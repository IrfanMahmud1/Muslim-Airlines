/*using AirlineReservationWebApplication.Data;
using AirlineReservationWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationWebApplication.Controllers
{
    public class AircraftController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AircraftController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            if (TempData.ContainsKey("AdminEmail"))
            {
                IEnumerable<AircraftViewModel> objAircraftList = _db.Aircraft;
                Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
                TempData["user_id"] = 7;
                return View(objAircraftList);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult CreateAircraft()
        {
            if (TempData.ContainsKey("AdminEmail"))
            {
                return View();
            }
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAircraft(AircraftViewModel obj)
        {
            if (ModelState.IsValid)
            {
                bool aircraft = _db.Aircraft.Any(x => x.Aircraft_Name == obj.Aircraft_Name);
                if(aircraft)
                {
                    ModelState.AddModelError("aircraft", "This aircraft name is already exist.Try a new aircraft name");
                    return View();
                }
                _db.Aircraft.Add(obj);
                _db.SaveChanges();
                ModelState.Clear();
                TempData["success"] = "Aircraft successfully Created";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateAircraft(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var aircraftFromDb = _db.Aircraft.Find(id);
            if (aircraftFromDb == null)
            {
                return NotFound();
            }
            return View(aircraftFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateAircraft(AircraftViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var passenger = _db.Aircraft.Find(obj.Aircraft_Id);
                if (passenger != null)
                {
                    _db.Aircraft.Update(obj);
                    _db.SaveChanges();
                    TempData["success"] = "Passenger successfully Updated";
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult DeleteAircraft(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var passengerFromDb = _db.Passenger.Find(id);
            if (passengerFromDb == null)
            {
                return NotFound();
            }
            return View(passengerFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAircraft(AircraftViewModel obj)
        {
            bool isValid = _db.Aircraft.Any(x => x.Aircraft_Model == obj.Aircraft_Model);
            if (isValid)
            {
                _db.Aircraft.Remove(obj);
                _db.SaveChanges();
                ModelState.Clear();
                TempData["success"] = "User successfully Deleted";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
*/