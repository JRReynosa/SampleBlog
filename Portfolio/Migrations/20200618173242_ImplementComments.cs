using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.Migrations
{
    public partial class ImplementComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13aa6730-3979-4d2d-85f0-039a882c1b94");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "486c9d69-1a2d-46d9-9222-6682a4244d5c");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Comment");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateSubmitted",
                table: "Blog",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "96d7d31e-e14a-415b-986a-d2ec7460b59b", "599e9e29-99f1-418a-995b-5aeb50a53585", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8f8af94d-5e31-4701-9fa1-89e0a0a3c8af", "121655bb-f395-4ffd-a56b-d84ea91e147f", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f8af94d-5e31-4701-9fa1-89e0a0a3c8af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96d7d31e-e14a-415b-986a-d2ec7460b59b");

            migrationBuilder.DropColumn(
                name: "DateSubmitted",
                table: "Blog");

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "13aa6730-3979-4d2d-85f0-039a882c1b94", "b6b2a578-6fd4-4af8-9012-81b506f89128", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "486c9d69-1a2d-46d9-9222-6682a4244d5c", "40665e33-d362-438a-a2b7-3462bde019fd", "Administrator", "ADMINISTRATOR" });
        }
    }
}
