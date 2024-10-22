using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineReservationWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddedFlightTableColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Flight");

            migrationBuilder.AddColumn<decimal>(
                name: "B_Price",
                table: "Flight",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "E_Price",
                table: "Flight",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FC_Price",
                table: "Flight",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "B_Price",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "E_Price",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "FC_Price",
                table: "Flight");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Flight",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
