using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.Migrations
{
    public partial class CleanUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Blog_BlogID",
                table: "Comment");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d0f5eaf-4d02-49b5-9b38-3d38362fb546");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5c87c0b-b5bd-4faf-af0b-8f568b2bea47");

            migrationBuilder.RenameColumn(
                name: "BlogID",
                table: "Comment",
                newName: "BlogId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_BlogID",
                table: "Comment",
                newName: "IX_Comment_BlogId");

            migrationBuilder.RenameColumn(
                name: "BlogID",
                table: "Blog",
                newName: "BlogId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "13aa6730-3979-4d2d-85f0-039a882c1b94", "b6b2a578-6fd4-4af8-9012-81b506f89128", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "486c9d69-1a2d-46d9-9222-6682a4244d5c", "40665e33-d362-438a-a2b7-3462bde019fd", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Blog_BlogId",
                table: "Comment",
                column: "BlogId",
                principalTable: "Blog",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Blog_BlogId",
                table: "Comment");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13aa6730-3979-4d2d-85f0-039a882c1b94");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "486c9d69-1a2d-46d9-9222-6682a4244d5c");

            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "Comment",
                newName: "BlogID");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_BlogId",
                table: "Comment",
                newName: "IX_Comment_BlogID");

            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "Blog",
                newName: "BlogID");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a5c87c0b-b5bd-4faf-af0b-8f568b2bea47", "87beb84c-d196-4151-8890-429883debe68", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4d0f5eaf-4d02-49b5-9b38-3d38362fb546", "572d1b37-406b-4749-834c-2c1f8ae89301", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Blog_BlogID",
                table: "Comment",
                column: "BlogID",
                principalTable: "Blog",
                principalColumn: "BlogID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
