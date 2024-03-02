using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bangazon.Migrations
{
    public partial class JCSProductTypeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "Accessories");

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: "Tops");

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 3, "Shoes" },
                    { 4, "Bottoms" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Image", "Price", "ProductName", "ProductTypeId", "Quantity", "SellerId" },
                values: new object[,]
                {
                    { 1, "https://img-prod-cms-rt-microsoft-com.akamaized.net/cms/api/am/imageFileData/RW16TLP?ver=5c8b&q=90&m=6&h=705&w=1253&b=%23FFFFFFFF&f=jpg&o=f&p=140&aim=true", 999.99m, "Laptop", 1, 10, 2 },
                    { 2, "https://images.squarespace-cdn.com/content/v1/60749d2bc6ea077ef59f25bb/1668559020652-VH40D8P9YVPWO6MJKDA0/Butterfly+Shirt+1+Front.jpg", 19.99m, "T-shirt", 2, 20, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "Electronics");

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: "Clothing");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Image", "Price", "ProductName", "ProductTypeId", "Quantity", "SellerId" },
                values: new object[,]
                {
                    { 420420, "https://images.squarespace-cdn.com/content/v1/60749d2bc6ea077ef59f25bb/1668559020652-VH40D8P9YVPWO6MJKDA0/Butterfly+Shirt+1+Front.jpg", 19.99m, "T-shirt", 2, 20, 2 },
                    { 696969, "https://img-prod-cms-rt-microsoft-com.akamaized.net/cms/api/am/imageFileData/RW16TLP?ver=5c8b&q=90&m=6&h=705&w=1253&b=%23FFFFFFFF&f=jpg&o=f&p=140&aim=true", 999.99m, "Laptop", 1, 10, 2 }
                });
        }
    }
}
