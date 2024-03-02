using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bangazon.Migrations
{
    public partial class JCSProductUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Products",
                newName: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                column: "ProductTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId",
                table: "Products",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductTypeId",
                table: "Products",
                newName: "TypeId");
        }
    }
}
