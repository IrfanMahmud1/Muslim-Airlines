using AirlineReservationWebApplication.Data;
using AirlineReservationWebApplication.Factory;
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
            /* if (TempData.ContainsKey("UserEmail"))
             {
                 return RedirectToAction("Search", "Flights", new { area = string.Empty });
             }*/
            if (TempData.ContainsKey("AdminEmail"))
            {
                return RedirectToAction("Dashboard", "AdminDashboard", new { area = "Admin" });
            }
            var allFlights = _userflightsearchmodelFactory.PreapreUserFlightSearchModel();
            var editUserFlight = new EditUserFlightSearchAndFlightViewModel();
            editUserFlight.userFlightSearchModel = allFlights;

            return View(editUserFlight);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Index(UserFlightSearchModel model)
        //{
        //    return View(model);
        //}
        public IActionResult Logout()
        {
            if (TempData.ContainsKey("UserEmail"))
            {
                TempData["success"] = "Successfully Logged out";
                TempData.Remove("UserEmail");
            }
            return RedirectToAction("Index", "Home", new { area = string.Empty });
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
