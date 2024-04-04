using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineReservationWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddRegisterToDbAfterRenamingProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User_Name",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "User_Email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "Users",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "User_Name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "User_Email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "User_Id");
        }
    }
}
