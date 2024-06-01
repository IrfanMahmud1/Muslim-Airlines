using AirlineReservationWebApplication.Areas.Admin.Models;
using AirlineReservationWebApplication.Data;
using AirlineReservationWebApplication.Areas.Admin.Models;
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

        //Register GET
        [HttpGet]
        public IActionResult Register()
        {
            if (TempData.ContainsKey("UserEmail"))
            {
                return RedirectToAction("Index", "HomePage", new {area = string.Empty});
            }
            TempData["register"] = "activate";
            return View();
        }

        //Register POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UsersViewModel obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.User_Email == obj.Password)
                {
                    ModelState.AddModelError("password", "The password cannot match the Email");
                    return View();
                }
                bool IsRegisteredEmail = _db.User.Any(x => x.User_Email == obj.User_Email);
                bool IsRegisteredUser = _db.User.Any(x => x.User_Name == obj.User_Name);
                if (IsRegisteredEmail)
                {
                    ModelState.AddModelError("User_Email", "Already registered with this email");
                    return View();
                }
                if (IsRegisteredUser)
                {
                    ModelState.AddModelError("User_Name", "Already registered with this name");
                    return View();
                }
                _db.User.Add(obj);
                ModelState.Clear();
                _db.SaveChanges();
                ModelState.Clear();
                TempData["success"] = "Successfully Registered";
                return View("Login");
            }
            return View();
        }

        //Login GET
        [HttpGet]
        public IActionResult Login()
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            if (TempData.ContainsKey("UserEmail"))
            {
                return RedirectToAction("Index", "HomePage", new {area = string.Empty});
            }
            if (TempData.ContainsKey("AdminEmail"))
            {
                return RedirectToAction("Dashboard", "AdminDashboard", new { area = "Admin" });
            }
            TempData["Log In"] = "activate";
            return View();
        }

        //Login POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel obj)
        {
            if (ModelState.IsValid && !TempData.ContainsKey("UserEmail"))
            {
                bool EmailExists= _db.User.Any(x=> x.User_Email == obj.Email);
                bool PassExists= _db.User.Any(x=> x.Password == obj.Password);
                if (!EmailExists)
                {
                    ModelState.AddModelError("Email", "Invalid email");
                    ModelState.AddModelError("Password", "Incorrect password");
                }
                else if (!PassExists)
                {
                    ModelState.AddModelError("Password", "Incorrect password");
                }
                else
                {
                    string userEmail = obj.Email;
                    string AdminEmail = userEmail.Substring(userEmail.Length - 11);
                    
                    var user = _db.User.ToList().Find(x => x.User_Email == obj.Email);
                    
                    TempData["success"] = "Successfully Logged in";

                    if (userEmail.ToLower().Contains("admin") && AdminEmail == "@sample.com")
                    {
                        TempData["AdminName"] = user.User_Name;
                        TempData["AdminEmail"] = userEmail;

                        return RedirectToAction("Dashboard", "AdminDashboard", new { area = "Admin" });
                    }
                    TempData["UserName"] = user.User_Name;
                    TempData["UserEmail"] = userEmail;

                    return RedirectToAction("Index", "HomePage");
                }
            }
            return View();
        }
    }
}
