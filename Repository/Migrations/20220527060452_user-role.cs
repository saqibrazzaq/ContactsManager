using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class userrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e65ba31-b0df-4623-9294-fc4626c7bc5c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee1eb9c2-d999-431e-a423-6f26e7c70fbb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "13db2f2d-e8b6-44e5-b82b-b8c1bd8384af", "6ad44fc9-c8bb-4ba6-b477-663a744bf59c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2670546b-3e21-41cd-8b7b-d2408fbbe53a", "a3ba8bf4-21b8-45dd-9c4a-b9352df57065", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4e2c297f-3c41-44cb-8cef-9b6cdd19d20a", "1f1f4016-0053-44d3-bca6-de9ea98b8879", "Manager", "MANAGER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13db2f2d-e8b6-44e5-b82b-b8c1bd8384af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2670546b-3e21-41cd-8b7b-d2408fbbe53a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e2c297f-3c41-44cb-8cef-9b6cdd19d20a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7e65ba31-b0df-4623-9294-fc4626c7bc5c", "c255e6f1-7113-41dd-8794-6bf67e28df1f", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ee1eb9c2-d999-431e-a423-6f26e7c70fbb", "01071e9b-3b2f-4b74-a44f-bc04a3ded30f", "Manager", "MANAGER" });
        }
    }
}
