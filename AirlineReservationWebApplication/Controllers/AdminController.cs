using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationWebApplication.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            if (TempData.ContainsKey("UserEmail"))
            {
                string IsAdmin = TempData["UserEmail"].ToString();
                if (IsAdmin.ToLower().Contains("admin") && IsAdmin.Substring(IsAdmin.Length - 11) == "@sample.com")
                {
                    return RedirectToAction("Dashboard", "Admin");
                }
                return NotFound();
            }
            return View();
        }
        public IActionResult Dashboard()
        {
            if (TempData.ContainsKey("UserEmail"))
            {
                string IsAdmin = TempData["UserEmail"].ToString();
                if (IsAdmin.ToLower().Contains("admin") && IsAdmin.Substring(IsAdmin.Length - 11) == "@sample.com")
                {
                    TempData.Keep("UserEmail");
                    return View();
                }
                return NotFound();
            }
            return NotFound();
        }

        public IActionResult Logout()
        {
            if (TempData.ContainsKey("UserEmail"))
            {
                string IsAdmin = TempData["UserEmail"].ToString();
                if (IsAdmin.ToLower().Contains("admin") && IsAdmin.Substring(IsAdmin.Length - 11) == "@sample.com")
                {
                    TempData["success"] = "Successfully Logged out";
                    TempData.Remove("UserEmail");
                    return RedirectToAction("Index", "Admin");
                }
                return NotFound();
            }
            return NotFound();
        }
        public IActionResult User()
        {
            return View();
        }
        public IActionResult Passenger()
        {
            return View();
        }
        public IActionResult Flight()
        {
            return View();
        }
        public IActionResult Reservation()
        {
            return View();
        }
        public IActionResult Offer()
        {
            return View();
        }
        public IActionResult Hotel()
        {
            return View();
        }
        public IActionResult Aircraft()
        {
            return View();
        }
        public IActionResult PrivateService()
        {
            return View();
        }
        public IActionResult Transport()
        {
            return View();
        }
    }
}
