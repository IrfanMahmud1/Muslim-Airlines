using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineReservationWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModelsAddToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Arrival_Place",
                table: "Transport",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Arrival_Place",
                table: "Transport");
        }
    }
}
