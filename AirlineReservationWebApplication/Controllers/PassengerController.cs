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
        public IActionResult CreatePassenger(PassengerViewModel obj)
        {
            /*if (obj.registerViewModel == null)
            {
                var user = _db.Users.Find(obj.User_Id);
                if(user == null)
                {
                    ModelState.AddModelError("User Id", "Invalid User Id");
                    return View(obj);
                }
                user.ConfirmPassword = user.Password;
                obj.registerViewModel = user;
            }*/
            if (ModelState.IsValid)
            {
                bool isPassportExist = _db.Passenger.Any(x => x.Passport == obj.Passport);
                int mobile = obj.Mobile;
                int nid = obj.Nid;
                if (isPassportExist)
                {
                    ModelState.AddModelError("Passport", "Already registered with this passport number");
                    return View();
                }
                int checkMobile = CountDigits(mobile);
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
                    _db.Passenger.Update(obj);
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
        public IActionResult DeletePassenger(PassengerViewModel obj)
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
    }
}
