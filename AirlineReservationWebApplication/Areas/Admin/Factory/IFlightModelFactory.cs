using AirlineReservationWebApplication.Areas.Admin.Models;
using AirlineReservationWebApplication.Models;

namespace AirlineReservationWebApplication.Areas.Admin.Factory
{
    public interface IFlightModelFactory
    {
        FlightViewModel PrepareFlightViewModel();
    }
}
