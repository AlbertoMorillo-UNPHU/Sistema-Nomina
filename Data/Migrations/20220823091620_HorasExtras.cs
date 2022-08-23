using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaNomina.Data.Migrations
{
    public partial class HorasExtras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HorasExtras",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CantidadMes = table.Column<decimal>(nullable: false),
                    FechaEfectiva = table.Column<DateTime>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    PaymentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorasExtras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HorasExtras_tPayment_PaymentId",
                        column: x => x.PaymentId,
                        principalSchema: "dbo",
                        principalTable: "tPayment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HorasExtras_PaymentId",
                table: "HorasExtras",
                column: "PaymentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HorasExtras");
        }
    }
}
