using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bangazon.Migrations
{
    public partial class JCSManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Products_productsId",
                table: "OrderProduct");

            migrationBuilder.RenameColumn(
                name: "isSeller",
                table: "Users",
                newName: "IsSeller");

            migrationBuilder.RenameColumn(
                name: "paymentType",
                table: "Orders",
                newName: "PaymentType");

            migrationBuilder.RenameColumn(
                name: "productsId",
                table: "OrderProduct",
                newName: "ProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProduct_productsId",
                table: "OrderProduct",
                newName: "IX_OrderProduct_ProductsId");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentTypeId",
                value: new DateTime(2024, 2, 22, 8, 52, 21, 941, DateTimeKind.Local).AddTicks(696));

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Products_ProductsId",
                table: "OrderProduct",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Products_ProductsId",
                table: "OrderProduct");

            migrationBuilder.RenameColumn(
                name: "IsSeller",
                table: "Users",
                newName: "isSeller");

            migrationBuilder.RenameColumn(
                name: "PaymentType",
                table: "Orders",
                newName: "paymentType");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "OrderProduct",
                newName: "productsId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProduct_ProductsId",
                table: "OrderProduct",
                newName: "IX_OrderProduct_productsId");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentTypeId",
                value: new DateTime(2024, 2, 21, 18, 33, 40, 322, DateTimeKind.Local).AddTicks(8165));

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Products_productsId",
                table: "OrderProduct",
                column: "productsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
