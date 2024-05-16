using AirlineReservationWebApplication.Data;
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
                return View(objAircraftList);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult CreateAircraft()
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            if (TempData.ContainsKey("AdminEmail"))
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAircraft(AircraftViewModel obj)
        {
            if (ModelState.IsValid)
            {
                bool aircraft = _db.Aircraft.Any(x => x.Aircraft_Name == obj.Aircraft_Name);
                if (aircraft)
                {
                    ModelState.AddModelError("Aircraft_Name", "This aircraft name is already exist.Try a new aircraft name");
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
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
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
                var aircraft = _db.Aircraft.Find(obj.Aircraft_Id);
                if (aircraft != null)
                {
                    if (aircraft.Aircraft_Name != obj.Aircraft_Name)
                    {
                        bool duplicate = _db.Aircraft.Any(x => x.Aircraft_Name == obj.Aircraft_Name);
                        if (duplicate)
                        {
                            ModelState.AddModelError("Aircraft", "This aircraft is already exist.Try a different one");
                            return View(obj);
                        }
                        aircraft.Aircraft_Name = obj.Aircraft_Name;
                    }
                    aircraft.Aircraft_Category = obj.Aircraft_Category;
                    aircraft.Aircraft_Type = obj.Aircraft_Type;
                    aircraft.Seat_Capacity = obj.Seat_Capacity;
                    aircraft.Availability = obj.Availability;
                    _db.Aircraft.Update(aircraft);
                    _db.SaveChanges();
                    TempData["success"] = "Aircraft successfully Updated";
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult DeleteAircraft(int? id)
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var aircraftFromDb = _db.Aircraft.Find(id);
            return View(aircraftFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAircraft(int id)
        {
            var aircraft = _db.Aircraft.Find(id);
            if (aircraft != null)
            {
                _db.Aircraft.Remove(aircraft);
                _db.SaveChanges();
                ModelState.Clear();
                TempData["success"] = "Aircraft successfully Deleted";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
