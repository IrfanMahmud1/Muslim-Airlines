using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineReservationWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNewTransportModelToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Transport_Name",
                table: "Transport",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Transport_Name",
                table: "Transport");
        }
    }
}
