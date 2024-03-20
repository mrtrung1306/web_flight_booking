using Microsoft.AspNetCore.Mvc;

namespace DemoMayBayCN.Controllers
{
    public class CheckOutController : Controller
    {
        public IActionResult Seats()
        {
            return View();
        }
        public IActionResult Passengers()
        {
            return View();
        }
        public IActionResult TicketInformation()
        {
            return View();
        }
        public IActionResult PaymentSuccess()
        {
            return View(); 
        }
        public IActionResult SearchTicket()
        {
            return View();
        }
    }
}
