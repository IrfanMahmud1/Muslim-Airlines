using AirlineReservationWebApplication.Models;

namespace AirlineReservationWebApplication.Factory
{
    public interface IOfferModelFactory
    {
        OfferViewModel PrepareOfferViewModel();
    }
}
