using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineReservationWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewTableColumnsToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Is_Approved",
                table: "Passenger");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Passenger",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date_of_Birth",
                table: "Passenger",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "PassportExpiryDate",
                table: "Passenger",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Passenger",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Flight",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Passenger");

            migrationBuilder.DropColumn(
                name: "Date_of_Birth",
                table: "Passenger");

            migrationBuilder.DropColumn(
                name: "PassportExpiryDate",
                table: "Passenger");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Passenger");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Flight");

            migrationBuilder.AddColumn<bool>(
                name: "Is_Approved",
                table: "Passenger",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
