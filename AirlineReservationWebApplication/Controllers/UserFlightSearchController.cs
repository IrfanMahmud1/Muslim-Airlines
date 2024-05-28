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

        public UserFlightSearchController(ApplicationDbContext db, 
            IUserFlightSearchModelFactory userFlightSearchModelFactory)
        {
            _db = db;
            _userflightsearchmodelFactory = userFlightSearchModelFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Check(FlightSearchFormData data)
        {
            string origin = data.origin;
            string des = data.destination;

            bool success = true;

            if (success)
            {
                return Json(new { status = "success", message = "Operation was successful." });
            }
            else
            {
                return Json(new { status = "error", message = "There was an error." });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Flights(UserFlightSearchModel obj)
        {
            var flightResults = _userflightsearchmodelFactory.PrepareUserFlightResults(obj);
            if (ModelState.IsValid)
            {
                return View(flightResults);
            }
            return Redirect("/Home/Index");
        }
    }
}
