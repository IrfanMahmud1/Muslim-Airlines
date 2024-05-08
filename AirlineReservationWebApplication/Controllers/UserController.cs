using AirlineReservationWebApplication.Data;
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
                IEnumerable<RegisterViewModel> objUserList = _db.Users;
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
        public IActionResult CreateUser(RegisterViewModel obj)
        {
            if (ModelState.IsValid)
            {
                bool isRegisteredEmail = _db.Users.Any(x => x.User_Email == obj.User_Email);
                bool isRegisteredName = _db.Users.Any(x => x.User_Name == obj.User_Name);
                if (isRegisteredEmail)
                {
                    ModelState.AddModelError("User_Email", "Already registered with this email");
                    if (isRegisteredName)
                    {
                        ModelState.AddModelError("User_Name", "Already registered with this name");
                        return View();
                    }
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
        public IActionResult UpdateUser(RegisterViewModel obj)
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
                            ModelState.AddModelError("User_Email", "Already         registered with this email");
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
        public IActionResult DeleteUser(RegisterViewModel obj)
        {
            bool isValid = _db.Users.Any(x => x.User_Id == obj.User_Id);
            if (isValid)
            {
                _db.Users.Remove(obj);
                _db.SaveChanges();
                ModelState.Clear();
                TempData["success"] = "User successfully Deleted";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
