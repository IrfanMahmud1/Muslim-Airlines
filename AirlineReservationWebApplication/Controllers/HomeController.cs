using AirlineReservationWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AirlineReservationWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       /* private bool flag {  get; set; }*/
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (TempData["success"]!=null && TempData["success"] == "Successfully Logged out")
            {
                ViewBag.DisableLoginButton = true;
                ViewBag.DisableRegisterButton = true;
            }
            if (TempData["UserEmail"]!=null)
            {
                return RedirectToAction("Index", "HomePage");
            }
            return View();
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
