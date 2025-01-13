using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class airportentityedited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FlightNumber",
                table: "Flights",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AdultPassengers",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BrandedFareName",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CabinClass",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Luggage",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Airports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdultPassengers",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "BrandedFareName",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "CabinClass",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "Luggage",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Airports");

            migrationBuilder.AlterColumn<string>(
                name: "FlightNumber",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
