using Aids;
using Core;
using Data;
using Domain.Attending;
using Domain.Comment;
using Domain.CommentProfile;
using Domain.Event;
using Domain.Profile;
using EventProject.Hubs;
using Facade.Comment;
using Facade.Event;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Domain.CommentEvent;

namespace EventProject.Controllers
{
    public class EventController : Controller, IEventProjectController
    {
        public const string properties = "ID, Name, Date, Type, Description, Location, Organizer, EventImage";
        public const string propertie = "CommentText";


        private readonly IEventObjectsRepository _eventRepository;
        private readonly IProfileObjectsRepository _profileRepository;
        private readonly IAttendingObjectsRepository _attendingRepository;

        private readonly ICommentObjectsRepository _commentRepository;
        private readonly ICommentEventObjectsRepository _commentEventRepository;
        private readonly ICommentProfileObjectsRepository _commentProfileRepository;


        private readonly UserManager<IdentityUser> _userManager;
        private readonly IImageHandler _imageHandler;
        private readonly IHubContext<CalendarHub> _hubContext;

       
        public EventController(IEventObjectsRepository repository, UserManager<IdentityUser> userManager,
            IProfileObjectsRepository profileRepository, IAttendingObjectsRepository attendingRepository, IImageHandler imageHandler, 
            IHubContext<CalendarHub> hubContext, ICommentObjectsRepository commentRepository, ICommentEventObjectsRepository commentEventRepository, ICommentProfileObjectsRepository commentProfileRepository)
        {
            _userManager = userManager;
            _profileRepository = profileRepository;
            _eventRepository = repository;
            _attendingRepository = attendingRepository;
            _imageHandler = imageHandler;
            _hubContext = hubContext;
            _commentRepository = commentRepository;
            _commentEventRepository = commentEventRepository;
            _commentProfileRepository = commentProfileRepository;
        }

        [Authorize]
        public async Task<IActionResult> Index(string sortOrder = null,
            string searchString = null, int? page = null, string currentFilter = null)
        {
            ViewData["userRealName"] = await _profileRepository.GetObjectsList();
            ViewData["SortName"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["SortID"] = sortOrder == "id" ? "id_desc" : "id";
            ViewData["SortDate"] = sortOrder == "date" ? "date_desc" : "date";
            ViewData["SortLocation"] = sortOrder == "location" ? "location_desc" : "location";
            ViewData["SortOrganizer"] = sortOrder == "organizer" ? "organizer_desc" : "organizer";
            _eventRepository.SortOrder = sortOrder != null && sortOrder.EndsWith("_desc")
                ? SortOrder.Descending
                : SortOrder.Ascending;
            _eventRepository.SortFunction = getSortFunction(sortOrder);
            if (searchString != null) page = 1;
            else searchString = currentFilter;
            ViewData["CurrentFilter"] = searchString;
            _eventRepository.SearchString = searchString;
            _eventRepository.PageIndex = page ?? 1;

            AllEventsViewModel allevents = new AllEventsViewModel();
            allevents.AllEventViewModel = await _eventRepository.GetObjectsList();
            allevents.MyEventsViewModel = await _attendingRepository.GetUserEventsList(GetCurrentUserID());
            allevents.MyOrganizedEventsViewModel = await _eventRepository.GetOrganizerEventsList(GetCurrentUserID());

            return View(allevents);
        }
       
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile avatarFile, [Bind(properties)] EventViewModel e)
        {        
            if (!ModelState.IsValid) return View(e);

            var extension = "." + avatarFile.FileName.Split('.')[avatarFile.FileName.Split('.').Length - 1]; //.jpg, . jne
            string fileName = GetUniqueID() + extension;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\"  + /*GetCurrentUserID(), */fileName); //kuhu pilt läheb

            var isCorrectImage = await _imageHandler.UploadImage(avatarFile, path);

            if (!isCorrectImage) return View(e);

            var eventID = GetUniqueID();

            var o = EventObjectFactory.Create(eventID, e.Name, e.Location, e.Date, e.Type, GetCurrentUserID(), e.Description, fileName, DateTime.Now);
            await _eventRepository.AddObject(o);
            await RegisterToEvent(eventID);
            string eventTimeFormat = e.Date.ToString("MMMM dd, yyyy hh:mm");
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", eventID, e.Name, e.Location, eventTimeFormat, fileName);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            string ID = GetCurrentUserID();
            var currentUserObject = await _profileRepository.GetObject(ID);
            var currentUserName = currentUserObject.DbRecord.Name;

            var currentEventObject = await _eventRepository.GetObject(id);
            var organizatorObject = await _profileRepository.GetObject(currentEventObject.DbRecord.Organizer);
            var organizatorName = organizatorObject.DbRecord.Name;

            if (currentUserName == organizatorName)
            {
                var c = await _eventRepository.GetObject(id);
                return View(EventViewModelFactory.Create(c));
            }
            else
            {
                return Content("You can't edit it, if you don't create it!");
            }
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IFormFile avatarFile, [Bind(properties)] EventViewModel c)
        {
            if (!ModelState.IsValid) return View(c);
            var o = await _eventRepository.GetObject(c.ID);

            string fileName = o.DbRecord.EventImage;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\" +  fileName);
            var isCorrectImage = await _imageHandler.UploadImage(avatarFile, path);

            if (!isCorrectImage) return View(c);

            o.DbRecord.Name = c.Name;
            o.DbRecord.Location = c.Location;
            o.DbRecord.Date = c.Date;
            o.DbRecord.Type = c.Type;
            o.DbRecord.Description = c.Description;
            o.DbRecord.Organizer = c.Organizer;
            o.DbRecord.EventImage = fileName;
            await _eventRepository.UpdateObject(o);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            var currentEventObject = await _eventRepository.GetObject(id);
            var organizatorObject = await _profileRepository.GetObject(currentEventObject.DbRecord.Organizer);
            var organizatorName = organizatorObject.DbRecord.Name;
            currentEventObject.DbRecord.Organizer = organizatorName;

            await _attendingRepository.LoadProfiles(currentEventObject);

            List<CommentObject> newlist = new List<CommentObject>();
            newlist = await _commentEventRepository.GetCommentsList(id);

            List<CommentProfileViewModel> fullComments = new List<CommentProfileViewModel>();

            foreach (var value in newlist)
            {
                var personId = await _commentProfileRepository.GetObjectString(value.DbRecord.ID);
                var personObject = await _profileRepository.GetObject(personId);
                var name = personObject.DbRecord.Name;
                var img = personObject.DbRecord.ProfileImage;
                

                var v = new CommentProfileViewModel()
                {
                    ID = personId,
                    Name = name,
                    CommentAddTime = value.DbRecord.CommentAddTime,
                    Subject = value.DbRecord.Name,
                    Email = value.DbRecord.Location,
                    CommentText = value.DbRecord.CommentText,
                    Image = img
                };
                fullComments.Add(v);
            }

            AllCommentViewModel allComments = new AllCommentViewModel();
            allComments.EventViewModel = EventViewModelFactory.Create(currentEventObject);
            allComments.CommentProfileViewModel = fullComments;

            if (_attendingRepository.FindObject(id, GetCurrentUserID()).Result == null)
            {
                ViewData["RegisterButtonText"] = "Register to Event";
            }
            else
            {
                ViewData["RegisterButtonText"] = "Unregister";
            }
            
            return View(allComments);
        }

        public async Task<string> GetUserName(string commentId)
        {
           var n =await _commentProfileRepository.GetObject(commentId);
           var name = n.ProfileObject.DbRecord.Name;
           return name;

        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateNewComment(string commentText, string id, string subject, string email)
        {
            // COMMENT
            var commentId = GetUniqueID();
            string currentUserId = GetCurrentUserID();
            var o = CommentObjectFactory.Create(commentId, DateTime.Now, commentText, subject, email);
            await _commentRepository.AddObject(o);


            // COMMENT-EVENT
            var eventObject = await _eventRepository.GetObject(id);
            var commentObject = await _commentRepository.GetObject(commentId);

            var ceo = CommentEventObjectFactory.Create(eventObject, commentObject, id, commentId);
            await _commentEventRepository.AddObject(ceo);

            //COMMENT-PROFILE
            var profileObject = await _profileRepository.GetObject(currentUserId);

            var cpo = CommentProfileObjectFactory.Create(commentObject, profileObject, commentId, currentUserId);
            await _commentProfileRepository.AddObject(cpo);

            return RedirectToAction(nameof(Details),new { id });
        }


        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            string ID = GetCurrentUserID();
            var currentUserObject = await _profileRepository.GetObject(ID);
            var currentUserName = currentUserObject.DbRecord.Name;

            var currentEventObject = await _eventRepository.GetObject(id);
            var organizatorObject = await _profileRepository.GetObject(currentEventObject.DbRecord.Organizer);
            var organizatorName = organizatorObject.DbRecord.Name;
            if (currentUserName == organizatorName)
            {
                var c = await _eventRepository.GetObject(id);
                return View(EventViewModelFactory.Create(c));
            }
            else
            {
                return Content("You can't delete it, if you don't create it!"); //selle asemel peaks üldse see, kes ei koostanud, et  ei näe neid nuppe
            }
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {

            var c = await _eventRepository.GetObject(id);
            var currentEventObject = await _eventRepository.GetObject(id);
            var organizatorObject = await _profileRepository.GetObject(currentEventObject.DbRecord.Organizer);
            var organizatorName = organizatorObject.DbRecord.Name;
            currentEventObject.DbRecord.Organizer = organizatorName;
            await _attendingRepository.RemoveListObjects(c);
            await _eventRepository.DeleteObject(c);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Attending(string id)
        {
            await RegisterToEvent(id);
            return RedirectToAction(nameof(Details), new {id});
        }

        [Authorize]
        private async Task RegisterToEvent(string id)
        {
            string userID = GetCurrentUserID();
            var eventObject = await _eventRepository.GetObject(id);
            string event_ID = eventObject.DbRecord.ID;
            var userObject = await _profileRepository.GetObject(userID);
            var o = AttendingObjectFactory.Create(eventObject, userObject, event_ID, userID);
            await _attendingRepository.AddObject(o);
        }

        [Authorize]
        public async Task<IActionResult> NotAttending(string id)
        {
            var o = await _attendingRepository.GetObject(id, GetCurrentUserID());
            await _attendingRepository.DeleteObject(o);
            return RedirectToAction(nameof(Details), new {id});
        }

        [Authorize]
        public async Task<IActionResult> Register(string id)
        {
            //TODO figure out how to find out if an object exists already
            if (_attendingRepository.FindObject(id, GetCurrentUserID()).Result == null)
            {
                return RedirectToAction(nameof(Attending), new {id});
            }
            else
            {
                return RedirectToAction(nameof(NotAttending), new {id});
            }
        }

        private Func<EventDbRecord, object> getSortFunction(string sortOrder)
        {
            if (string.IsNullOrWhiteSpace(sortOrder)) return x => x.Name;
            if (sortOrder.StartsWith("date")) return x => x.Date;
            if (sortOrder.StartsWith("location")) return x => x.Location;
            if (sortOrder.StartsWith("id")) return x => x.ID;
            if (sortOrder.StartsWith("organizer")) return x => x.Organizer;
            return x => x.Name;
        }

        private async Task validateId(string id, ModelStateDictionary d)
        {
            if (await isIdInUse(id))
                d.AddModelError(string.Empty, idIsInUseMessage(id));
        }

        private async Task<bool> isIdInUse(string id)
        {
            return (await _eventRepository.GetObject(id))?.DbRecord?.ID == id;
        }

        private static string idIsInUseMessage(string id)
        {
            var name = GetMember.DisplayName<EventViewModel>(c => c.ID);
            return string.Format(Messages.ValueIsAlreadyInUse, id, name);
        }

        private static string GetUniqueID()
        {
            Guid guid = Guid.NewGuid();
            string uniqueID = guid.ToString();
            return uniqueID;
        }

        private string GetCurrentUserID()
        {
            return _userManager.GetUserId(HttpContext.User).ToString();
        }



        public async Task<IActionResult> Calendar()
        {
            var l = await _eventRepository.GetObjectsList();
            return View(new EventViewModelsList(l));
        }


        private async Task<string> GetCurrentUserImage()
        {
            string currentUserID = GetCurrentUserID();
            var obj = await _profileRepository.GetObject(currentUserID);
            var currentUserImage = obj.DbRecord.ProfileImage;
            return currentUserImage;
        }

       

        private async Task<string> GetCurrentUserName()
        {
            string id = GetCurrentUserID();
            var currentUserObject = await _profileRepository.GetObject(id);
            var currentUserName = currentUserObject.DbRecord.Name;

           
            return currentUserName;
        }
    }
}