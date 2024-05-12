using AirlineReservationWebApplication.Data;
using AirlineReservationWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationWebApplication.Controllers
{
    public class PassengerController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PassengerController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            if (TempData.ContainsKey("AdminEmail"))
            {
                IEnumerable<PassengerViewModel> objPassengerList = _db.Passenger;
                Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
                return View(objPassengerList);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult CreatePassenger()
        {
            if (TempData.ContainsKey("AdminEmail"))
            {
                /* var existingPassengers = _db.Passenger
                     .Select(ps => ps.User_Id)
                     .ToList();*/

                var availableUsers = _db.User.Select(user => user).Where(us => us.User_Email!= "admin@sample.com").ToList();

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
        public IActionResult CreatePassenger(PassengerViewModel obj)
        {
            if (ModelState.IsValid)
            {
                bool PassportExist = _db.Passenger.Any(x => x.Passport == obj.Passport);
                int mobile = obj.Mobile;
                int nid = obj.Nid;
                int passportSize = obj.Passport.Length;
                if (PassportExist)
                {
                    ModelState.AddModelError("Passport", "This Passenger is already registered");
                    return View(obj);
                }
                int checkMobile = CountDigits(mobile);
                if(passportSize < 9)
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
        public IActionResult UpdatePassenger(int? id)
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
        public IActionResult UpdatePassenger(PassengerViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var passenger = _db.Passenger.Find(obj.Passenger_ID);
                if (passenger != null)
                {
                    if (passenger.Passport != obj.Passport)
                    {
                        bool duplicate = _db.Passenger.Any(x => x.Passport == obj.Passport);
                        if (duplicate)
                        {
                            ModelState.AddModelError("passport", "A passenger already exists with this passport");
                            return View(obj);
                        }
                        passenger.Passport = obj.Passport;
                    }
                    passenger.First_Name = obj.First_Name;
                    passenger.Last_Name = obj.Last_Name;
                    passenger.Gender = obj.Gender;
                    passenger.Mobile = obj.Mobile;
                    passenger.Nid = obj.Nid;
                    passenger.Email = obj.Email;
                    passenger.Address = obj.Address;
                    passenger.User_Id = obj.User_Id;
                    passenger.Is_Approved = obj.Is_Approved;
                    passenger.AllUsers = obj.AllUsers;
                    _db.Passenger.Update(passenger);
                    _db.SaveChanges();
                    TempData["success"] = "Passenger successfully Updated";
                } 
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult DeletePassenger(int? id)
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
        public IActionResult DeletePassenger(int id)
        {
            var passenger = _db.Passenger.Find(id);
            if (passenger != null)
            {
                _db.Passenger.Remove(passenger);
                _db.SaveChanges();
                ModelState.Clear();
                TempData["success"] = "Passenger successfully Deleted";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
