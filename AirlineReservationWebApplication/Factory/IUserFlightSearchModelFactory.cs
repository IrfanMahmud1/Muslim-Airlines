using AirlineReservationWebApplication.Models;
using System.Collections.Generic;

namespace AirlineReservationWebApplication.Factory
{
    public interface IUserFlightSearchModelFactory
    {
        UserFlightSearchModel PreapreUserFlightSearchModel();
        EditUserFlightSearchAndFlightViewModel PrepareUserFlightResults(UserFlightSearchModel obj);
    }
}
