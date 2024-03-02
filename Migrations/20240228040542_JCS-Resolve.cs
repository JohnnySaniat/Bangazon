using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bangazon.Migrations
{
    public partial class JCSResolve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductTypeId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductTypeId1",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductTypeId1",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId1",
                table: "Products",
                column: "ProductTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId1",
                table: "Products",
                column: "ProductTypeId1",
                principalTable: "ProductTypes",
                principalColumn: "Id");
        }
    }
}
