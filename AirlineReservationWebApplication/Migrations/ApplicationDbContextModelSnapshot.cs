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
                    b.Property<int>("Aircraft_Model")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Aircraft_Model"));

                    b.Property<string>("Aircraft_Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Aircraft_Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Seat_Capacity")
                        .HasColumnType("int");

                    b.HasKey("Aircraft_Model");

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

                    b.HasIndex("Passenger_Id");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("AirlineReservationWebApplication.Models.FlightViewModel", b =>
                {
                    b.Property<int>("Flight_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Flight_Id"));

                    b.Property<string>("Aircraft_Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("Arrival_Date")
                        .HasColumnType("date");

                    b.Property<string>("Arrival_Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeOnly>("Arrival_Time")
                        .HasColumnType("time");

                    b.Property<int>("Available_Seats")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Departure_Date")
                        .HasColumnType("date");

                    b.Property<string>("Departure_Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeOnly>("Departure_Time")
                        .HasColumnType("time");

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

                    b.Property<int>("Available_Rooms")
                        .HasColumnType("int");

                    b.Property<DateTime>("Hotel_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Hotel_Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hotel_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Room_Availability")
                        .HasColumnType("bit");

                    b.Property<int>("Room_Booked")
                        .HasColumnType("int");

                    b.Property<string>("Room_Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Hotel_Id");

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("AirlineReservationWebApplication.Models.OfferViewModel", b =>
                {
                    b.Property<int>("Offer_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Offer_Id"));

                    b.Property<int>("Flight_Id")
                        .HasColumnType("int");

                    b.Property<int>("Hotel_Id")
                        .HasColumnType("int");

                    b.Property<string>("Offer_For")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Offer_Range")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start_Date")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("Validity")
                        .HasColumnType("time");

                    b.HasKey("Offer_Id");

                    b.HasIndex("Flight_Id");

                    b.HasIndex("Hotel_Id");

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

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Mobile")
                        .HasColumnType("int");

                    b.Property<int>("Nid")
                        .HasColumnType("int");

                    b.Property<string>("Passport")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Passenger_ID");

                    b.HasIndex("User_Id");

                    b.ToTable("Passengers");
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

                    b.Property<DateTime>("Payment_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Payment_For")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Payment_Id");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("AirlineReservationWebApplication.Models.PrivateServiceViewModel", b =>
                {
                    b.Property<int>("PrivateS_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrivateS_Id"));

                    b.Property<int>("Aircraft_Model")
                        .HasColumnType("int");

                    b.Property<string>("ArrivalPlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Arrival_Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Arrival_Time")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Departure_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Departure_Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Departure_Time")
                        .HasColumnType("datetime2");

                    b.Property<string>("Service_Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PrivateS_Id");

                    b.HasIndex("Aircraft_Model");

                    b.ToTable("PrivateService");
                });

            modelBuilder.Entity("AirlineReservationWebApplication.Models.ReservationViewModel", b =>
                {
                    b.Property<int>("Reservation_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Reservation_Id"));

                    b.Property<DateTime>("Flight_Booking_Date")
                        .HasColumnType("datetime2");

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

                    b.HasIndex("Flight_No");

                    b.HasIndex("Hotel_Id");

                    b.HasIndex("Passenger_Id");

                    b.HasIndex("Payment_Id");

                    b.HasIndex("PrivateService_Id");

                    b.HasIndex("Transport_Id");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("AirlineReservationWebApplication.Models.TransportViewModel", b =>
                {
                    b.Property<int>("Transport_Model")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Transport_Model"));

                    b.Property<int>("Available_Seats")
                        .HasColumnType("int");

                    b.Property<string>("PickUp_Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PickUp_Time")
                        .HasColumnType("datetime2");

                    b.Property<int>("Seat_Booked")
                        .HasColumnType("int");

                    b.Property<int>("Total_Seats")
                        .HasColumnType("int");

                    b.Property<string>("Transport_Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Transport_Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Transport_Model");

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

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            User_Id = 1,
                            Password = "123",
                            User_Email = "admin@sample.com",
                            User_Name = "Admin"
                        });
                });

            modelBuilder.Entity("AirlineReservationWebApplication.Models.FeedbackViewModel", b =>
                {
                    b.HasOne("AirlineReservationWebApplication.Models.PassengerViewModel", "passengerViewModel")
                        .WithMany()
                        .HasForeignKey("Passenger_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("passengerViewModel");
                });

            modelBuilder.Entity("AirlineReservationWebApplication.Models.OfferViewModel", b =>
                {
                    b.HasOne("AirlineReservationWebApplication.Models.FlightViewModel", "flightViewModel")
                        .WithMany()
                        .HasForeignKey("Flight_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirlineReservationWebApplication.Models.HotelViewModel", "hotelViewModel")
                        .WithMany()
                        .HasForeignKey("Hotel_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("flightViewModel");

                    b.Navigation("hotelViewModel");
                });

            modelBuilder.Entity("AirlineReservationWebApplication.Models.PassengerViewModel", b =>
                {
                    b.HasOne("AirlineReservationWebApplication.Models.UserViewModel", "UserViewModel")
                        .WithMany()
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserViewModel");
                });

            modelBuilder.Entity("AirlineReservationWebApplication.Models.PrivateServiceViewModel", b =>
                {
                    b.HasOne("AirlineReservationWebApplication.Models.AircraftViewModel", "aircraftViewModel")
                        .WithMany()
                        .HasForeignKey("Aircraft_Model")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("aircraftViewModel");
                });

            modelBuilder.Entity("AirlineReservationWebApplication.Models.ReservationViewModel", b =>
                {
                    b.HasOne("AirlineReservationWebApplication.Models.FlightViewModel", "flightViewModel")
                        .WithMany()
                        .HasForeignKey("Flight_No")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirlineReservationWebApplication.Models.HotelViewModel", "hotelViewModel")
                        .WithMany()
                        .HasForeignKey("Hotel_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirlineReservationWebApplication.Models.PassengerViewModel", "passengerViewModel")
                        .WithMany()
                        .HasForeignKey("Passenger_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirlineReservationWebApplication.Models.PaymentViewModel", "paymentViewModel")
                        .WithMany()
                        .HasForeignKey("Payment_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirlineReservationWebApplication.Models.PrivateServiceViewModel", "privateServiceViewModel")
                        .WithMany()
                        .HasForeignKey("PrivateService_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirlineReservationWebApplication.Models.TransportViewModel", "transportViewModel")
                        .WithMany()
                        .HasForeignKey("Transport_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("flightViewModel");

                    b.Navigation("hotelViewModel");

                    b.Navigation("passengerViewModel");

                    b.Navigation("paymentViewModel");

                    b.Navigation("privateServiceViewModel");

                    b.Navigation("transportViewModel");
                });
#pragma warning restore 612, 618
        }
    }
}
