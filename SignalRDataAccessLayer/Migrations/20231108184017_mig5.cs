using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalRDataAccessLayer.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SliderTitle",
                table: "Sliders",
                newName: "SliderTitle3");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Sliders",
                newName: "SliderTitle2");

            migrationBuilder.AddColumn<string>(
                name: "Description1",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description2",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description3",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SliderTitle1",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description1",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "Description2",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "Description3",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "SliderTitle1",
                table: "Sliders");

            migrationBuilder.RenameColumn(
                name: "SliderTitle3",
                table: "Sliders",
                newName: "SliderTitle");

            migrationBuilder.RenameColumn(
                name: "SliderTitle2",
                table: "Sliders",
                newName: "Description");
        }
    }
}
