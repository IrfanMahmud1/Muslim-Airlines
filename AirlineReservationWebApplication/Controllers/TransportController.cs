using AirlineReservationWebApplication.Data;
using AirlineReservationWebApplication.Factory;
using AirlineReservationWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationWebApplication.Controllers
{
    public class TransportController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TransportController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            if (TempData.ContainsKey("AdminEmail"))
            {
                IEnumerable<TransportViewModel> objTransportList = _db.Transport;
                Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
                return View(objTransportList);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult CreateTransport()
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
        public IActionResult CreateTransport(TransportViewModel obj)
        {
            if (ModelState.IsValid)
            {
                bool TransportExist = _db.Transport.Any(x => x.Transport_Name == obj.Transport_Name);
                if (TransportExist)
                {
                    ModelState.AddModelError("Transport_Name", "Transport is already available");
                    return View(obj);
                }
                _db.Transport.Add(obj);
                _db.SaveChanges();
                ModelState.Clear();
                TempData["success"] = "Transport successfully Created";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateTransport(int? id)
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var transFromDB= _db.Transport.Find(id);
            if (transFromDB == null)
            {
                return View();
            }
            return View(transFromDB);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateTransport(TransportViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var transport = _db.Transport.Find(obj.Transport_Id);
                if (transport != null)
                {
                    if (obj.Transport_Name != transport.Transport_Name)
                    {
                        bool TransportExist = _db.Transport.Any(x => x.Transport_Name == obj.Transport_Name);
                        if (TransportExist)
                        {
                            ModelState.AddModelError("Transport_Name", "Transport is already available");
                            return View(obj);
                        }

                        transport.Transport_Name = obj.Transport_Name;
                    }
                    transport.Transport_Category = obj.Transport_Category;
                    transport.Total_Seats = obj.Total_Seats;
                    transport.Date = obj.Date;
                    transport.PickUp_Place = obj.PickUp_Place;
                    transport.PickUp_Time = obj.PickUp_Time;
                    _db.Transport.Update(transport);
                    _db.SaveChanges();
                    ModelState.Clear();
                    TempData["success"] = "Transport successfully Updated";
                    return RedirectToAction("Index");
                }
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult DeleteTransport(int? id)
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var transFromDB = _db.Transport.Find(id);
            if (transFromDB == null)
            {
                return View();
            }
            return View(transFromDB);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteTransport(int id)
        {
            var transport = _db.Transport.Find(id);
            if (transport != null)
            {
                _db.Transport.Remove(transport);
                _db.SaveChanges();
                ModelState.Clear();
                TempData["success"] = "Transport successfully Deleted";
                return RedirectToAction("Index");
            }
            return View(transport);
        }
    }
}
