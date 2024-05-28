using AirlineReservationWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AirlineReservationWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IUserFlightSearchModelFactory _userflightsearchmodelFactory;
        private readonly ILogger<HomeController> _logger;
        private bool Search {  get; set; }
        private bool Modify { get; set; }

        public HomeController(ApplicationDbContext db , IUserFlightSearchModelFactory userFlightSearchModelFactory ,ILogger<HomeController> logger)
        {
            _db = db;
            _userflightsearchmodelFactory = userFlightSearchModelFactory;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            if (TempData.ContainsKey("UserEmail"))
            {
                return RedirectToAction("Index", "HomePage");
            }
            if (TempData["UserEmail"]!=null)
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            var allFlights = _userflightsearchmodelFactory.PreapreUserFlightSearchModel();
            var editUserFlight = new EditUserFlightSearchAndFlightViewModel();
            editUserFlight.userFlightSearchModel = allFlights;
            TempData["action"] = "Index";
            return View(editUserFlight);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(UserFlightSearchModel obj)
        {
            var flightResults = _userflightsearchmodelFactory.PrepareUserFlightResults(obj);
            if (ModelState.IsValid)
            {
                if (obj.Origin == obj.Destination)
                {
                    TempData["error"] = "Origin and Destination cannot be same";
                    ModelState.AddModelError("Origin", "Origin and Destination cannot be same");
                    if (TempData.ContainsKey("Modify"))
                    {
                        return View(flightResults);
                    }
                    return RedirectToAction("Index");
                }
                TempData["Modify"] = "true";
                Check();
                return View(flightResults);
            }
            return RedirectToAction("Index");
        }

        public void Check()
        {
            if (TempData.ContainsKey("Modify"))
            {
                TempData.Keep("Modify");
            }
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
                    if (TempData.ContainsKey("Modify"))
                    {
                        return View(flightResults);
                    }
                    return RedirectToAction("Index");
                }
                TempData["Modify"] = "true";
                Check();
                return View(flightResults);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
