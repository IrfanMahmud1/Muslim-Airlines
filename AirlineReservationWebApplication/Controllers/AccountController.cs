using AirlineReservationWebApplication.Data;
using AirlineReservationWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace AirlineReservationWebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AccountController(ApplicationDbContext db)
        {
            _db = db;
        }

       /* public IActionResult Index()
        {
            return View();
        }*/
        //Register GET
        [HttpGet]
        public IActionResult Register()
        {
            if (TempData.ContainsKey("UserEmail"))
            {
                return RedirectToAction("Index", "HomePage");
            }
            return View();
        }

        //Register POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.User_Email == obj.Password)
                {
                    ModelState.AddModelError("password", "The password cannot match the Email");
                    return View();
                }
                bool IsRegistered = _db.Users.Any(x => x.User_Email == obj.User_Email);
                if (IsRegistered)
                {
                    ModelState.AddModelError("User_Email", "Already registered with this email");
                    return View();
                }
                _db.Users.Add(obj);
                ModelState.Clear();
                _db.SaveChanges();
                TempData["success"] = "Successfully Registered";      
                return View(obj);
            }
            return View();
        }

        //Login GET
        [HttpGet]
        public IActionResult Login()
        {
            if (TempData.ContainsKey("UserEmail"))
            {
                string IsAdmin = TempData["UserEmail"].ToString();
                if(IsAdmin.ToLower().Contains("admin") && IsAdmin.Substring(IsAdmin.Length - 11) == "@sample.com")
                {
                    return RedirectToAction("Dashboard", "Admin");
                }
                return RedirectToAction("Index", "HomePage");
            }
            return View();
        }

        //Login POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel obj)
        {
            if (ModelState.IsValid && !TempData.ContainsKey("UserEmail"))
            {
                bool EmailExists= _db.Users.Any(x=> x.User_Email == obj.Email);
                bool PassExists= _db.Users.Any(x=> x.Password == obj.Password);
                if (!EmailExists)
                {
                    ModelState.AddModelError("Email", "Invalid email");
                    ModelState.AddModelError("Password", "Incorrect password");
                }
                else if(!PassExists)
                {
                    ModelState.AddModelError("Password", "Incorrect password");
                }
                else
                {
                    string userEmail = obj.Email;
                    string AdminEmail = userEmail.Substring(userEmail.Length - 11);
                    
                    var user = _db.Users.ToList().Find(x => x.User_Email == obj.Email);
                    TempData["UserName"] = user.User_Name;
                    TempData["UserEmail"] = userEmail;
                    TempData["success"] = "Successfully Logged in";

                    if (userEmail.ToLower().Contains("admin") && AdminEmail == "@sample.com")
                    {
                        return RedirectToAction("Dashboard", "Admin");
                    }
                    return RedirectToAction("Index", "HomePage");
                }
            }
            return View();
        }

    }
}

