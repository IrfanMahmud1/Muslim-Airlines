using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationWebApplication.Controllers
{
    public class PrivateServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
