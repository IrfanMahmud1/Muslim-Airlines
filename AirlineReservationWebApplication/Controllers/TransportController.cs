using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationWebApplication.Controllers
{
    public class TransportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
