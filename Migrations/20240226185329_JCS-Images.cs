using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bangazon.Migrations
{
    public partial class JCSImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentTypeId",
                value: new DateTime(2024, 2, 26, 12, 53, 29, 645, DateTimeKind.Local).AddTicks(4396));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "https://img-prod-cms-rt-microsoft-com.akamaized.net/cms/api/am/imageFileData/RW16TLP?ver=5c8b&q=90&m=6&h=705&w=1253&b=%23FFFFFFFF&f=jpg&o=f&p=140&aim=true");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "https://images.squarespace-cdn.com/content/v1/60749d2bc6ea077ef59f25bb/1668559020652-VH40D8P9YVPWO6MJKDA0/Butterfly+Shirt+1+Front.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentTypeId",
                value: new DateTime(2024, 2, 24, 13, 5, 43, 321, DateTimeKind.Local).AddTicks(7824));
        }
    }
}
