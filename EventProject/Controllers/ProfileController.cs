using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain.Profile;
using Facade.Profile;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EventProject.Controllers
{
    public class ProfileController : Controller
    {
        private IProfileObjectsRepository repository;
        public const string properties = "ID, Name, Gender, Age, Location";



        public ProfileController(IProfileObjectsRepository r)
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
        public async Task<IActionResult> Create([Bind(properties)] ProfileViewModel c)
        {
            if (!ModelState.IsValid) return View(c);         
            var o = ProfileObjectFactory.Create(c.ID, c.Name, c.Location, c.Age, c.Gender);
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