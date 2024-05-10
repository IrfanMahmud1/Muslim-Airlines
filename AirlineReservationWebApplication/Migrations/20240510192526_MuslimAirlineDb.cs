using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineReservationWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class MuslimAirlineDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aircraft",
                columns: table => new
                {
                    Aircraft_Model = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aircraft_Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seat_Capacity = table.Column<int>(type: "int", nullable: false),
                    Aircraft_Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircraft", x => x.Aircraft_Model);
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
                    Aircraft_Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Flight_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Flight_Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Available_Rooms = table.Column<int>(type: "int", nullable: false),
                    Room_Booked = table.Column<int>(type: "int", nullable: false),
                    Room_Availability = table.Column<bool>(type: "bit", nullable: false),
                    Hotel_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Hotel_Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Payment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Payment_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Payment_For = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Payment_Id);
                });

            migrationBuilder.CreateTable(
                name: "Transport",
                columns: table => new
                {
                    Transport_Model = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Transport_Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Available_Seats = table.Column<int>(type: "int", nullable: false),
                    Total_Seats = table.Column<int>(type: "int", nullable: false),
                    Seat_Booked = table.Column<int>(type: "int", nullable: false),
                    PickUp_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PickUp_Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transport_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transport", x => x.Transport_Model);
                });

            migrationBuilder.CreateTable(
                name: "Users",
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
                    table.PrimaryKey("PK_Users", x => x.User_Id);
                });

            migrationBuilder.CreateTable(
                name: "PrivateService",
                columns: table => new
                {
                    PrivateS_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Departure_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Arrival_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Departure_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Arrival_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Departure_Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArrivalPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Service_Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aircraft_Model = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateService", x => x.PrivateS_Id);
                    table.ForeignKey(
                        name: "FK_PrivateService_Aircraft_Aircraft_Model",
                        column: x => x.Aircraft_Model,
                        principalTable: "Aircraft",
                        principalColumn: "Aircraft_Model",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    Offer_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Validity = table.Column<TimeSpan>(type: "time", nullable: false),
                    Offer_Range = table.Column<int>(type: "int", nullable: false),
                    Offer_For = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hotel_Id = table.Column<int>(type: "int", nullable: false),
                    Flight_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.Offer_Id);
                    table.ForeignKey(
                        name: "FK_Offer_Flight_Flight_Id",
                        column: x => x.Flight_Id,
                        principalTable: "Flight",
                        principalColumn: "Flight_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offer_Hotel_Hotel_Id",
                        column: x => x.Hotel_Id,
                        principalTable: "Hotel",
                        principalColumn: "Hotel_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Passenger_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passport = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Mobile = table.Column<int>(type: "int", nullable: false),
                    Nid = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Passenger_ID);
                    table.ForeignKey(
                        name: "FK_Passengers_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_Feedback_Passengers_Passenger_Id",
                        column: x => x.Passenger_Id,
                        principalTable: "Passengers",
                        principalColumn: "Passenger_ID",
                        onDelete: ReferentialAction.Cascade);
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
                    Flight_Booking_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Payment_Id = table.Column<int>(type: "int", nullable: false),
                    Transport_Id = table.Column<int>(type: "int", nullable: false),
                    Hotel_Id = table.Column<int>(type: "int", nullable: false),
                    PrivateService_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Reservation_Id);
                    table.ForeignKey(
                        name: "FK_Reservation_Flight_Flight_No",
                        column: x => x.Flight_No,
                        principalTable: "Flight",
                        principalColumn: "Flight_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Hotel_Hotel_Id",
                        column: x => x.Hotel_Id,
                        principalTable: "Hotel",
                        principalColumn: "Hotel_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Passengers_Passenger_Id",
                        column: x => x.Passenger_Id,
                        principalTable: "Passengers",
                        principalColumn: "Passenger_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Payment_Payment_Id",
                        column: x => x.Payment_Id,
                        principalTable: "Payment",
                        principalColumn: "Payment_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_PrivateService_PrivateService_Id",
                        column: x => x.PrivateService_Id,
                        principalTable: "PrivateService",
                        principalColumn: "PrivateS_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Transport_Transport_Id",
                        column: x => x.Transport_Id,
                        principalTable: "Transport",
                        principalColumn: "Transport_Model",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "User_Id", "Password", "User_Email", "User_Name" },
                values: new object[] { 1, "123", "admin@sample.com", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_Passenger_Id",
                table: "Feedback",
                column: "Passenger_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_Flight_Id",
                table: "Offer",
                column: "Flight_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_Hotel_Id",
                table: "Offer",
                column: "Hotel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_User_Id",
                table: "Passengers",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateService_Aircraft_Model",
                table: "PrivateService",
                column: "Aircraft_Model");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_Flight_No",
                table: "Reservation",
                column: "Flight_No");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_Hotel_Id",
                table: "Reservation",
                column: "Hotel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_Passenger_Id",
                table: "Reservation",
                column: "Passenger_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_Payment_Id",
                table: "Reservation",
                column: "Payment_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_PrivateService_Id",
                table: "Reservation",
                column: "PrivateService_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_Transport_Id",
                table: "Reservation",
                column: "Transport_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Offer");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "PrivateService");

            migrationBuilder.DropTable(
                name: "Transport");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Aircraft");
        }
    }
}
