using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminDashboardController : Controller
    {
        public IActionResult Dashboard()
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            if (TempData.ContainsKey("AdminEmail"))
            {
                TempData.Keep("AdminEmail");
                return View();
            }

            return RedirectToAction("Index", "Home", new {area = string.Empty});
        }

        public IActionResult Logout()
        {
            if (TempData.ContainsKey("AdminEmail"))
            {
                TempData["success"] = "Successfully Logged out";
                TempData.Remove("AdminEmail");
            }
            else
            {
                return NotFound();
            }
            return RedirectToAction("Index", "Home", new {area = string.Empty});
        }

    }
}
