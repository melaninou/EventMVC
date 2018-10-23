using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aids;
using Core;
using Data;
using Domain.Event;
using Facade.Event;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EventProject.Controllers
{
    public class EventController : Controller
    {
        public const string properties = "ID, Name, Date, Type, Description, Location, Organiser";

        private IEventObjectsRepository repository;
      
        
        public EventController(IEventObjectsRepository r)
        {
            repository = r;
         
        }
        public async Task<IActionResult> Index()
        {
           
           
               var l = await repository.GetObjectsList();
                return View(new EventViewModelsList(l));
           
           
        }
       

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind(properties)] EventViewModel e)
        {
            //await validateId(e.ID, ModelState);
            if (!ModelState.IsValid) return View(e);
            var o = EventObjectFactory.Create(GetUniqueID(), e.Name, e.Location, e.Date, e.Type, e.Organiser, e.Description);
            await repository.AddObject(o);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string id)
        {
            var c = await repository.GetObject(id);
            return View(EventViewModelFactory.Create(c));
        }
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
            o.DbRecord.Organiser = c.Organiser;
            await repository.UpdateObject(o);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(string id)
        {
            var c = await repository.GetObject(id);
            return View(EventViewModelFactory.Create(c));
        }
        public async Task<IActionResult> Delete(string id)
        {
            var c = await repository.GetObject(id);
            return View(EventViewModelFactory.Create(c));
        }
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
            if (sortOrder.StartsWith("organiser")) return x => x.Organiser;
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
    }
}