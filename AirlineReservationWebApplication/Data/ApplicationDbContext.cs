using AirlineReservationWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace AirlineReservationWebApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserViewModel>()
                .HasData(new UserViewModel() 
                { 
                    User_Id = 1, 
                    User_Email = "admin@sample.com", 
                    User_Name = "Admin", 
                    Password = "123", 
                    ConfirmPassword = "123"
                });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserViewModel> Users { get; set; }
        public DbSet<PassengerViewModel> Passengers { get; set; }
    }
}
