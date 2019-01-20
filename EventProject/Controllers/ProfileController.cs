using System;
using System.IO;
using System.Threading.Tasks;
using Domain.Profile;
using Facade.Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Core;
using Microsoft.AspNetCore.Http;
namespace EventProject.Controllers
{
    public class ProfileController : Controller, IEventProjectController
    {
        private IProfileObjectsRepository repository;
        public const string properties = "ID, Name, Location, Gender, BirthDay, Location, Occupation, AboutText, ProfileImage";
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
            var currentUser = await repository.GetObject(GetCurrentUserId());
            if (currentUser.DbRecord.ID == "Unspecified")
            {
                return RedirectToAction(nameof(Create));
            }
            else
            {
                return RedirectToAction(nameof(Details));
            }
        }

        [Authorize]
        public async Task<IActionResult> FindFriends()
        {
            var l = await repository.GetObjectsList();
            //ProfileViewModel allProfiles = new ProfileViewModel();
            //allProfiles = await repository.GetObjectsList();

            return View(new ProfileViewModelsList(l));
        }

        public Task<IActionResult> Index(string sortOrder = null, 
            string searchString = null, 
            int? page = null, 
            string currentFilter = null)
        {
            throw new NotImplementedException();
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile avatarFile, [Bind(properties)] ProfileViewModel c)
        {       
            if (!ModelState.IsValid) return View(c);

            var extension = "." + avatarFile.FileName.Split('.')[avatarFile.FileName.Split('.').Length - 1];
            string fileName = GetUniqueID() + extension;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\" + GetCurrentUserId(), fileName);

            var isCorrectImage = await _imageHandler.UploadImage(avatarFile, path);

            if (!isCorrectImage) return View(c);

            var o = ProfileObjectFactory.Create(GetCurrentUserId(), c.Name, c.Location, c.Gender, c.BirthDay, c.Occupation, c.AboutText, fileName);                                                       
            await repository.AddObject(o);

            return RedirectToAction(nameof(Details)); 
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

            string fileName = o.DbRecord.ProfileImage; 
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\" + GetCurrentUserId(), fileName);
            var isCorrectImage = await _imageHandler.UploadImage(avatarFile, path);

            if (!isCorrectImage) return View(c);

            o.DbRecord.Name = c.Name;
            o.DbRecord.Location = c.Location;
            o.DbRecord.Gender = c.Gender;
            o.DbRecord.BirthDay = c.BirthDay;
            o.DbRecord.Occupation = c.Occupation;
            o.DbRecord.AboutText = c.AboutText;
            o.DbRecord.ProfileImage = fileName;

            await repository.UpdateObject(o);

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                id = GetCurrentUserId();
            }
            var otherUser = await repository.GetObject(id);
            return View(ProfileViewModelFactory.Create(otherUser));
        }

        [Authorize]
        public async Task<IActionResult> Delete(string id)
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