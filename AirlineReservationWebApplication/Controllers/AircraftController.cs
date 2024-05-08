using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationWebApplication.Controllers
{
    public class AircraftController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
