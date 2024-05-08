﻿using AirlineReservationWebApplication.Data;
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
                TempData["user_id"] = 7;
                return View(objPassengerList);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult CreatePassenger(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var userFromDb = _db.Users.Find(id);
            PassengerViewModel passengerFromDb = new PassengerViewModel();
            passengerFromDb.User_Id = userFromDb.User_Id;
            passengerFromDb.registerViewModel = userFromDb;
            if (passengerFromDb == null)
            {
                return NotFound();
            }
            return View(passengerFromDb);
        }
        public static int CountDigits(int number)
        {
            return (int)Math.Floor(Math.Log10(Math.Abs(number))) + 1;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePassenger(PassengerViewModel obj)
        {
            if (obj.registerViewModel.Password == null)
            {
               
            }
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
