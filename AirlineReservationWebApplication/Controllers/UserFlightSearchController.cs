using AirlineReservationWebApplication.Data;
using AirlineReservationWebApplication.Factory;
using AirlineReservationWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationWebApplication.Controllers
{
    public class UserFlightSearchController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IUserFlightSearchModelFactory _userflightsearchmodelFactory;

        public UserFlightSearchController(ApplicationDbContext db, IUserFlightSearchModelFactory userFlightSearchModelFactory)
        {
            _db = db;
            _userflightsearchmodelFactory = userFlightSearchModelFactory;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Flights(UserFlightSearchModel obj)
        {
            var flightResults = _userflightsearchmodelFactory.PrepareUserFlightResults(obj);
            if (ModelState.IsValid)
            {
                if (obj.Origin == obj.Destination)
                {
                    TempData["error"] = "Origin and Destination cannot be same";
                    ModelState.AddModelError("Origin", "Origin and Destination cannot be same");
                    return RedirectToAction("Index", "Home");
                }
                return View(flightResults);
            }
            return RedirectToAction("Index");
        }
    }
}
