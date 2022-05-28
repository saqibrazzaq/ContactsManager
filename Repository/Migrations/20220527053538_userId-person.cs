using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class userIdperson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63202d60-7aeb-4833-af39-bf3c0915696e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3fcb04d-2501-47fd-81f8-cf1ee681ed2e");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Person",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7e65ba31-b0df-4623-9294-fc4626c7bc5c", "c255e6f1-7113-41dd-8794-6bf67e28df1f", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ee1eb9c2-d999-431e-a423-6f26e7c70fbb", "01071e9b-3b2f-4b74-a44f-bc04a3ded30f", "Manager", "MANAGER" });

            migrationBuilder.CreateIndex(
                name: "IX_Person_UserId",
                table: "Person",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_AspNetUsers_UserId",
                table: "Person",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_AspNetUsers_UserId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_UserId",
                table: "Person");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e65ba31-b0df-4623-9294-fc4626c7bc5c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee1eb9c2-d999-431e-a423-6f26e7c70fbb");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Person");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "63202d60-7aeb-4833-af39-bf3c0915696e", "37cdf74a-861b-4817-89cf-27f00a4c71ba", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a3fcb04d-2501-47fd-81f8-cf1ee681ed2e", "fba63e36-4041-4afd-8da7-0346f53a6d92", "Manager", "MANAGER" });
        }
    }
}
