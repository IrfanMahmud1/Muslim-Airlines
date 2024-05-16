/*using AirlineReservationWebApplication.Data;
using AirlineReservationWebApplication.Factory;
using AirlineReservationWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationWebApplication.Controllers
{
    public class PrivateServiceController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PrivateServiceController(ApplicationDbContext db, IFlightModelFactory flightModelFactory)
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
        public IActionResult CreatePrivateService()
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            if (TempData.ContainsKey("AdminEmail"))
            {
                var availableAircrafts = _flightModelFactory.PrepareFlightViewModel();
                if (availableAircrafts == null)
                {
                    return View();
                }
                return View(availableAircrafts);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateFlight(FlightViewModel obj)
        {
            var availableAircrafts = _flightModelFactory.PrepareFlightViewModel();
            if (ModelState.IsValid)
            {
                obj.AllAircrafts = availableAircrafts.AllAircrafts;
                var aircraft = _db.Aircraft.Find(obj.Aircraft_Id);
                obj.Total_Seats = aircraft.Seat_Capacity;
                obj.Available_Seats = obj.Total_Seats;
                int seatPerClass = obj.Total_Seats / 3;
                obj.Business = seatPerClass;
                obj.FirstClass = seatPerClass;
                obj.Economy = seatPerClass + obj.Total_Seats % 3;

                bool FlightExist = _db.Flight.Any(x => x.Flight_Name == obj.Flight_Name);
                if (FlightExist)
                {
                    ModelState.AddModelError("Flight", "Flight is already available");
                    return View(obj);
                }
                _db.Flight.Add(obj);
                _db.SaveChanges();
                ModelState.Clear();
                TempData["success"] = "Flight successfully Created";
                return RedirectToAction("Index");
            }
            return View(availableAircrafts);
        }

        [HttpGet]
        public IActionResult UpdateFlight(int? id)
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var availableAircrafts = _flightModelFactory.PrepareFlightViewModel();
            FlightViewModel flightFromDb = _db.Flight.Find(id);
            if (flightFromDb == null)
            {
                return View();
            }
            flightFromDb.AllAircrafts = availableAircrafts.AllAircrafts;
            return View(flightFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateFlight(FlightViewModel obj)
        {
            var availableAircrafts = _flightModelFactory.PrepareFlightViewModel();
            obj.AllAircrafts = availableAircrafts.AllAircrafts;
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
                    flight.Aircraft_Id = obj.Aircraft_Id;
                    flight.Flight_Status = obj.Flight_Status;
                    flight.Flight_Type = obj.Flight_Type;
                    flight.AllAircrafts = obj.AllAircrafts;
                    _db.Flight.Update(flight);
                    _db.SaveChanges();
                    ModelState.Clear();
                    TempData["success"] = "Flight successfully Updated";
                    return RedirectToAction("Index");
                }
            }
            return View(availableAircrafts);
        }

        [HttpGet]
        public IActionResult DeleteFlight(int? id)
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var availableAircrafts = _flightModelFactory.PrepareFlightViewModel();
            var flightFromDb = _db.Flight.Find(id);
            if (flightFromDb == null)
            {
                return View();
            }
            flightFromDb.AllAircrafts = availableAircrafts.AllAircrafts;
            return View(flightFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteFlight(int id)
        {
            var flight = _db.Flight.Find(id);
            if (flight != null)
            {
                _db.Flight.Remove(flight);
                _db.SaveChanges();
                ModelState.Clear();
                TempData["success"] = "Flight successfully Deleted";
                return RedirectToAction("Index");
            }
            return View(flight);
        }
    }
}
*/