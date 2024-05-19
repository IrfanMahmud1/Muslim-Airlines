using AirlineReservationWebApplication.Data;
using AirlineReservationWebApplication.Models;

namespace AirlineReservationWebApplication.Factory
{
    public class OfferModelFactory : IOfferModelFactory
    {
        private readonly ApplicationDbContext _db;
        public OfferModelFactory(ApplicationDbContext db)
        {
            _db = db;
        }

        public OfferViewModel PrepareOfferViewModel()
        {
            var allFlights = _db.Flight.Where(x => x.Flight_Type == "Public" && x.Flight_Status == "Scheduled");
            var allHotels = _db.Hotel.Where(x => x.Booked_Rooms < x.Total_Rooms);
            var offers = new OfferViewModel();
            offers.AllFlights = new List<(string, int)>();
            offers.AllHotels = new List<(string, int)>();

            foreach(var flight in allFlights)
            {
                offers.AllFlights.Add((flight.Flight_Name, flight.Flight_Id));
            }
            foreach(var hotel in allHotels)
            {
                offers.AllHotels.Add((hotel.Hotel_Name, hotel.Hotel_Id));
            }

            return offers;
        }
    }
}
