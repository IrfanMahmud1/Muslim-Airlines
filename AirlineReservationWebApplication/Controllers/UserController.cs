﻿using AirlineReservationWebApplication.Data;
using AirlineReservationWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationWebApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            if (TempData.ContainsKey("AdminEmail"))
            {
                List<UserViewModel> objUserList = _db.Users.ToList();
                Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
                return View(objUserList);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            if (TempData.ContainsKey("AdminEmail"))
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUser(UserViewModel obj)
        {
            if (ModelState.IsValid)
            {
                bool isRegisteredEmail = _db.Users.Any(x => x.User_Email == obj.User_Email);

                if (isRegisteredEmail)
                {
                    ModelState.AddModelError("User_Email", "A user already registered with this email. Try a different one.");                    
                    return View();
                }
                _db.Users.Add(obj);
                _db.SaveChanges();
                ModelState.Clear();
                TempData["success"] = "User successfully Created";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateUser(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var userFromDb = _db.Users.Find(id);
            if (userFromDb == null)
            {
                return NotFound();
            }
            return View(userFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateUser(UserViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var user = _db.Users.Find(obj.User_Id);
                if (user != null)
                {
                    if (user.User_Email != obj.User_Email)
                    {
                        bool duplicate = _db.Users.Any(x => x.User_Email == obj.User_Email);
                        if (duplicate)
                        {
                            ModelState.AddModelError("User_Email", "Already registered with this email");
                            return View();
                        }
                        user.User_Email = obj.User_Email;
                    }
                    if (user.User_Name != obj.User_Name)
                    {
                        user.User_Name = obj.User_Name;
                    }
                    if (user.Password != obj.Password)
                    {
                        user.Password = obj.Password;
                    }
                    _db.Users.Update(user);
                    _db.SaveChanges();
                    ModelState.Clear();
                    TempData["success"] = "User successfully Updated";
                }
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult DeleteUser(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var userFromDb = _db.Users.Find(id);
            if (userFromDb == null)
            {
                return NotFound();
            }
            return View(userFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteUser(int id)
        {
            var user = _db.Users.Find(id);
            if (user != null)
            {
                _db.Users.Remove(user);
                _db.SaveChanges();
                ModelState.Clear();
                TempData["success"] = "User successfully deleted.";
            }
            else
                TempData["error"] = "User not found.";

            return RedirectToAction("Index");
        }
    }
}
