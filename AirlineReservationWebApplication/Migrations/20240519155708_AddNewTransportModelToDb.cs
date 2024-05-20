using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineReservationWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTransportModelToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available_Seats",
                table: "Transport");

            migrationBuilder.RenameColumn(
                name: "Reserved_Seats",
                table: "Transport",
                newName: "Booked_Seats");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Booked_Seats",
                table: "Transport",
                newName: "Reserved_Seats");

            migrationBuilder.AddColumn<int>(
                name: "Available_Seats",
                table: "Transport",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
