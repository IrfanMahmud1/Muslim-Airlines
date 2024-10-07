using AirlineReservationWebApplication.Areas.Admin.Models;

namespace AirlineReservationWebApplication.Models
{
    public class EditUserFlightSearchAndFlightViewModel
    {
        public UserFlightSearchModel userFlightSearchModel { get; set; }

        //public List<FlightViewModel>? OneWay {  get; set; }
        public List<List<FlightViewModel>>? Flights { get; set; }
    }
}
