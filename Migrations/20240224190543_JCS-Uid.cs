using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bangazon.Migrations
{
    public partial class JCSUid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirebaseKey",
                table: "Users",
                newName: "Uid");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentTypeId",
                value: new DateTime(2024, 2, 24, 13, 5, 43, 321, DateTimeKind.Local).AddTicks(7824));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Uid",
                table: "Users",
                newName: "FirebaseKey");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentTypeId",
                value: new DateTime(2024, 2, 22, 8, 52, 21, 941, DateTimeKind.Local).AddTicks(696));
        }
    }
}
