using AirlineReservationWebApplication.Data;
using AirlineReservationWebApplication.Factory;
using AirlineReservationWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationWebApplication.Controllers
{
    public class OfferController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IOfferModelFactory _offerModelFactory;
        public OfferController(ApplicationDbContext db,IOfferModelFactory offerModelFactory)
        {
            _db = db;
            _offerModelFactory = offerModelFactory;
        }
        public IActionResult Index()
        {
            if (TempData.ContainsKey("AdminEmail"))
            {
                IEnumerable<OfferViewModel> objOfferList = _db.Offer;
                Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
                return View(objOfferList);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult CreateOffer()
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            if (TempData.ContainsKey("AdminEmail"))
            {
                var allFlightHotelOffers = _offerModelFactory.PrepareOfferViewModel();
                return View(allFlightHotelOffers);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateOffer(OfferViewModel obj)
        {
            var allFlightHotelOffers = _offerModelFactory.PrepareOfferViewModel();
            
            if (ModelState.IsValid)
            {
                obj.AllHotels = allFlightHotelOffers.AllHotels;
                obj.AllFlights = allFlightHotelOffers.AllFlights;

                bool OfferExist = _db.Offer.Any(x => x.Start_Date == obj.Start_Date&& x.End_Date== obj.End_Date && x.Validity== obj.Validity && x.Offer_Range == obj.Offer_Range);
                if (OfferExist)
                {
                    ModelState.AddModelError("", "Offer is already available");
                    return View(obj);
                }
                _db.Offer.Add(obj);
                _db.SaveChanges();
                ModelState.Clear();
                TempData["success"] = "Offer successfully Created";
                return RedirectToAction("Index");
            }
            return View(allFlightHotelOffers);
        }

        [HttpGet]
        public IActionResult UpdateOffer(int? id)
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            if (TempData.ContainsKey("AdminEmail"))
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }
                var allFlightHotelOffers = _offerModelFactory.PrepareOfferViewModel();
                var offerFromDb = _db.Offer.Find(id);
                if (offerFromDb == null)
                {
                    return View(allFlightHotelOffers);
                }
                offerFromDb.AllFlights = allFlightHotelOffers.AllFlights;
                offerFromDb.AllHotels = allFlightHotelOffers.AllHotels;
                return View(offerFromDb);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateOffer(OfferViewModel obj)
        {
            var allFlightHotelOffers = _offerModelFactory.PrepareOfferViewModel();
            obj.AllHotels = allFlightHotelOffers.AllHotels;
            obj.AllFlights = allFlightHotelOffers.AllFlights;
            if (ModelState.IsValid)
            {
                var offer = _db.Offer.Find(obj.Offer_Id);
                if (offer != null)
                {
                    bool OfferExist = _db.Offer.Any(x => x.Start_Date == obj.Start_Date && x.End_Date == obj.End_Date && x.Validity == obj.Validity && x.Offer_Range == obj.Offer_Range);
                    if (OfferExist)
                    {
                        ModelState.AddModelError("", "Offer is already available");
                        return View(obj);
                    }
                    offer.Start_Date = obj.Start_Date;
                    offer.Start_Time = obj.Start_Time;
                    offer.End_Date = obj.End_Date;
                    offer.End_Time = obj.End_Time;
                    offer.Validity = obj.Validity;
                    offer.Flight_Id = obj.Flight_Id;
                    offer.Hotel_Id = obj.Hotel_Id;

                    _db.Offer.Update(offer);
                    _db.SaveChanges();
                    ModelState.Clear();
                    TempData["success"] = "Offer successfully Updated";
                    return RedirectToAction("Index");
                }
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult DeleteOffer(int? id)
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            if (TempData.ContainsKey("AdminEmail"))
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }
                var allFlightHotelOffers = _offerModelFactory.PrepareOfferViewModel();
                var offerFromDb = _db.Offer.Find(id);
                if (offerFromDb == null)
                {
                    return View(allFlightHotelOffers);
                }
                offerFromDb.AllFlights = allFlightHotelOffers.AllFlights;
                offerFromDb.AllHotels = allFlightHotelOffers.AllHotels;
                return View(offerFromDb);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteOffer(int id)
        {
            var offer = _db.Offer.Find(id);
            if (offer != null)
            {
                _db.Offer.Remove(offer);
                _db.SaveChanges();
                ModelState.Clear();
                TempData["success"] = "Offer successfully Deleted";
                return RedirectToAction("Index");
            }
            return View(offer);
        }
    }
}
