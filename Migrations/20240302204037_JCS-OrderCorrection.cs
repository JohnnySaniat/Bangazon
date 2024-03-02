using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bangazon.Migrations
{
    public partial class JCSOrderCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeId",
                table: "Orders",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "PaymentTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "PaymentTypeId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentTypeId",
                table: "Orders",
                column: "PaymentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_PaymentTypes_PaymentTypeId",
                table: "Orders",
                column: "PaymentTypeId",
                principalTable: "PaymentTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_PaymentTypes_PaymentTypeId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PaymentTypeId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentTypeId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "PaymentType",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "PaymentType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "PaymentType",
                value: 2);
        }
    }
}
