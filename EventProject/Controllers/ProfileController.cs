﻿using System;
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
using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;



namespace EventProject.Controllers
{
    public class ProfileController : Controller
    {
        private IProfileObjectsRepository repository;
        public const string properties = "ID, Name, Location, Gender, Birthday, Location, Occupation, AboutText, ProfileImage";
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IImageHandler _imageHandler;


        public ProfileController(IProfileObjectsRepository r, UserManager<IdentityUser> userManager, IImageHandler imageHandler)
        {
            _userManager = userManager;
            repository = r;
            _imageHandler = imageHandler;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View();
        }


        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(IFormFile avatarFile, [Bind(properties)] ProfileViewModel c)
        {       
            if (!ModelState.IsValid) return View(c);
            var fileName = await _imageHandler.UploadImage(avatarFile, GetCurrentUserId());
            if (fileName == Constants.InvalidImageFile) return View(c);


            var o = ProfileObjectFactory.Create(GetCurrentUserId(), c.Name, c.Location, c.Gender, c.BirthDay, c.Occupation, c.AboutText, fileName);                                                       
            await repository.AddObject(o);

            return RedirectToAction("Details"); 
        }


        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            var currentUser = await repository.GetObject(id);
            return View(ProfileViewModelFactory.Create(currentUser));
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IFormFile avatarFile, [Bind(properties)] ProfileViewModel c)
        {
            if (!ModelState.IsValid) return View(c);
            var o = await repository.GetObject(c.ID);

            var fileName = await _imageHandler.UploadImage(avatarFile, GetCurrentUserId());
            if (fileName == Constants.InvalidImageFile) return View(c);

            o.DbRecord.Name = c.Name;
            o.DbRecord.Location = c.Location;
            o.DbRecord.Gender = c.Gender;
            o.DbRecord.BirthDay = c.BirthDay;
            o.DbRecord.Occupation = c.Occupation;
            o.DbRecord.AboutText = c.AboutText;
            o.DbRecord.ProfileImage = fileName;

            await repository.UpdateObject(o);


            return RedirectToAction("Index");
        }



        [Authorize]
        public async Task<IActionResult> Details()
        {
            var currentUser = await repository.GetObject(GetCurrentUserId());     
            return View(ProfileViewModelFactory.Create(currentUser));
        }

        [Authorize]
        public ActionResult Delete(string id)
        {
            return View();
        }



        private static string GetUniqueID()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
            
        }

        private string GetCurrentUserId()
        {
            return _userManager.GetUserId(HttpContext.User);
        }
    }
}