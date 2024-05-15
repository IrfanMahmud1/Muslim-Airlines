using AirlineReservationWebApplication.Data;
using AirlineReservationWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationWebApplication.Controllers
{
    public class FlightController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FlightController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            if (TempData.ContainsKey("AdminEmail"))
            {
                IEnumerable<FlightViewModel> objFlightList = _db.Flight;
                Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
                return View(objFlightList);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult CreateFlight()
        {
            if (TempData.ContainsKey("AdminEmail"))
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateFlight(FlightViewModel obj)
        {
            if (ModelState.IsValid)
            {
                bool FlightExist = _db.Flight.Any(x => x.Flight_Name == obj.Flight_Name);
                if (FlightExist)
                {
                    ModelState.AddModelError("Flight", "Flight is already available");
                    return View();
                }
                _db.Flight.Add(obj);
                _db.SaveChanges();
                ModelState.Clear();
                TempData["success"] = "Flight successfully Created";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateFlight(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var flightFromDb = _db.Flight.Find(id);
            if (flightFromDb == null)
            {
                return NotFound();
            }
            return View(flightFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateFlight(FlightViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var flight = _db.Flight.Find(obj.Flight_Id);
                if (flight != null)
                {
                    if (obj.Flight_Name != flight.Flight_Name)
                    {
                        bool duplicate = _db.Flight.Any(x => x.Flight_Name == obj.Flight_Name);
                        if (duplicate)
                        {
                            ModelState.AddModelError("flight", "Flight is already availabe");
                            return View();
                        }

                        flight.Flight_Name = obj.Flight_Name;
                    }
                    flight.Departure_Date = obj.Departure_Date;
                    flight.Arrival_Date = obj.Arrival_Date;
                    flight.Departure_Time = obj.Departure_Time;
                    flight.Arrival_Time = obj.Arrival_Time;
                    flight.Departure_Place = obj.Departure_Place;
                    flight.Arrival_Place = obj.Departure_Place;
                    flight.Total_Seats = obj.Total_Seats;
                    flight.Available_Seats = obj.Available_Seats;
                    flight.Aircraft_Model = obj.Aircraft_Model;
                    flight.Flight_Status = obj.Flight_Status;
                    flight.Flight_Type = obj.Flight_Type;
                    flight.Business  = obj.Business;
                    flight.Economy = obj.Economy;
                    flight.FirstClass = obj.FirstClass;
                    _db.Flight.Update(flight);
                    _db.SaveChanges();
                    ModelState.Clear();
                    TempData["success"] = "Flight successfully Updated";
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult DeleteFlight(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var flightFromDb = _db.Flight.Find(id);
            if (flightFromDb == null)
            {
                return NotFound();
            }
            return View(flightFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteFlight(FlightViewModel obj)
        {
            bool isValid = _db.Flight.Any(x => x.Flight_Id == obj.Flight_Id);
            if (isValid)
            {
                _db.Flight.Remove(obj);
                _db.SaveChanges();
                ModelState.Clear();
                TempData["success"] = "Flight successfully Deleted";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
