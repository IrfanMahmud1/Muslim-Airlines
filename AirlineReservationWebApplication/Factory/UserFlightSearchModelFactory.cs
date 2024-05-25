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
            var destinations = _db.Flight.Select(x =>x.Arrival_Place);

            var flights = new UserFlightSearchModel();
            flights.AllOrigins = new List<string>();
            flights.AllDestinations = new List<string>();


            foreach(var origin in origins)
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
            var flights = _db.Flight.Where(x => x.Departure_Place == obj.Origin && x.Arrival_Place == obj.Destination && x.Departure_Date == obj.Departure).ToList();
            
            var flightResults = new EditUserFlightSearchAndFlightViewModel();
            flightResults.flightViewModel =flights;

            var allflights = PreapreUserFlightSearchModel();
            var userFlightSearchModel = new UserFlightSearchModel();
            userFlightSearchModel.AllOrigins = allflights.AllOrigins;
            userFlightSearchModel.AllDestinations = allflights.AllDestinations;
            userFlightSearchModel.Departure = obj.Departure;
            userFlightSearchModel.Origin = obj.Origin;
            userFlightSearchModel.Destination = obj.Destination;
            flightResults.userFlightSearchModel = userFlightSearchModel;
            
            return flightResults;
        }
    }
}
