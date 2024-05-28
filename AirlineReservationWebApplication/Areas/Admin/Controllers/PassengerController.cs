using AirlineReservationWebApplication.Areas.Admin.Models;
using AirlineReservationWebApplication.Data;
using AirlineReservationWebApplication.Factory;
using AirlineReservationWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
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
                List<PassengerViewModel> objPassengerList = _db.Passenger.ToList();
                Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
                return View(objPassengerList);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult CreatePassenger()
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            if (TempData.ContainsKey("AdminEmail"))
            {
                var newPassenger = _passengerModelFactory.PreparePassengerViewModel();
                return View(newPassenger);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePassenger(PassengerViewModel obj)
        {
            var newPassenger = _passengerModelFactory.PreparePassengerViewModel();
            if (ModelState.IsValid)
            {
                obj.AllUsers = newPassenger.AllUsers;
                bool PassportExist = _db.Passenger.Any(x => x.Passport == obj.Passport);
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

                int checkMobile = obj.Mobile.Length;
                if (checkMobile != 11)
                {
                    ModelState.AddModelError("Mobile", "Invalid Mobile number");
                    return View(obj);
                }

                int checkNid = obj.Nid.Length;
                if (checkNid != 10)
                {
                    ModelState.AddModelError("NID", "Invalid NID number");
                    return View(obj);
                }
                _db.Passenger.Add(obj);
                _db.SaveChanges();
                ModelState.Clear();
                TempData["success"] = "Passengers successfully created.";
                return RedirectToAction("Index");
            }
            return View(newPassenger);
        }

        [HttpGet]
        public IActionResult UpdatePassenger(int? id)
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            if (TempData.ContainsKey("AdminEmail"))
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }
                var newPassenger = _passengerModelFactory.PreparePassengerViewModel();
                PassengerViewModel passengerFromDb = _db.Passenger.Find(id);
                if (passengerFromDb == null)
                {
                    return View();
                }
                passengerFromDb.AllUsers = newPassenger.AllUsers;
                return View(passengerFromDb);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePassenger(PassengerViewModel obj)
        {
            var newPassenger = _passengerModelFactory.PreparePassengerViewModel();
            obj.AllUsers = newPassenger.AllUsers;
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
                    TempData["success"] = "Passengers successfully Updated";
                }
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult DeletePassenger(int? id)
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            if (TempData.ContainsKey("AdminEmail"))
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }
                var newPassenger = _passengerModelFactory.PreparePassengerViewModel();
                PassengerViewModel passengerFromDb = _db.Passenger.Find(id);
                if (passengerFromDb == null)
                {
                    return View();
                }
                passengerFromDb.AllUsers = newPassenger.AllUsers;
                return View(passengerFromDb);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePassenger(int id)
        {
            var passengerFromDb = _db.Passenger.Find(id);
            if (passengerFromDb != null)
            {
                _db.Passenger.Remove(passengerFromDb);
                _db.SaveChanges();
                ModelState.Clear();
                TempData["success"] = "Passenger successfully Deleted";
                return RedirectToAction("Index");
            }
            return View(passengerFromDb);
        }
    }
}
