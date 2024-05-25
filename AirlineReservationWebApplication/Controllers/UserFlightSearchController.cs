using AirlineReservationWebApplication.Data;
using AirlineReservationWebApplication.Factory;
using AirlineReservationWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationWebApplication.Controllers
{
    public class UserFlightSearchController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IUserFlightSearchModelFactory _userflightsearchmodelFactory;

        public UserFlightSearchController(ApplicationDbContext db, IUserFlightSearchModelFactory userFlightSearchModelFactory)
        {
            _db = db;
            _userflightsearchmodelFactory = userFlightSearchModelFactory;
        }
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
