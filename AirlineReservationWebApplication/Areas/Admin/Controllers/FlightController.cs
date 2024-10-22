using AirlineReservationWebApplication.Areas.Admin.Factory;
using AirlineReservationWebApplication.Areas.Admin.Models;
using AirlineReservationWebApplication.Data;
using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FlightController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IFlightModelFactory _flightModelFactory;
        public FlightController(ApplicationDbContext db, IFlightModelFactory flightModelFactory)
        {
            _db = db;
            _flightModelFactory = flightModelFactory;
        }
        public IActionResult Index()
        {
            if (TempData.ContainsKey("AdminEmail"))
            {
                IEnumerable<FlightViewModel> objFlightList = _db.Flight;
                Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
                return View(objFlightList);
            }
            return RedirectToAction("Index", "Home", new { area = string.Empty });
        }

        [HttpGet]
        public IActionResult CreateFlight()
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
            return RedirectToAction("Index", "Home", new { area = string.Empty });
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
                int seatPerClass = obj.Total_Seats;
                obj.Business = seatPerClass * 20/100;
                obj.FirstClass = seatPerClass * 10/100;
                obj.Economy = seatPerClass - (obj.Business + obj.FirstClass);

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
            if (TempData.ContainsKey("AdminEmail"))
            {
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
            return RedirectToAction("Index", "Home", new { area = string.Empty });
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
                    flight.Arrival_Place = obj.Arrival_Place;
                    flight.Aircraft_Id = obj.Aircraft_Id;
                    flight.E_Price = obj.E_Price;
                    flight.B_Price = obj.B_Price;
                    flight.FC_Price = obj.FC_Price;
                    var aircraft = _db.Aircraft.Find(obj.Aircraft_Id);
                    obj.Total_Seats = aircraft.Seat_Capacity;
                    int seatPerClass = obj.Total_Seats;
                    obj.Business = seatPerClass * 20 / 100;
                    obj.FirstClass = seatPerClass * 10 / 100;
                    obj.Economy = seatPerClass - (obj.Business + obj.FirstClass);
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
            if (TempData.ContainsKey("AdminEmail"))
            {
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
            return RedirectToAction("Index", "Home", new { area = string.Empty });
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
