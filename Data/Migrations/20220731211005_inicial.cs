using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaNomina.Data.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "tAuthentication",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: false),
                    AuthKey = table.Column<Guid>(nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tAuthentication", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tEmployee",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    SSN = table.Column<string>(nullable: true),
                    Insurance = table.Column<decimal>(nullable: false),
                    W4Allowances = table.Column<int>(nullable: false),
                    Retirement401KPercent = table.Column<decimal>(nullable: false),
                    Retirement401KPreTax = table.Column<bool>(nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tEmployee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tTaxPercentage",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxCode = table.Column<string>(nullable: true),
                    Percent = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tTaxPercentage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tUser",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CreateDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tPayment",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<long>(nullable: false),
                    GrossPay = table.Column<decimal>(nullable: false),
                    PaymentPeriodFrom = table.Column<DateTime>(nullable: false),
                    PaymentPeriodTo = table.Column<DateTime>(nullable: false),
                    FedTax = table.Column<decimal>(nullable: false),
                    StateTax = table.Column<decimal>(nullable: false),
                    SocialSecurityTax = table.Column<decimal>(nullable: false),
                    MedicareTax = table.Column<decimal>(nullable: false),
                    Insurance = table.Column<decimal>(nullable: false),
                    Retirement401K = table.Column<decimal>(nullable: false),
                    NetPay = table.Column<decimal>(nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tPayment_tEmployee_EmpId",
                        column: x => x.EmpId,
                        principalSchema: "dbo",
                        principalTable: "tEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tPayment_EmpId",
                schema: "dbo",
                table: "tPayment",
                column: "EmpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tAuthentication",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tPayment",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tTaxPercentage",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tUser",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tEmployee",
                schema: "dbo");
        }
    }
}
