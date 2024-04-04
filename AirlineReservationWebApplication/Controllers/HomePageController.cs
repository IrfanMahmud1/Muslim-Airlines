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
                ViewBag.DisableLoginButton = true;
                ViewBag.DisableRegisterButton = true;
                ViewBag.UserEmail = userEmail;
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
