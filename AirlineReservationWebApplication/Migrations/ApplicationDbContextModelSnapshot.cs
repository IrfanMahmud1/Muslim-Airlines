﻿// <auto-generated />
using System;
using AirlineReservationWebApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AirlineReservationWebApplication.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AirlineReservationWebApplication.Models.AircraftViewModel", b =>
                {
                    b.Property<int>("Aircraft_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Aircraft_Id"));

                    b.Property<string>("Aircraft_Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Aircraft_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Aircraft_Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Availability")
                        .HasColumnType("bit");

                    b.Property<int>("Seat_Capacity")
                        .HasColumnType("int");

                    b.HasKey("Aircraft_Id");

                    b.ToTable("Aircraft");
                });

            modelBuilder.Entity("AirlineReservationWebApplication.Models.FeedbackViewModel", b =>
                {
                    b.Property<int>("Feedback_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Feedback_Id"));

                    b.Property<string>("Passenger_Feedback")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Passenger_Id")
                        .HasColumnType("int");

                    b.HasKey("Feedback_Id");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("AirlineReservationWebApplication.Models.FlightViewModel", b =>
                {
                    b.Property<int>("Flight_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Flight_Id"));

                    b.Property<int>("Aircraft_Id")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Arrival_Date")
                        .HasColumnType("date");

                    b.Property<string>("Arrival_Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeOnly>("Arrival_Time")
                        .HasColumnType("time");

                    b.Property<int>("Booked_Seats")
                        .HasColumnType("int");

                    b.Property<int>("Business")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Departure_Date")
                        .HasColumnType("date");

                    b.Property<string>("Departure_Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeOnly>("Departure_Time")
                        .HasColumnType("time");

                    b.Property<int>("Economy")
                        .HasColumnType("int");

                    b.Property<int>("FirstClass")
                        .HasColumnType("int");

                    b.Property<string>("Flight_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Flight_Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Flight_Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Total_Seats")
                        .HasColumnType("int");

                    b.HasKey("Flight_Id");

                    b.ToTable("Flight");
                });

            modelBuilder.Entity("AirlineReservationWebApplication.Models.HotelViewModel", b =>
                {
                    b.Property<int>("Hotel_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Hotel_Id"));

                    b.Property<int>("Booked_Rooms")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Checkin_Date")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("Checkin_Time")
                        .HasColumnType("time");

                    b.Property<DateOnly>("Checkout_Date")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("Checkout_Time")
                        .HasColumnType("time");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hotel_Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hotel_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Room_Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Total_Rooms")
                        .HasColumnType("int");

                    b.HasKey("Hotel_Id");

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("AirlineReservationWebApplication.Models.OfferViewModel", b =>
                {
                    b.Property<int>("Offer_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Offer_Id"));

                    b.Property<DateOnly>("End_Date")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("End_Time")
                        .HasColumnType("time");

                    b.Property<int>("Flight_Id")
                        .HasColumnType("int");

                    b.Property<int>("Hotel_Id")
                        .HasColumnType("int");

                    b.Property<int>("Offer_Range")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Start_Date")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("Start_Time")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("Validity")
                        .HasColumnType("time");

                    b.HasKey("Offer_Id");

                    b.ToTable("Offer");
                });

            modelBuilder.Entity("AirlineReservationWebApplication.Models.PassengerViewModel", b =>
                {
                    b.Property<int>("Passenger_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Passenger_ID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("First_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Is_Approved")
                        .HasColumnType("bit");

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Passport")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Passenger_ID");

                    b.ToTable("Passenger");
                });

            modelBuilder.Entity("AirlineReservationWebApplication.Models.PaymentViewModel", b =>
                {
                    b.Property<int>("Payment_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Payment_Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("Payment_Date")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("Payment_Time")
                        .HasColumnType("time");

                    b.Property<int>("Reservation_Id")
                        .HasColumnType("int");

                    b.HasKey("Payment_Id");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("AirlineReservationWebApplication.Models.PrivateServiceViewModel", b =>
                {
                    b.Property<int>("PrivateService_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrivateService_Id"));

                    b.Property<int>("Aircraft_Id")
                        .HasColumnType("int");

                    b.Property<string>("ArrivalPlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("Arrival_Date")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("Arrival_Time")
                        .HasColumnType("time");

                    b.Property<DateOnly>("Departure_Date")
                        .HasColumnType("date");

                    b.Property<string>("Departure_Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeOnly>("Departure_Time")
                        .HasColumnType("time");

                    b.Property<int>("Seat_Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Service_Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PrivateService_Id");

                    b.ToTable("PrivateService");
                });

            modelBuilder.Entity("AirlineReservationWebApplication.Models.ReservationViewModel", b =>
                {
                    b.Property<int>("Reservation_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Reservation_Id"));

                    b.Property<TimeOnly>("Checkin_Time")
                        .HasColumnType("time");

                    b.Property<DateOnly>("Flight_Booking_Date")
                        .HasColumnType("date");

                    b.Property<int>("Flight_No")
                        .HasColumnType("int");

                    b.Property<int>("Hotel_Id")
                        .HasColumnType("int");

                    b.Property<int>("Passenger_Id")
                        .HasColumnType("int");

                    b.Property<string>("Passenger_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Payment_Id")
                        .HasColumnType("int");

                    b.Property<int>("PrivateService_Id")
                        .HasColumnType("int");

                    b.Property<int>("Transport_Id")
                        .HasColumnType("int");

                    b.HasKey("Reservation_Id");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("AirlineReservationWebApplication.Models.TransportViewModel", b =>
                {
                    b.Property<int>("Transport_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Transport_Id"));

                    b.Property<string>("Arrival_Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Booked_Seats")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("PickUp_Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeOnly>("PickUp_Time")
                        .HasColumnType("time");

                    b.Property<int>("Total_Seats")
                        .HasColumnType("int");

                    b.Property<string>("Transport_Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Transport_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Transport_Id");

                    b.ToTable("Transport");
                });

            modelBuilder.Entity("AirlineReservationWebApplication.Models.UserViewModel", b =>
                {
                    b.Property<int>("User_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("User_Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            User_Id = 1,
                            Password = "123",
                            User_Email = "admin@sample.com",
                            User_Name = "Admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
