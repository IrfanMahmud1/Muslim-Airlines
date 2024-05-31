using AirlineReservationWebApplication.Areas.Admin.Models;
using AirlineReservationWebApplication.Data;
using AirlineReservationWebApplication.Models;

namespace AirlineReservationWebApplication.Areas.Admin.Factory
{
    public class PrivateServiceModelFactory : IPrivateServiceModelFactory
    {
        public readonly ApplicationDbContext _db;
        public PrivateServiceModelFactory(ApplicationDbContext db)
        {
            _db = db;
        }

        public PrivateServiceViewModel PreparePrivateServiceViewModle()
        {
            var aircrafts = _db.Aircraft.Where(x => x.Availability == true);

            var privateService = new PrivateServiceViewModel();
            privateService.AllAircrafts = new List<(string, int, int)>();

            foreach (var aircraft in aircrafts)
            {
                privateService.AllAircrafts.Add((aircraft.Aircraft_Name, aircraft.Aircraft_Id, aircraft.Seat_Capacity));
            }
            return privateService;
        }

    }
}
