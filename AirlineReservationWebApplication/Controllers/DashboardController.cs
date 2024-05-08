using AirlineReservationWebApplication.Data;
using AirlineReservationWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace AirlineReservationWebApplication.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DashboardController(ApplicationDbContext db)
        {
            _db = db;
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
