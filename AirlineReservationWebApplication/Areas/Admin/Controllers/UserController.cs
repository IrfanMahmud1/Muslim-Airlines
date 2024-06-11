using AirlineReservationWebApplication.Data;
using AirlineReservationWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
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
                IEnumerable<UserViewModel> objUserList = _db.User;
                Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
                return View(objUserList);
            }
            return RedirectToAction("Index", "Home", new { area = string.Empty });
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            if (TempData.ContainsKey("AdminEmail"))
            {
                return View();
            }
            return RedirectToAction("Index", "Home", new { area = string.Empty });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUser(UserViewModel obj)
        {
            if (ModelState.IsValid)
            {
                bool isRegisteredEmail = _db.User.Any(x => x.User_Email == obj.User_Email);
                bool isRegisteredName = _db.User.Any(x => x.User_Name == obj.User_Name);
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
                _db.User.Add(obj);
                _db.SaveChanges();
                ModelState.Clear();
                TempData["success"] = "User successfully Created";
                return View("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateUser(int? id)
        {
            if (TempData.ContainsKey("AdminEmail"))
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }
                var userFromDb = _db.User.Find(id);
                if (userFromDb == null)
                {
                    return NotFound();
                }
                return View(userFromDb);
            }
            return RedirectToAction("Index", "Home", new { area = string.Empty });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateUser(UserViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var user = _db.User.Find(obj.User_Id);
                if (user != null)
                {
                    if (user.User_Email != obj.User_Email)
                    {
                        bool duplicate = _db.User.Any(x => x.User_Email == obj.User_Email);
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
                    _db.User.Update(user);
                    _db.SaveChanges();
                    ModelState.Clear();
                    TempData["success"] = "User successfully Updated";
                }
                return View("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult DeleteUser(int? id)
        {
            if (TempData.ContainsKey("AdminEmail"))
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }
                var userFromDb = _db.User.Find(id);
                if (userFromDb == null)
                {
                    return NotFound();
                }
                return View(userFromDb);
            }
            return RedirectToAction("Index", "Home", new { area = string.Empty });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteUser(int id)
        {
            var user = _db.User.Find(id);
            if (user != null)
            {
                _db.User.Remove(user);
                _db.SaveChanges();
                ModelState.Clear();
                TempData["success"] = "User successfully deleted.";
            }
            else
                TempData["error"] = "User not found.";

            return View("Index");
        }
    }
}
