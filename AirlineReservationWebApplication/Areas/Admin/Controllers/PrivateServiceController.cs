using AirlineReservationWebApplication.Areas.Admin.Factory;
using AirlineReservationWebApplication.Areas.Admin.Models;
using AirlineReservationWebApplication.Data;
using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PrivateServiceController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IPrivateServiceModelFactory _privateServiceModelFactory;
        public PrivateServiceController(ApplicationDbContext db, IPrivateServiceModelFactory privateServiceModelFactory)
        {
            _db = db;
            _privateServiceModelFactory = privateServiceModelFactory;
        }
        public IActionResult Index()
        {
            if (TempData.ContainsKey("AdminEmail"))
            {
                IEnumerable<PrivateServiceViewModel> objPrivateServiceList = _db.PrivateService;
                Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
                return View(objPrivateServiceList);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult CreatePrivateService()
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            if (TempData.ContainsKey("AdminEmail"))
            {
                var availableAircrafts = _privateServiceModelFactory.PreparePrivateServiceViewModle();

                if (availableAircrafts == null)
                {
                    return View();
                }
                return View(availableAircrafts);
            }
            return RedirectToAction("Index", "Home", new { area = string.Empty });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePrivateService(PrivateServiceViewModel obj)
        {
            var availableAircrafts = _privateServiceModelFactory.PreparePrivateServiceViewModle();
            if (ModelState.IsValid)
            {
                var aircraft = _db.Aircraft.Find(obj.Aircraft_Id);
                obj.Seat_Capacity = aircraft.Seat_Capacity;
                obj.AllAircrafts = availableAircrafts.AllAircrafts;
                bool privatServiceExist = _db.PrivateService.Any(x => x.Departure_Date == obj.Departure_Date && x.Departure_Time == obj.Departure_Time && x.Aircraft_Id == obj.Aircraft_Id || x.Arrival_Date == obj.Arrival_Date && x.Arrival_Time == obj.Arrival_Time && x.Aircraft_Id == obj.Aircraft_Id);
                if (privatServiceExist)
                {
                    ModelState.AddModelError("Aircraft_Id", "Private Service is not available for this aircraft");
                    return View(obj);
                }
                _db.PrivateService.Add(obj);
                _db.SaveChanges();
                ModelState.Clear();
                TempData["success"] = "Private Service successfully Created";
                return RedirectToAction("Index");
            }
            return View(availableAircrafts);
        }

        [HttpGet]
        public IActionResult UpdatePrivateService(int? id)
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            if (TempData.ContainsKey("AdminEmail"))
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }
                var availableAircrafts = _privateServiceModelFactory.PreparePrivateServiceViewModle();
                var privateServiceFormDb = _db.PrivateService.Find(id);
                if (privateServiceFormDb == null)
                {
                    return View();
                }
                privateServiceFormDb.AllAircrafts = availableAircrafts.AllAircrafts;
                return View(privateServiceFormDb);
            }
            return RedirectToAction("Index", "Home", new { area = string.Empty });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePrivateService(PrivateServiceViewModel obj)
        {
            var availableAircrafts = _privateServiceModelFactory.PreparePrivateServiceViewModle();
            obj.AllAircrafts = availableAircrafts.AllAircrafts;
            if (ModelState.IsValid)
            {
                var privateService = _db.PrivateService.Find(obj.PrivateService_Id);
                if (privateService != null)
                {
                    /* bool privatServiceExist = _db.PrivateService.Any(x => x.Departure_Date == obj.Departure_Date && x.Departure_Time == obj.Departure_Time && x.Aircraft_Id == obj.Aircraft_Id || x.Arrival_Date == obj.Arrival_Date && x.Arrival_Time == obj.Arrival_Time && x.Aircraft_Id == obj.Aircraft_Id);
                     if (privatServiceExist)
                     {
                         ModelState.AddModelError("Aircraft_Id", "Private Service is not available for this aircraft");
                         return View(obj);
                     }*/
                    privateService.Departure_Date = obj.Departure_Date;
                    privateService.Departure_Time = obj.Departure_Time;
                    privateService.Departure_Place = obj.Departure_Place;
                    privateService.Arrival_Date = obj.Arrival_Date;
                    privateService.Arrival_Time = obj.Arrival_Time;
                    privateService.ArrivalPlace = obj.ArrivalPlace;
                    privateService.Service_Category = obj.Service_Category;
                    privateService.Seat_Capacity = obj.Seat_Capacity;
                    privateService.Aircraft_Id = obj.Aircraft_Id;
                    privateService.AllAircrafts = obj.AllAircrafts;

                    _db.PrivateService.Update(privateService);
                    _db.SaveChanges();
                    ModelState.Clear();
                    TempData["success"] = "Private Service successfully Updated";
                    return RedirectToAction("Index");
                }
            }
            return View(availableAircrafts);
        }

        [HttpGet]
        public IActionResult DeletePrivateService(int? id)
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            if (TempData.ContainsKey("AdminEmail"))
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }
                var availableAircrafts = _privateServiceModelFactory.PreparePrivateServiceViewModle();
                var privateServiceFormDb = _db.PrivateService.Find(id);
                if (privateServiceFormDb == null)
                {
                    return View();
                }
                privateServiceFormDb.AllAircrafts = availableAircrafts.AllAircrafts;
                return View(privateServiceFormDb);
            }
            return RedirectToAction("Index", "Home", new { area = string.Empty });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePrivateService(int id)
        {
            var privateService = _db.PrivateService.Find(id);
            if (privateService != null)
            {
                _db.PrivateService.Remove(privateService);
                _db.SaveChanges();
                ModelState.Clear();
                TempData["success"] = "Private Service successfully Deleted";
                return RedirectToAction("Index");
            }
            return View(privateService);
        }
    }
}
