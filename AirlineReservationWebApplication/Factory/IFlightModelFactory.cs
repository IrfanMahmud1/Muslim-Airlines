using AirlineReservationWebApplication.Models;

namespace AirlineReservationWebApplication.Factory
{
    public interface IFlightModelFactory 
    {
        FlightViewModel PrepareFlightViewModel();
    }
}
