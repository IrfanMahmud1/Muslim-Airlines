using AirlineReservationWebApplication.Data;
using AirlineReservationWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationWebApplication.Controllers
{
    public class FlightController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FlightController(ApplicationDbContext db)
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
        public IActionResult CreateFlight()
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
        public static int CountDigits(int number)
        {
            return (int)Math.Floor(Math.Log10(Math.Abs(number))) + 1;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateFlight(PassengerViewModel obj)
        {
            if (ModelState.IsValid)
            {
                bool PassportExist = _db.Passenger.Any(x => x.Passport == obj.Passport);
                int mobile = obj.Mobile;
                int nid = obj.Nid;
                int passportSize = obj.Passport.Length;
                if (PassportExist)
                {
                    ModelState.AddModelError("Passport", "Already registered with this passport number");
                    return View();
                }
                int checkMobile = CountDigits(mobile);
                if (passportSize < 9)
                {
                    ModelState.AddModelError("passport", "Invalid Passport number");
                    return View();
                }
                if (checkMobile < 10 || checkMobile > 10)
                {
                    ModelState.AddModelError("mobile", "Invalid Mobile number");
                    return View();
                }
                int checkNid = CountDigits(nid);
                if (checkNid < 10 || checkNid > 10)
                {
                    ModelState.AddModelError("nid", "Invalid NID number");
                    return View();
                }

                _db.Passenger.Add(obj);
                _db.SaveChanges();
                ModelState.Clear();
                TempData["success"] = "Passenger successfully Created";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateFlight(int? id)
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
        public IActionResult UpdateFlight(PassengerViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var passenger = _db.Passenger.Find(obj.Passenger_ID);
                if (passenger != null)
                {
                    _db.Passenger.Update(obj);
                    _db.SaveChanges();
                    TempData["success"] = "Passenger successfully Updated";
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult DeleteFlight(int? id)
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
        public IActionResult DeleteFlight(PassengerViewModel obj)
        {
            bool isValid = _db.Passenger.Any(x => x.Passenger_ID == obj.Passenger_ID);
            if (isValid)
            {
                _db.Passenger.Remove(obj);
                _db.SaveChanges();
                ModelState.Clear();
                TempData["success"] = "User successfully Deleted";
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Logout()
        {
            if (TempData.ContainsKey("AdminEmail"))
            {
                TempData["success"] = "Successfully Logged out";
                TempData.Remove("AdminEmail");
                //return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
