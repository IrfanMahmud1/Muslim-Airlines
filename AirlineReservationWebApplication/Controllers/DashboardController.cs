using AirlineReservationWebApplication.Data;
using AirlineReservationWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationWebApplication.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DashboardController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Users()
        {
            if(TempData.ContainsKey("AdminEmail"))
            {
                IEnumerable<RegisterViewModel> objUserList = _db.Users;
                Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
                return View(objUserList);
            }           
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            if(TempData.ContainsKey("AdminEmail"))
            {
                return View();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUser(RegisterViewModel obj)
        {
            ModelState.Clear();
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
                var ObjEmail = obj.User_Email;
                _db.Users.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "User successfully Created";
                return RedirectToAction("Users");
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateUser(int? id)
        {
            if(id==null ||  id==0)
            {
                return NotFound();
            }
            var userFromDb = _db.Users.Find(id);
            if(userFromDb==null)
            {
                return NotFound();
            }
             return View(userFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateUser(RegisterViewModel obj)
        {
            if(ModelState.IsValid)
            {
                bool isRegisteredEmail = _db.Users.Any(x=> x.User_Email == obj.User_Email); 
                bool isRegisteredName = _db.Users.Any(x=> x.User_Name == obj.User_Name);
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
                var ObjEmail = obj.User_Email;
                _db.Users.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "User successfully Updated";
                return RedirectToAction("Users");
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
            if (ModelState.IsValid)
            {
                var ObjEmail = obj.User_Email;
                _db.Users.Remove(obj);
                _db.SaveChanges();
                TempData["success"] = "User successfully Deleted";
                return RedirectToAction("Users");
            }
            return View();
        }
        public IActionResult Passenger()
        {
            return View();
        }
        public IActionResult Flight()
        {
            return View();
        }
        public IActionResult Reservation()
        {
            return View();
        }
        public IActionResult Offer()
        {
            return View();
        }
        public IActionResult Hotel()
        {
            return View();
        }
        public IActionResult Aircraft()
        {
            return View();
        }
        public IActionResult PrivateService()
        {
            return View();
        }
        public IActionResult Transport()
        {
            return View();
        }
    }
}
