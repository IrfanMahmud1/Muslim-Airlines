using AirlineReservationWebApplication.Areas.Admin.Models;
using AirlineReservationWebApplication.Models;

namespace AirlineReservationWebApplication.Factory
{
    public interface IPassengerModelFactory
    {
        PassengerViewModel PreparePassengerViewModel();
    }
}
