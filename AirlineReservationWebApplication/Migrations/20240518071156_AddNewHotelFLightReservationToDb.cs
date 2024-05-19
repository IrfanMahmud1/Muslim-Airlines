using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineReservationWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddNewHotelFLightReservationToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Available_Rooms",
                table: "Hotel",
                newName: "Booked_Rooms");

            migrationBuilder.RenameColumn(
                name: "Available_Seats",
                table: "Flight",
                newName: "Booked_Seats");

            migrationBuilder.AddColumn<int>(
                name: "Reserved_Seats",
                table: "Transport",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "Checkin_Time",
                table: "Reservation",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reserved_Seats",
                table: "Transport");

            migrationBuilder.DropColumn(
                name: "Checkin_Time",
                table: "Reservation");

            migrationBuilder.RenameColumn(
                name: "Booked_Rooms",
                table: "Hotel",
                newName: "Available_Rooms");

            migrationBuilder.RenameColumn(
                name: "Booked_Seats",
                table: "Flight",
                newName: "Available_Seats");
        }
    }
}
