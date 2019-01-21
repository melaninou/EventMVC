using System;
using System.IO;
using System.Threading.Tasks;
using Domain.Profile;
using Facade.Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Core;
using Domain.Following;
using Microsoft.AspNetCore.Http;
namespace EventProject.Controllers
{
    public class ProfileController : Controller, IEventProjectController
    {
        private readonly IProfileObjectsRepository _profileRepository;
        private readonly IFollowingObjectsRepository _followingRepository;

        public const string properties = "ID, Name, Location, Gender, BirthDay, Location, Occupation, AboutText, ProfileImage";
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IImageHandler _imageHandler;


        public ProfileController(IProfileObjectsRepository r, IFollowingObjectsRepository followingRepository, UserManager<IdentityUser> userManager, IImageHandler imageHandler)
        {
            _profileRepository = r;
            _followingRepository = followingRepository;
            _userManager = userManager;
            _imageHandler = imageHandler;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var currentUser = await _profileRepository.GetObject(GetCurrentUserId());
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
            var l = await _profileRepository.GetObjectsList();
            //ProfileViewModel allProfiles = new ProfileViewModel();
            //allProfiles = await _profileRepository.GetObjectsList();

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
            await _profileRepository.AddObject(o);

            return RedirectToAction(nameof(Details)); 
        }


        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            var currentUser = await _profileRepository.GetObject(id);
            return View(ProfileViewModelFactory.Create(currentUser));
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IFormFile avatarFile, [Bind(properties)] ProfileViewModel c)
        {
            if (!ModelState.IsValid) return View(c);
            var o = await _profileRepository.GetObject(c.ID);

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

            await _profileRepository.UpdateObject(o);

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Details(string id, bool currentUser)
        {
            if (currentUser)
            {
                id = GetCurrentUserId();
            }
            var otherUserID = await _profileRepository.GetObject(id);

            
            await _followingRepository.LoadFollowers(otherUserID);

            if (_followingRepository.FindObject(id, GetCurrentUserID()).Result == null)
            {
                ViewData["FollowButtonText"] = "Follow";
            }
            else
            {
                ViewData["FollowButtonText"] = "Unfollow";
            }

            var currentUserObject = await _profileRepository.GetObject(GetCurrentUserID());
            var currentUserName = currentUserObject.DbRecord.Name;

            if (otherUserID.DbRecord.Name == currentUserName)
            {
                ViewData["IsCurrentPerson"] = "true";
            }
            else
            {
                ViewData["IsCurrentPerson"] = "false";
            }

            return View(ProfileViewModelFactory.Create(otherUserID));
        }

        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Follow(string id)
        {
            if (_followingRepository.FindObject(id, GetCurrentUserID()).Result == null)
            {
                return RedirectToAction(nameof(Following), new { id });
            }
            else
            {
                return RedirectToAction(nameof(NotFollowing), new { id });
            }
        }

        [Authorize]
        public async Task<IActionResult> Following(string id)
        {
            await FollowOtherUser(id);
            return RedirectToAction(nameof(Details), new { id });
        }

        [Authorize]
        private async Task FollowOtherUser(string id)
        {
            string userID = GetCurrentUserID();
            var userObject = await _profileRepository.GetObject(userID);
            var followedUserObject = await _profileRepository.GetObject(id);
            string followedUserID = followedUserObject.DbRecord.ID;
            var o = FollowingObjectFactory.Create(userObject, followedUserObject, userID, followedUserID);
            await _followingRepository.AddObject(o);
        }

        [Authorize]
        public async Task<IActionResult> NotFollowing(string id)
        {
            var o = await _followingRepository.GetObject(GetCurrentUserID(), id);
            await _followingRepository.DeleteObject(o);
            return RedirectToAction(nameof(Details), new { id });
        }

        public string GetCurrentUserID()
        {
            return _userManager.GetUserId(HttpContext.User).ToString();
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