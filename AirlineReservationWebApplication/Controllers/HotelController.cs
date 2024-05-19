using AirlineReservationWebApplication.Data;
using AirlineReservationWebApplication.Factory;
using AirlineReservationWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationWebApplication.Controllers
{
    public class HotelController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HotelController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            if (TempData.ContainsKey("AdminEmail"))
            {
                IEnumerable<HotelViewModel> objHotelList = _db.Hotel;
                Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
                return View(objHotelList);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult CreateHotel()
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            if (TempData.ContainsKey("AdminEmail"))
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateHotel(HotelViewModel obj)
        {
            if (ModelState.IsValid)
            {
                bool HotelExist = _db.Hotel.Any(x => x.Hotel_Name == obj.Hotel_Name && x.Hotel_Location == obj.Hotel_Location && x.Room_Category == obj.Room_Category);
                if (HotelExist)
                {
                    ModelState.AddModelError("Hotel", "Hotel is already available");
                    return View(obj);
                }
                _db.Hotel.Add(obj);
                _db.SaveChanges();
                ModelState.Clear();
                TempData["success"] = "Flight successfully Created";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult UpdateHotel(int? id)
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var hotelFromDb = _db.Hotel.Find(id);
            if (hotelFromDb == null)
            {
                return View();
            }
            return View(hotelFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateHotel(HotelViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var hotel = _db.Hotel.Find(obj.Hotel_Id);
                if (hotel != null)
                {
                    bool HotelExist = _db.Hotel.Any(x => x.Hotel_Name == obj.Hotel_Name && x.Hotel_Location == obj.Hotel_Location && x.Room_Category == obj.Room_Category);
                    if (HotelExist)
                    {
                        ModelState.AddModelError("Room_Category", "Room is already available");
                        return View(obj);
                    }
                    hotel.Hotel_Name = obj.Hotel_Name;
                    hotel.Total_Rooms = obj.Total_Rooms;
                    hotel.Room_Category = obj.Room_Category;
                    hotel.Checkin_Date = obj.Checkin_Date;
                    hotel.Checkin_Time = obj.Checkin_Time;
                    hotel.Checkout_Date = obj.Checkout_Date;
                    hotel.Checkout_Time = obj.Checkout_Time;
                    hotel.Country = obj.Country;

                    _db.Hotel.Update(hotel);
                    _db.SaveChanges();
                    ModelState.Clear();
                    TempData["success"] = "Hotel successfully Updated";
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult DeleteHotel(int? id)
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var hotelFromDb = _db.Hotel.Find(id);
            if (hotelFromDb == null)
            {
                return View();
            }
            return View(hotelFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteHotel(int id)
        {
            var hotel = _db.Hotel.Find(id);
            if (hotel != null)
            {
                _db.Hotel.Remove(hotel);
                _db.SaveChanges();
                ModelState.Clear();
                TempData["success"] = "Flight successfully Deleted";
                return RedirectToAction("Index");
            }
            return View(hotel);
        }
    }
}
