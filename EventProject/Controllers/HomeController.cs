using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain.Event;
using EventProject.Hubs;
using Microsoft.AspNetCore.Mvc;
using EventProject.Models;
using Facade.Event;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace EventProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly IEventObjectsRepository _eventRepository;
        private readonly IHubContext<CalendarHub> _hubContext;

        public HomeController(IEventObjectsRepository repository,
            IHubContext<CalendarHub> hubContext)
        {
            _eventRepository = repository;
            _hubContext = hubContext;
        }

        public async Task<IActionResult> Index()
        {
            var l = await _eventRepository.GetRecent5ObjectsList();
            return View(new EventViewModelsList(l));
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult CreateEvent()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        //public IActionResult ViewEvents()
        //{
        //    ViewData["Message"] = "Your application description page.";

        //    return View();
        //}
        public IActionResult Profile()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
