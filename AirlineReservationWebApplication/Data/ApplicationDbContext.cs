using AirlineReservationWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace AirlineReservationWebApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
    
        }
        public DbSet<RegisterViewModel> User { get; set; }
        public DbSet<PassengerViewModel> Passenger { get; set; }
        public DbSet<ReservationViewModel> Reservation { get; set; }
        public DbSet<FlightViewModel> Flight { get; set; }
        public DbSet<OfferViewModel> Offer { get; set; }
        public DbSet<HotelViewModel> Hotel { get; set; }
        public DbSet<AircraftViewModel> Aircraft { get; set; }
        public DbSet<FeedbackViewModel> Feedback { get; set; }
        public DbSet<PaymentViewModel> Payment { get; set; }
        public DbSet<PrivateServiceViewModel> PrivateService { get; set; }
        public DbSet<TransportViewModel> Transport { get; set; }
    }
}
