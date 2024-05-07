using AirlineReservationWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace AirlineReservationWebApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<RegisterViewModel> Users { get; set; }
        public DbSet<PassengerViewModel> Passenger { get; set; }
    }
}
