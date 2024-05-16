using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineReservationWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddModelsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aircraft",
                columns: table => new
                {
                    Aircraft_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aircraft_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aircraft_Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seat_Capacity = table.Column<int>(type: "int", nullable: false),
                    Aircraft_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Availability = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircraft", x => x.Aircraft_Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Feedback_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Passenger_Id = table.Column<int>(type: "int", nullable: false),
                    Passenger_Feedback = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Feedback_Id);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    Flight_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Flight_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departure_Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Arrival_Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Departure_Time = table.Column<TimeOnly>(type: "time", nullable: false),
                    Arrival_Time = table.Column<TimeOnly>(type: "time", nullable: false),
                    Departure_Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Arrival_Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total_Seats = table.Column<int>(type: "int", nullable: false),
                    Available_Seats = table.Column<int>(type: "int", nullable: false),
                    Aircraft_Id = table.Column<int>(type: "int", nullable: false),
                    Flight_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Flight_Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Business = table.Column<int>(type: "int", nullable: false),
                    Economy = table.Column<int>(type: "int", nullable: false),
                    FirstClass = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.Flight_Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    Hotel_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hotel_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hotel_Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Room_Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total_Rooms = table.Column<int>(type: "int", nullable: false),
                    Available_Rooms = table.Column<int>(type: "int", nullable: false),
                    Checkin_Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Checkout_Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Checkin_Time = table.Column<TimeOnly>(type: "time", nullable: false),
                    Checkout_Time = table.Column<TimeOnly>(type: "time", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Hotel_Id);
                });

            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    Offer_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start_Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Start_Time = table.Column<TimeOnly>(type: "time", nullable: false),
                    End_Date = table.Column<DateOnly>(type: "date", nullable: false),
                    End_Time = table.Column<TimeOnly>(type: "time", nullable: false),
                    Validity = table.Column<TimeSpan>(type: "time", nullable: false),
                    Offer_Range = table.Column<int>(type: "int", nullable: false),
                    Hotel_Id = table.Column<int>(type: "int", nullable: false),
                    Flight_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.Offer_Id);
                });

            migrationBuilder.CreateTable(
                name: "Passenger",
                columns: table => new
                {
                    Passenger_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passport = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Approved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passenger", x => x.Passenger_ID);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Payment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Payment_Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Payment_Time = table.Column<TimeOnly>(type: "time", nullable: false),
                    Reservation_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Payment_Id);
                });

            migrationBuilder.CreateTable(
                name: "PrivateService",
                columns: table => new
                {
                    PrivateService_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Departure_Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Arrival_Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Departure_Time = table.Column<TimeOnly>(type: "time", nullable: false),
                    Arrival_Time = table.Column<TimeOnly>(type: "time", nullable: false),
                    Departure_Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArrivalPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Service_Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aircraft_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateService", x => x.PrivateService_Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Reservation_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Passenger_Id = table.Column<int>(type: "int", nullable: false),
                    Passenger_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Flight_No = table.Column<int>(type: "int", nullable: false),
                    Flight_Booking_Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Payment_Id = table.Column<int>(type: "int", nullable: false),
                    Transport_Id = table.Column<int>(type: "int", nullable: false),
                    Hotel_Id = table.Column<int>(type: "int", nullable: false),
                    PrivateService_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Reservation_Id);
                });

            migrationBuilder.CreateTable(
                name: "Transport",
                columns: table => new
                {
                    Transport_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Transport_Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Available_Seats = table.Column<int>(type: "int", nullable: false),
                    Total_Seats = table.Column<int>(type: "int", nullable: false),
                    PickUp_Time = table.Column<TimeOnly>(type: "time", nullable: false),
                    PickUp_Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transport", x => x.Transport_Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.User_Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "User_Id", "Password", "User_Email", "User_Name" },
                values: new object[] { 1, "123", "admin@sample.com", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aircraft");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "Offer");

            migrationBuilder.DropTable(
                name: "Passenger");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "PrivateService");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Transport");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
