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

        private readonly UserManager<IdentityUser> _userManager;
 

        public ProfileController(IProfileObjectsRepository r, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
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
            string userId = _userManager.GetUserId(HttpContext.User);
            var o = ProfileObjectFactory.Create(c.ID, c.Name, c.Location, c.Age, c.Gender);
            await repository.AddObject(o);
            return RedirectToAction("Index"); 
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind(properties)] ProfileViewModel c)
        {
            if (!ModelState.IsValid) return View(c);
            var o = await repository.GetObject(c.ID);
            o.DbRecord.Name = c.Name;
            o.DbRecord.Location = c.Location;
            o.DbRecord.Age = c.Age;
            o.DbRecord.Gender = c.Gender;
            await repository.UpdateObject(o);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details()
        {
            string id = "1";
            var c = await repository.GetObject(id);
            return View(ProfileViewModelFactory.Create(c));
        }
        public ActionResult Delete(string id)
        {
            return View();
        }
    }
}