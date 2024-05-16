using AirlineReservationWebApplication.Data;
using AirlineReservationWebApplication.Factory;
using AirlineReservationWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationWebApplication.Controllers
{
    public class PassengerController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IPassengerModelFactory _passengerModelFactory;

        public PassengerController(ApplicationDbContext db, IPassengerModelFactory passengerModelFactory)
        {
            _db = db;
            _passengerModelFactory = passengerModelFactory;
        }

        public IActionResult Index()
        {
            if (TempData.ContainsKey("AdminEmail"))
            {
                List<PassengerViewModel> objPassengerList = _db.Passengers.ToList();
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
                var newPassenger = _passengerModelFactory.PreparePassengerViewModel();
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
                int mobile = obj.Mobile;
                int nid = obj.Nid;

                bool PassportExist = _db.Passengers.Any(x => x.Passport == obj.Passport);
                if (PassportExist)
                {
                    ModelState.AddModelError("Passport", "This Passenger is already registered");
                    return View(obj);
                }

                int passportSize = obj.Passport.Length;
                if (passportSize < 9)
                {
                    ModelState.AddModelError("Passport", "Invalid Passport number");
                    return View(obj);
                }

                int checkMobile = CountDigits(mobile);
                if (checkMobile != 10)
                {
                    ModelState.AddModelError("Mobile", "Invalid Mobile number");
                    return View(obj);
                }

                int checkNid = CountDigits(nid);
                if (checkNid != 10)
                {
                    ModelState.AddModelError("NID", "Invalid NID number");
                    return View(obj);
                }

                _db.Passengers.Add(obj);
                _db.SaveChanges();
                ModelState.Clear();
                TempData["success"] = "Passengers successfully created.";
                return RedirectToAction("Index");
            }

            var newPassenger = _passengerModelFactory.PreparePassengerViewModel();
            return View(newPassenger);
        }

        [HttpGet]
        public IActionResult UpdatePassenger(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var passengerFromDb = _db.Passengers.Find(id);
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
                var passenger = _db.Passengers.Find(obj.Passenger_ID);
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
                    TempData["success"] = "Passengers successfully Updated";
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
            var passengerFromDb = _db.Passengers.Find(id);
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
