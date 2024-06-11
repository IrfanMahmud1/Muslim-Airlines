using AirlineReservationWebApplication.Areas.Admin.Models;
using AirlineReservationWebApplication.Data;
using AirlineReservationWebApplication.Models;

namespace AirlineReservationWebApplication.Areas.Admin.Factory
{
    public class PassengerModelFactory : IPassengerModelFactory
    {
        private readonly ApplicationDbContext _db;

        public PassengerModelFactory(ApplicationDbContext db)
        {
            _db = db;
        }

        public PassengerViewModel PreparePassengerViewModel()
        {
            var availableUsers = _db.User.Where(us => us.User_Email != "admin@sample.com").ToList();

            var newPassenger = new PassengerViewModel();

            newPassenger.AllUsers = new List<(string, int)>();

            foreach (var user in availableUsers)
            {
                newPassenger.AllUsers.Add((user.User_Name, user.User_Id));
            }

            return newPassenger;
        }
    }
}
