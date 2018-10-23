using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain.Profile;
using Facade.Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Server.Kestrel.Core;


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

        [Authorize]
        public async Task<IActionResult> Index()
        {
            string userId = _userManager.GetUserId(HttpContext.User);
            var currentUser = await repository.GetObject(userId);
            if (currentUser.DbRecord.ID == "Unspecified")
            {
                return RedirectToAction("Create");
            }
            else
            {
                return RedirectToAction("Details");
            }
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([Bind(properties)] ProfileViewModel c)
        {
            if (!ModelState.IsValid) return View(c);
            string userId = _userManager.GetUserId(HttpContext.User);
            var o = ProfileObjectFactory.Create(userId, c.Name, c.Location, c.Age, c.Gender);
            await repository.AddObject(o);
            return RedirectToAction("Details"); 
        }

        [Authorize]
        public ActionResult Edit()
        {
            return View();
        }

        [Authorize]
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

        [Authorize]
        public async Task<IActionResult> Details()
        {
            string userId = _userManager.GetUserId(HttpContext.User);
            var currentUser = await repository.GetObject(userId);
            return View(ProfileViewModelFactory.Create(currentUser));
        }

        [Authorize]
        public ActionResult Delete(string id)
        {
            return View();
        }
    }
}