using AirlineReservationWebApplication.Data;
using AirlineReservationWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationWebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AccountController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        //Register GET
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        //Register POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel obj)
        {
            if (obj.Email== obj.Password )
            {
                ModelState.AddModelError("password", "The password cannot match the Email");
            }
            if (ModelState.IsValid)
            {
                bool IsRegistered = _db.Users.Any(x => x.Email == obj.Email);
                if (IsRegistered)
                {
                    ModelState.AddModelError("Email", "Already registered with this email");
                    return View();
                }
                _db.Users.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Successfully Registered";
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        //Login GET
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //Login POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel obj)
        {
            if (ModelState.IsValid)
            {
                bool EmailExists= _db.Users.Any(x=> x.Email == obj.Email);
                bool PassExists= _db.Users.Any(x=> x.Password == obj.Password);
                if (EmailExists && PassExists)
                {
                    TempData["success"] = "Successfully Logged in";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Password", "The password you have entered is incorrect");
                }
                
            }
            return View();
        }
    }
}

