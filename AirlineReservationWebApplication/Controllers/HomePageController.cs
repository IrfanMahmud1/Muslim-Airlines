﻿using AirlineReservationWebApplication.Data;
using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationWebApplication.Controllers
{
    public class HomePageController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HomePageController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (TempData.ContainsKey("UserEmail"))
            {
                TempData.Keep("UserEmail");            
            }
            else
            {
                return RedirectToAction("Index", "Home", new {area = string.Empty});
            }
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            return View();
        }

        //Log out
       
    }
}
