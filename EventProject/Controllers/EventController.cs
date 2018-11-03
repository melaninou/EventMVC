using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aids;
using Core;
using Data;
using Domain.Event;
using Domain.Profile;
using Facade.Event;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EventProject.Controllers
{
    public class EventController : Controller
    {
        public const string properties = "ID, Name, Date, Type, Description, Location, Organizer";

        private IEventObjectsRepository repository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IProfileObjectsRepository _profile;
        
        public EventController(IEventObjectsRepository r, UserManager<IdentityUser> userManager, IProfileObjectsRepository profile)
        {
            _userManager = userManager;
            _profile = profile;
            repository = r;
         
        }
        public async Task<IActionResult> Index(string sortOrder = null,
            string currentFilter = null,
            string searchString = null,
            int? page = null)
        {

            ViewData["userRealName"] = await _profile.GetObjectsList();
            //ViewData["SortName"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewData["SortID"] = sortOrder == "id" ? "id_desc" : "id";
            //ViewData["SortDate"] = sortOrder == "date" ? "date_desc" : "date";
            //ViewData["SortLocation"] = sortOrder == "location" ? "location_desc" : "location";
            //ViewData["SortOrganizer"] = sortOrder == "organizer" ? "organizer_desc" : "organizer";
            //repository.SortOrder = sortOrder != null && sortOrder.EndsWith("_desc")
            //    ? SortOrder.Descending
            //    : SortOrder.Ascending;
            //repository.SortFunction = getSortFunction(sortOrder);
            //if (searchString != null) page = 1;
            //else searchString = currentFilter;
            //ViewData["CurrentFilter"] = searchString;
            //repository.SearchString = searchString;
            //repository.PageIndex = page ?? 1;
            var l = await repository.GetObjectsList();
                return View(new EventViewModelsList(l));
        }
       
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([Bind(properties)] EventViewModel e)
        {
          
            if (!ModelState.IsValid) return View(e);
            var o = EventObjectFactory.Create(GetUniqueID(), e.Name, e.Location, e.Date, e.Type, GetID(), e.Description);
            await repository.AddObject(o);
            return RedirectToAction("Index");
        }
        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
           
            var c = await repository.GetObject(id);
            return View(EventViewModelFactory.Create(c));
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind(properties)] EventViewModel c)
        {
            if (!ModelState.IsValid) return View(c);
            var o = await repository.GetObject(c.ID);
            o.DbRecord.Name = c.Name;
            o.DbRecord.Location = c.Location;
            o.DbRecord.Date = c.Date;
            o.DbRecord.Type = c.Type;
            o.DbRecord.Description = c.Description;
            o.DbRecord.Organizer = c.Organizer;
            await repository.UpdateObject(o);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(string id)
        {
            var currentEventObject = await repository.GetObject(id);
            var organizatorObject = await _profile.GetObject(currentEventObject.DbRecord.Organizer);
            var organizatorName = organizatorObject.DbRecord.Name;
            currentEventObject.DbRecord.Organizer = organizatorName;
            return View(EventViewModelFactory.Create(currentEventObject));
        }
        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            var c = await repository.GetObject(id);
            return View(EventViewModelFactory.Create(c));
        }
        [Authorize]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var c = await repository.GetObject(id);
            await repository.DeleteObject(c);
            return RedirectToAction("Index");
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
            return (await repository.GetObject(id))?.DbRecord?.ID == id;
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

        private string GetID()
        {
            return _userManager.GetUserId(HttpContext.User);
        }
    }
}