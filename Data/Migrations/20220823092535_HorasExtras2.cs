using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaNomina.Data.Migrations
{
    public partial class HorasExtras2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HorasExtras_tPayment_PaymentId",
                table: "HorasExtras");

            migrationBuilder.AlterColumn<long>(
                name: "PaymentId",
                table: "HorasExtras",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HorasExtras_tPayment_PaymentId",
                table: "HorasExtras",
                column: "PaymentId",
                principalSchema: "dbo",
                principalTable: "tPayment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HorasExtras_tPayment_PaymentId",
                table: "HorasExtras");

            migrationBuilder.AlterColumn<long>(
                name: "PaymentId",
                table: "HorasExtras",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_HorasExtras_tPayment_PaymentId",
                table: "HorasExtras",
                column: "PaymentId",
                principalSchema: "dbo",
                principalTable: "tPayment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
