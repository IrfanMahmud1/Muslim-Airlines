using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationWebApplication.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            if (TempData.ContainsKey("AdminEmail"))
            {
                TempData.Keep("AdminEmail");
                Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
                return View();
            }
            
            return RedirectToAction("Index", "Home");

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
            return RedirectToAction("Index", "Home");
        }
        
    }
}
