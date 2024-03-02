using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bangazon.Migrations
{
    public partial class JCSOrderUID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Uid",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Uid",
                value: "UddDl9yg9Nhq28kdu0SQyjjstkr2");

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "IsComplete", "PaymentType", "Uid" },
                values: new object[,]
                {
                    { 2, false, 2, "UddDl9yg9Nhq28kdu0SQyjjstkr2" },
                    { 3, true, 2, "UddDl9yg9Nhq28kdu0SQyjjstkr2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Uid",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: 1);
        }
    }
}
