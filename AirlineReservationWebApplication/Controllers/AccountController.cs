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
            ViewBag.DisableRegisterButton = true;
            return View();
        }

        //Register POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Email == obj.Password)
                {
                    ModelState.AddModelError("password", "The password cannot match the Email");
                    return View();
                }
                bool IsRegistered = _db.Users.Any(x => x.Email == obj.Email);
                if (IsRegistered)
                {
                    ModelState.AddModelError("Email", "Already registered with this email");
                    return View();
                }
                _db.Users.Add(obj);
                _db.SaveChanges();
                ViewBag.DisableRegisterButton = true;
                TempData["success"] = "Successfully Registered";
                return View();
            }
            return View();
        }

        //Login GET
        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.DisableLoginButton = true;
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
                if (!PassExists && !EmailExists)
                {
                    ModelState.AddModelError("EmailPass", "Invalid email or password");
                    return View();
                }
                if (EmailExists && PassExists)
                {
                    //PassingDataModel passingDataModel = new PassingDataModel();
                    ViewData["Login"] = "true";
                    TempData["success"] = "Successfully Logged in";
                    return RedirectToAction("Index", "Home", new {IsLogged = "True"});
                }
                else
                {
                    if (!EmailExists)
                    {
                        ModelState.AddModelError("Email", "Invalid email");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Incorrect password");
                    }
                }
            }
            return View();
        }

        //Log out
        [HttpGet]
        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home", new{ IsLogged = "false" });
        }
    }
}

