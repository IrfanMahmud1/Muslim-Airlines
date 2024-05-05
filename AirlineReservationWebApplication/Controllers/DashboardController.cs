using AirlineReservationWebApplication.Data;
using AirlineReservationWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace AirlineReservationWebApplication.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DashboardController(ApplicationDbContext db)
        {
            _db = db;
        }
        public static int CountDigits(int number)
        {
            return (int)Math.Floor(Math.Log10(Math.Abs(number))) + 1;
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

        public string getEmail(int id)
        {
            var model = _db.Users.Find(id);
            return model.User_Email;
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

                    _db.Users.Update(user);
                    _db.SaveChanges();
                    ModelState.Clear();
                    TempData["success"] = "User successfully Updated";
                }
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
            bool isValid = _db.Users.Any(x => x.User_Id == obj.User_Id);
            if (isValid)
            {
                _db.Users.Remove(obj);
                _db.SaveChanges();
                ModelState.Clear();
                TempData["success"] = "User successfully Deleted";
                return RedirectToAction("Users");
            }
            return View();
        }
        public IActionResult Passenger()
        {
            if (TempData.ContainsKey("AdminEmail"))
            {
                IEnumerable<PassengerViewModel> objPassengerList = _db.Passenger;
                Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
                return View(objPassengerList);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult CreatePassenger()
        {
            if (TempData.ContainsKey("AdminEmail"))
            {
                return View();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePassenger(PassengerViewModel obj)
        {
            if (obj.registerViewModel == null)
            {
                var registermodel = _db.Users.Find(obj.User_Id);
                registermodel.ConfirmPassword = registermodel.Password;
                obj.registerViewModel = registermodel;
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
                if (checkMobile<10 || checkMobile > 10)
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
                return RedirectToAction("Passenger");
            }
            return View();
        }

        [HttpGet("id")]
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
                _db.Passenger.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Passenger successfully Updated";
                return RedirectToAction("Users");
            }
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
