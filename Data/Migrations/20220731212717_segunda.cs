using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaNomina.Data.Migrations
{
    public partial class segunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FedTax",
                schema: "dbo",
                table: "tPayment");

            migrationBuilder.DropColumn(
                name: "Insurance",
                schema: "dbo",
                table: "tPayment");

            migrationBuilder.DropColumn(
                name: "MedicareTax",
                schema: "dbo",
                table: "tPayment");

            migrationBuilder.DropColumn(
                name: "Retirement401K",
                schema: "dbo",
                table: "tPayment");

            migrationBuilder.DropColumn(
                name: "SocialSecurityTax",
                schema: "dbo",
                table: "tPayment");

            migrationBuilder.DropColumn(
                name: "StateTax",
                schema: "dbo",
                table: "tPayment");

            migrationBuilder.DropColumn(
                name: "Retirement401KPreTax",
                schema: "dbo",
                table: "tEmployee");

            migrationBuilder.DropColumn(
                name: "W4Allowances",
                schema: "dbo",
                table: "tEmployee");

            migrationBuilder.RenameColumn(
                name: "Retirement401KPercent",
                schema: "dbo",
                table: "tEmployee",
                newName: "RetirementPercent");

            migrationBuilder.RenameColumn(
                name: "Insurance",
                schema: "dbo",
                table: "tEmployee",
                newName: "ISR");

            migrationBuilder.AddColumn<decimal>(
                name: "AFP",
                schema: "dbo",
                table: "tPayment",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ARL",
                schema: "dbo",
                table: "tPayment",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ARS",
                schema: "dbo",
                table: "tPayment",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "INFOTEP",
                schema: "dbo",
                table: "tPayment",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ISR",
                schema: "dbo",
                table: "tPayment",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Retirement",
                schema: "dbo",
                table: "tPayment",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TSS",
                schema: "dbo",
                table: "tPayment",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AFP",
                schema: "dbo",
                table: "tEmployee",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ARS",
                schema: "dbo",
                table: "tEmployee",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AFP",
                schema: "dbo",
                table: "tPayment");

            migrationBuilder.DropColumn(
                name: "ARL",
                schema: "dbo",
                table: "tPayment");

            migrationBuilder.DropColumn(
                name: "ARS",
                schema: "dbo",
                table: "tPayment");

            migrationBuilder.DropColumn(
                name: "INFOTEP",
                schema: "dbo",
                table: "tPayment");

            migrationBuilder.DropColumn(
                name: "ISR",
                schema: "dbo",
                table: "tPayment");

            migrationBuilder.DropColumn(
                name: "Retirement",
                schema: "dbo",
                table: "tPayment");

            migrationBuilder.DropColumn(
                name: "TSS",
                schema: "dbo",
                table: "tPayment");

            migrationBuilder.DropColumn(
                name: "AFP",
                schema: "dbo",
                table: "tEmployee");

            migrationBuilder.DropColumn(
                name: "ARS",
                schema: "dbo",
                table: "tEmployee");

            migrationBuilder.RenameColumn(
                name: "RetirementPercent",
                schema: "dbo",
                table: "tEmployee",
                newName: "Retirement401KPercent");

            migrationBuilder.RenameColumn(
                name: "ISR",
                schema: "dbo",
                table: "tEmployee",
                newName: "Insurance");

            migrationBuilder.AddColumn<decimal>(
                name: "FedTax",
                schema: "dbo",
                table: "tPayment",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Insurance",
                schema: "dbo",
                table: "tPayment",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MedicareTax",
                schema: "dbo",
                table: "tPayment",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Retirement401K",
                schema: "dbo",
                table: "tPayment",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SocialSecurityTax",
                schema: "dbo",
                table: "tPayment",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "StateTax",
                schema: "dbo",
                table: "tPayment",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "Retirement401KPreTax",
                schema: "dbo",
                table: "tEmployee",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "W4Allowances",
                schema: "dbo",
                table: "tEmployee",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
