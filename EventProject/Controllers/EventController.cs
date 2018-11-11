using System;
using System.IO;
using System.Threading.Tasks;
using Aids;
using Core;
using Data;
using Domain.Attending;
using Domain.Event;
using Domain.Profile;
using EventProject.Hubs;
using Facade.Event;
using Infra;
using Infra.Attending;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.SignalR;

namespace EventProject.Controllers
{
    public class EventController : Controller
    {
        public const string properties = "ID, Name, Date, Type, Description, Location, Organizer, EventImage";

        private IEventObjectsRepository _eventRepository;

        private readonly UserManager<IdentityUser> _userManager;

        private readonly IProfileObjectsRepository _profileRepository;

        private readonly IAttendingObjectsRepository _attendingRepository;

        private readonly IImageHandler _imageHandler;
        private readonly IHubContext<CalendarHub> _hubContext;


        public EventController(IEventObjectsRepository repository, UserManager<IdentityUser> userManager,
            IProfileObjectsRepository profileRepository, IAttendingObjectsRepository attendingRepository, IImageHandler imageHandler, IHubContext<CalendarHub> hubContext)
        {

            _userManager = userManager;
            _profileRepository = profileRepository;
            _eventRepository = repository;
            _attendingRepository = attendingRepository;
            _imageHandler = imageHandler;
            _hubContext = hubContext;

        }
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

            var l = await _eventRepository.GetObjectsList();
                return View(new EventViewModelsList(l));
        }
       
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(IFormFile avatarFile, [Bind(properties)] EventViewModel e)
        {
          
            if (!ModelState.IsValid) return View(e);
            var eventId = GetUniqueID();

            var extension = "." + avatarFile.FileName.Split('.')[avatarFile.FileName.Split('.').Length - 1]; //.jpg, . jne
            string fileName = GetUniqueID() + extension;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\"  + /*GetCurrentUserID(), */fileName); //kuhu pilt läheb

            var isCorrectImage = await _imageHandler.UploadImage(avatarFile, path);

            if (!isCorrectImage) return View(e);

            var o = EventObjectFactory.Create(GetUniqueID(), e.Name, e.Location, e.Date, e.Type, GetCurrentUserID(), e.Description, fileName);
            await _eventRepository.AddObject(o);
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", e.ID, e.Name, e.Location, e.Date);
            return RedirectToAction("Index");
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
            //var currentUserName = GetCurrentUserName();
            //var organizatorName =GetOrgName(id);
           
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
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\" + /*GetCurrentUserID(),*/ fileName);
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
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(string id)
        {
            var currentEventObject = await _eventRepository.GetObject(id);
            var organizatorObject = await _profileRepository.GetObject(currentEventObject.DbRecord.Organizer);
            var organizatorName = organizatorObject.DbRecord.Name;
            currentEventObject.DbRecord.Organizer = organizatorName;

            await _attendingRepository.LoadProfiles(currentEventObject);

            return View(EventViewModelFactory.Create(currentEventObject));
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
            //var currentUserName = GetCurrentUserName();
            //var organizatorName =GetOrgName(id);
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
            await _eventRepository.DeleteObject(c);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Attending(string id)
        {
            string userID = GetCurrentUserID();
            var eventObject = await _eventRepository.GetObject(id);
            string eventID = eventObject.DbRecord.ID;
            var userObject = await _profileRepository.GetObject(userID);
            var o = AttendingObjectFactory.Create(eventObject, userObject, eventID, userID);
            await _attendingRepository.AddObject(o);
            return RedirectToAction("Details", new {id});
        }

        public async Task<IActionResult> NotAttending(string id)
        {
            var o = await _attendingRepository.GetObject(id, GetCurrentUserID());
            await _attendingRepository.DeleteObject(o);
            return RedirectToAction("Details", new {id});
        }

        public async Task<IActionResult> Register(string id)
        {
            //TODO figure out how to find out if an object exists already
            if (_attendingRepository.FindObject(id, GetCurrentUserID()).Result == null)
            {
                return RedirectToAction("Attending", new {id});
            }
            else
            {
                return RedirectToAction("NotAttending", new {id});
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

        private async Task<string> GetCurrentUserName()
        {
            string id = GetCurrentUserID();
            var currentUserObject = await _profileRepository.GetObject(id);
            var currentUserName = currentUserObject.DbRecord.Name;
            return currentUserName;
        }

        private async Task<string> GetOrgName(string id)
        {

            var currentEventObject = await _eventRepository.GetObject(id);
            var organizatorObject = await _profileRepository.GetObject(currentEventObject.DbRecord.Organizer);
            var organizatorName = organizatorObject.DbRecord.Name;
            return organizatorName;
        }

        public async Task<IActionResult> Calendar()
        {
            var l = await _eventRepository.GetObjectsList();
            return View(new EventViewModelsList(l));
           // return View();
        }

    }
}