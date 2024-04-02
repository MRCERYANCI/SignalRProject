using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalRDataAccessLayer.Migrations
{
    public partial class mig1453 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookingPhone",
                table: "Bookings",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "BookingPersonCount",
                table: "Bookings",
                newName: "PersonCount");

            migrationBuilder.RenameColumn(
                name: "BookingName",
                table: "Bookings",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "BookingMail",
                table: "Bookings",
                newName: "Mail");

            migrationBuilder.RenameColumn(
                name: "BookingDate",
                table: "Bookings",
                newName: "Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Bookings",
                newName: "BookingPhone");

            migrationBuilder.RenameColumn(
                name: "PersonCount",
                table: "Bookings",
                newName: "BookingPersonCount");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Bookings",
                newName: "BookingName");

            migrationBuilder.RenameColumn(
                name: "Mail",
                table: "Bookings",
                newName: "BookingMail");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Bookings",
                newName: "BookingDate");
        }
    }
}
