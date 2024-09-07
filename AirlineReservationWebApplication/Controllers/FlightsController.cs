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

        public FlightsController(ApplicationDbContext db, IUserFlightSearchModelFactory userFlightSearchModelFactory, ILogger<HomeController> logger)
        {
            _db = db;
            _userflightsearchmodelFactory = userFlightSearchModelFactory;
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
                //if(TempData.ContainsKey("flights"))
                //{

                //}
                return Redirect("/Home/Index");
            }


            var flightResults = JsonConvert.DeserializeObject<EditUserFlightSearchAndFlightViewModel>(flightResultsJson);
            return View(flightResults);

        }
        public IActionResult Review(int? id)
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            return View();
        }
    }
}
