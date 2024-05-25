using AirlineReservationWebApplication.Data;
using AirlineReservationWebApplication.Factory;
using Microsoft.EntityFrameworkCore;

namespace AirlineReservationWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
                ));

            builder.Services.AddScoped<IPassengerModelFactory, PassengerModelFactory>();
            builder.Services.AddScoped<IFlightModelFactory, FlightModelFactory>();
            builder.Services.AddScoped<IOfferModelFactory,OfferModelFactory>();
            builder.Services.AddScoped<IPrivateServiceModelFactory,PrivateServiceModelFactory>();
            builder.Services.AddScoped<IUserFlightSearchModelFactory, UserFlightSearchModelFactory>();

            /*builder.Services.AddDistributedMemoryCache(); // Or other chosen session provider
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20); // Adjust timeout as needed
            });*/

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
