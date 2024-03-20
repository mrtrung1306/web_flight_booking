using Microsoft.AspNetCore.Mvc;

namespace DemoMayBayCN.Admin.Controllers
{
    [Area("Admin")]
    public class FlightsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
