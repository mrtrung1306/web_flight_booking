using Microsoft.AspNetCore.Mvc;

namespace DemoMayBayCN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AirportsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}
