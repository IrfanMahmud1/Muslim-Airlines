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
                IEnumerable<PassengerViewModel> objPassengerList = _db.Passenger;
                Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
                TempData["user_id"] = 7;
                return View(objPassengerList);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult CreateAircraft()
        {
            if (TempData.ContainsKey("AdminEmail"))
            {
                var admin = _db.Users.Where(user => user.User_Email.Equals("admin@sample.com")).FirstOrDefault();

                var existingPassengers = _db.Passenger
                    .Select(ps => ps.User_Id)
                    .ToList();

                var availableUsers = _db.Users
                    .Where(user => !existingPassengers.Any(ps => ps == user.User_Id)
                        && user.User_Id != admin.User_Id)
                    .ToList();

                var newPassenger = new PassengerViewModel();

                newPassenger.AllUsers = new List<(string, int)>();

                foreach (var user in availableUsers)
                {
                    newPassenger.AllUsers.Add((user.User_Name, user.User_Id));
                }

                // Existing users: 1, 2, 3, 4, 5, 6, 7, 8
                // Already passenger: 1, 3, 6, 7
                // Available users: 2, 4, 5, 8

                return View(newPassenger);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAircraft(AircraftViewModel obj)
        {
            if (ModelState.IsValid)
            {
                _db.Aircraft.Add(obj);
                _db.SaveChanges();
                ModelState.Clear();
                TempData["success"] = "Passenger successfully Created";
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
            var passengerFromDb = _db.Passenger.Find(id);
            if (passengerFromDb == null)
            {
                return NotFound();
            }
            return View(passengerFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateAircraft(AircraftViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var passenger = _db.Aircraft.Find(obj.Aircraft_Model);
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