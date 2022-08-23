using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaNomina.Data.Migrations
{
    public partial class secondVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                schema: "dbo",
                table: "tEmployee");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentPeriodTo",
                schema: "dbo",
                table: "tPayment",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                schema: "dbo",
                table: "tEmployee",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                schema: "dbo",
                table: "tEmployee",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Puesto",
                schema: "dbo",
                table: "tEmployee",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direccion",
                schema: "dbo",
                table: "tEmployee");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                schema: "dbo",
                table: "tEmployee");

            migrationBuilder.DropColumn(
                name: "Puesto",
                schema: "dbo",
                table: "tEmployee");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentPeriodTo",
                schema: "dbo",
                table: "tPayment",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                schema: "dbo",
                table: "tEmployee",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
