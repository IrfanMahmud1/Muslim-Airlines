using AirlineReservationWebApplication.Areas.Admin.Factory;
using AirlineReservationWebApplication.Areas.Admin.Models;
using AirlineReservationWebApplication.Data;
using AirlineReservationWebApplication.Factory;
using AirlineReservationWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AirlineReservationWebApplication.Controllers
{
    public class FlightsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IUserFlightSearchModelFactory _userflightsearchmodelFactory;
        private readonly IPassengerModelFactory _passengermodelFactory;

        public FlightsController(ApplicationDbContext db, IUserFlightSearchModelFactory userFlightSearchModelFactory, IPassengerModelFactory passengerModelFactory)
        {
            _db = db;
            _userflightsearchmodelFactory = userFlightSearchModelFactory;
            _passengermodelFactory = passengerModelFactory;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Search(UserFlightSearchModel obj)
        {

            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            if (ModelState.IsValid)
            {
                EditUserFlightSearchAndFlightViewModel flightResults = _userflightsearchmodelFactory.PrepareUserFlightResults(obj);
                HttpContext.Session.SetString("FlightResults", JsonConvert.SerializeObject(flightResults));
                TempData["flights"] = "active";
                return RedirectToAction("SearchResults");
            }
            return Redirect("/Home/Index");
        }

        [HttpGet]
        public IActionResult SearchResults()
        {
            var flightResultsJson = HttpContext.Session.GetString("FlightResults");

            if (flightResultsJson == null)
            {
                return Redirect("/Home/Index");
            }


            var flightResults = JsonConvert.DeserializeObject<EditUserFlightSearchAndFlightViewModel>(flightResultsJson);
            return View(flightResults);

        }

        [HttpGet]
        public IActionResult Book(int? id)
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            var users = _passengermodelFactory.PreparePassengerViewModel();
            return View(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Review(PassengerViewModel obj)
        {
            if(ModelState.IsValid)
            {
                if (obj.Title.Contains("Mr"))
                {
                    obj.Gender = "Male";
                }
                else
                {
                    obj.Gender = "Female";
                }
                return RedirectToAction("Confirm",obj);
            }
            return NotFound();
        }

        public IActionResult Confirm(PassengerViewModel obj)
        {
            return View();
        }
    }
}
