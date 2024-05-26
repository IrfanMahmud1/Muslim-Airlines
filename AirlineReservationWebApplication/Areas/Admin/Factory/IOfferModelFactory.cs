using AirlineReservationWebApplication.Areas.Admin.Models;

namespace AirlineReservationWebApplication.Areas.Admin.Factory
{
    public interface IOfferModelFactory
    {
        OfferViewModel PrepareOfferViewModel();
    }
}
