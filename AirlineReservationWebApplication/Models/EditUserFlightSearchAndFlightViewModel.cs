using AirlineReservationWebApplication.Areas.Admin.Models;

namespace AirlineReservationWebApplication.Models
{
    public class EditUserFlightSearchAndFlightViewModel
    {
        public UserFlightSearchModel userFlightSearchModel { get; set; }
        public List<List<FlightViewModel>>? Flights { get; set; }
        public List<List<FlightViewModel>>? Hotels { get; set; }
    }
}
