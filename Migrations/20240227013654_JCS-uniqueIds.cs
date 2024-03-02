using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bangazon.Migrations
{
    public partial class JCSuniqueIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentTypeId",
                value: new DateTime(2024, 2, 26, 19, 36, 54, 161, DateTimeKind.Local).AddTicks(51));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Image", "Price", "ProductName", "Quantity", "SellerId", "TypeId" },
                values: new object[,]
                {
                    { 420420, "https://images.squarespace-cdn.com/content/v1/60749d2bc6ea077ef59f25bb/1668559020652-VH40D8P9YVPWO6MJKDA0/Butterfly+Shirt+1+Front.jpg", 19.99m, "T-shirt", 20, 2, 2 },
                    { 696969, "https://img-prod-cms-rt-microsoft-com.akamaized.net/cms/api/am/imageFileData/RW16TLP?ver=5c8b&q=90&m=6&h=705&w=1253&b=%23FFFFFFFF&f=jpg&o=f&p=140&aim=true", 999.99m, "Laptop", 10, 2, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 420420);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 696969);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentTypeId",
                value: new DateTime(2024, 2, 26, 12, 53, 29, 645, DateTimeKind.Local).AddTicks(4396));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Image", "Price", "ProductName", "Quantity", "SellerId", "TypeId" },
                values: new object[,]
                {
                    { 1, "https://img-prod-cms-rt-microsoft-com.akamaized.net/cms/api/am/imageFileData/RW16TLP?ver=5c8b&q=90&m=6&h=705&w=1253&b=%23FFFFFFFF&f=jpg&o=f&p=140&aim=true", 999.99m, "Laptop", 10, 2, 1 },
                    { 2, "https://images.squarespace-cdn.com/content/v1/60749d2bc6ea077ef59f25bb/1668559020652-VH40D8P9YVPWO6MJKDA0/Butterfly+Shirt+1+Front.jpg", 19.99m, "T-shirt", 20, 2, 2 }
                });
        }
    }
}
