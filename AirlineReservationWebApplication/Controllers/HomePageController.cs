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
                TempData.Keep("UserEmail");            
            }
            else
            {
                return RedirectToAction("Index", "Home", new {area = string.Empty});
            }
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            return View();
        }

        //Log out
       
    }
}
