using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Event;
using Facade.Event;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind(properties)] EventViewModel e)
        {
            if (!ModelState.IsValid) return View(e);
            var o = EventObjectFactory.Create(e.ID, e.Name, e.Location, e.Date, e.Type, e.Organiser, e.Description);
            await repository.AddObject(o);
            return RedirectToAction("Index");
        }

        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult Edit(string id)
        {
            return View();
        }
        public ActionResult Details(string id)
        {
            return View();
        }
        public ActionResult Delete(string id)
        {
            return View();
        }
    }
}