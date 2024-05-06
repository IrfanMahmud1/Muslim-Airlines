using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationWebApplication.Controllers
{
    public class HomePageController : Controller
    {
        private readonly ILogger<HomePageController> _logger;

        public HomePageController(ILogger<HomePageController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (TempData.ContainsKey("UserEmail"))
            {
                ViewBag.DisableLoginButton = true;
                ViewBag.DisableRegisterButton = true;
                ViewBag.UserEmail = TempData["UserEmail"].ToString();
                TempData.Keep("UserEmail");
            }

            return View();
        }

        //Log out
        [HttpGet]
        public IActionResult Logout()
        {
            TempData["LogoutFlag"] = "true";
            TempData["success"] = "Successfully Logged out";
            TempData.Remove("UserEmail");
            return RedirectToAction("Index", "Home");
        }
    }
}
