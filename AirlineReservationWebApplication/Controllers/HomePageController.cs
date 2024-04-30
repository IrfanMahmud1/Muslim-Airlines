using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationWebApplication.Controllers
{
    public class HomePageController : Controller
    {
        public IActionResult Index()
        {
            string userEmail = "";
            //string userName = "";
            if (TempData.ContainsKey("UserEmail"))
            {
                userEmail = TempData["UserEmail"].ToString();
                //userName = TempData["UserName"].ToString();
                ViewBag.UserEmail = userEmail;
                TempData.Keep("UserEmail");            
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            return View();
        }

        //Log out
        public IActionResult Logout()
        {
            if (TempData.ContainsKey("UserEmail"))
            {
                TempData["success"] = "Successfully Logged out";
                TempData.Remove("UserEmail");
                //return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
