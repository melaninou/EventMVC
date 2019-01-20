using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EventProject.Controllers
{
    public interface IEventProjectController
    {
        Task<IActionResult> Index(string sortOrder = null,
            string searchString = null,
            int? page = null,
            string currentFilter = null);
        ActionResult Create();
        Task<IActionResult> Edit(string id);
       // Task<IActionResult> Details(string id);
        Task<IActionResult> Delete(string id);

    }
}