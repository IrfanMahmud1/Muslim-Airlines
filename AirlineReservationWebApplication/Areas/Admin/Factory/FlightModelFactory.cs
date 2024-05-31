using AirlineReservationWebApplication.Areas.Admin.Models;
using AirlineReservationWebApplication.Data;
using AirlineReservationWebApplication.Models;

namespace AirlineReservationWebApplication.Areas.Admin.Factory
{
    public class FlightModelFactory : IFlightModelFactory
    {
        public readonly ApplicationDbContext _db;
        public FlightModelFactory(ApplicationDbContext db)
        {
            _db = db;
        }

        public FlightViewModel PrepareFlightViewModel()
        {
            var aircrafts = _db.Aircraft.Where(x => x.Availability == true);

            var flight = new FlightViewModel();
            flight.AllAircrafts = new List<(string, int, int)>();

            foreach (var aircraft in aircrafts)
            {
                flight.AllAircrafts.Add((aircraft.Aircraft_Name, aircraft.Aircraft_Id, aircraft.Seat_Capacity));
            }
            return flight;
        }


    }
}
