using AirlineReservationWebApplication.Areas.Admin.Models;
using AirlineReservationWebApplication.Data;
using AirlineReservationWebApplication.Models;

namespace AirlineReservationWebApplication.Factory
{
    public class UserFlightSearchModelFactory : IUserFlightSearchModelFactory
    {
        private readonly ApplicationDbContext _db;
        public UserFlightSearchModelFactory(ApplicationDbContext db)
        {
            _db = db;
        }

        public UserFlightSearchModel PreapreUserFlightSearchModel()
        {
            var origins = _db.Flight.Select(x => x.Departure_Place);
            var destinations = _db.Flight.Select(x => x.Arrival_Place);

            var flights = new UserFlightSearchModel();
            flights.AllOrigins = new List<string>();
            flights.AllDestinations = new List<string>();


            foreach (var origin in origins)
            {
                flights.AllOrigins.Add(origin);
            }

            foreach (var destination in destinations)
            {
                flights.AllDestinations.Add(destination);
            }

            return flights;
        }

        public EditUserFlightSearchAndFlightViewModel PrepareUserFlightResults(UserFlightSearchModel obj)
        {
            var flights = _db.Flight.Where(
      x => x.Departure_Place == obj.Origin &&
           x.Arrival_Place == obj.Destination &&
           x.Departure_Date == obj.Departure &&
           (obj.BookingClass == "Economy" ? x.Economy >= obj.Travelers :
            (obj.BookingClass == "Business" ? x.Business >= obj.Travelers :
             (obj.BookingClass == "FirstClass" ? x.FirstClass >= obj.Travelers : false)))
                                        ).ToList();

            var flightResults = new EditUserFlightSearchAndFlightViewModel();
            flightResults.Flights = new List<List<FlightViewModel>> { flights };

            if (obj.Way == "roundtrip")
            {
                var flights2 = _db.Flight.Where(
               x => x.Departure_Place == obj.Destination &&
              x.Arrival_Place == obj.Origin &&
              x.Departure_Date == obj.Return &&
              (obj.BookingClass == "Economy" ? x.Economy >= obj.Travelers :
               (obj.BookingClass == "Business" ? x.Business >= obj.Travelers :
                (obj.BookingClass == "FirstClass" ? x.FirstClass >= obj.Travelers : false)))
                                           ).ToList();

                flightResults.Flights.Add(flights2 );
            }

            flightResults.userFlightSearchModel = PreapreUserFlightSearchModel();
            flightResults.userFlightSearchModel.Return = obj.Return;
            flightResults.userFlightSearchModel.Way = obj.Way;
            flightResults.userFlightSearchModel.Departure = obj.Departure;

            return flightResults;
        }
    }
}
