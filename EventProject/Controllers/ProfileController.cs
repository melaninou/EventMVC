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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;



namespace EventProject.Controllers
{
    public class ProfileController : Controller
    {
        private IProfileObjectsRepository repository;
        public const string properties = "ID, Name, Location, Gender, Birthday, Location, Occupation, AboutText, ProfileImage";
        private readonly UserManager<IdentityUser> _userManager;
       


        public ProfileController(IProfileObjectsRepository r, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            repository = r;
     

        }

        [Authorize]
        public async Task<IActionResult> Index()
        {

            var currentUser = await repository.GetObject(GetCurrentUserId());
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
        [HttpPost("Create")]
        public async Task<IActionResult> Create(IFormFile avatarFile, [Bind(properties)] ProfileViewModel c)
        {       

            if (!ModelState.IsValid) return View(c);

            string profileImageFilename = GetUniqueID();

            await UploadProfileImage(avatarFile, GetCurrentUserId(), profileImageFilename);

            var o = ProfileObjectFactory.Create(GetCurrentUserId(), c.Name, c.Location, c.Gender, c.BirthDay, c.Occupation, c.AboutText, profileImageFilename);                                                       
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

            o.DbRecord.Name = c.Name;
            o.DbRecord.Location = c.Location;
            o.DbRecord.Gender = c.Gender;
            o.DbRecord.BirthDay = c.BirthDay;
            o.DbRecord.Occupation = c.Occupation;
            o.DbRecord.AboutText = c.AboutText;
            o.DbRecord.ProfileImage = c.ProfileImage;

            await UploadProfileImage(avatarFile, GetCurrentUserId(), c.ProfileImage);

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

        private static void EnsureFolderExists(string filePath)
        {
            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            }
        }

        private async Task UploadProfileImage(IFormFile avatarFile, string userIdForFolder, string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\" + userIdForFolder,
                fileName + ".jpg");

            EnsureFolderExists(filePath);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await avatarFile.CopyToAsync(stream);
            }
        }
    }
}