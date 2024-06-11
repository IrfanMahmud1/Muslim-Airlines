using AirlineReservationWebApplication.Data;
using AirlineReservationWebApplication.Factory;
using AirlineReservationWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationWebApplication.Controllers
{
    public class FlightsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IUserFlightSearchModelFactory _userflightsearchmodelFactory;

        public FlightsController(ApplicationDbContext db, IUserFlightSearchModelFactory userFlightSearchModelFactory)
        {
            _db = db;
            _userflightsearchmodelFactory = userFlightSearchModelFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Search()
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            if (TempData.ContainsKey("UserEmail"))
            {
                TempData.Keep("UserEmail");
            }
            var allFlights = _userflightsearchmodelFactory.PreapreUserFlightSearchModel();
            var editUserFlight = new EditUserFlightSearchAndFlightViewModel();
            editUserFlight.userFlightSearchModel = allFlights;
            return View("~/Views/Home/Index.cshtml",editUserFlight);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Search(UserFlightSearchModel obj)
        {
            var flightResults = _userflightsearchmodelFactory.PrepareUserFlightResults(obj);
            if (ModelState.IsValid)
            {
                return View(flightResults);
            }
            return Redirect("/Home/Index");
        }

        [HttpGet]
        public IActionResult Review(int? id)
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            return View();
        }
    }
}
