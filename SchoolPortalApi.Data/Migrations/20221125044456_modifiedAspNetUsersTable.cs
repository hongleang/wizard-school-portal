using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolPortalApi.Data.Migrations
{
    public partial class modifiedAspNetUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02f38c5f-5b90-4958-8420-2b299a9a5a01");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "252e59ea-a7d0-4702-96cc-6c7f9943886c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "20080648-b7ea-40b4-8937-ba61b56007d7", "a7e3ceef-8ec1-4dda-88c0-befdcde50305", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eb6ae950-9f2e-445c-b383-fb20a28cdb3e", "39a4aeaf-6b06-4dd4-b293-16acfd9c6c62", "user", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20080648-b7ea-40b4-8937-ba61b56007d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb6ae950-9f2e-445c-b383-fb20a28cdb3e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "02f38c5f-5b90-4958-8420-2b299a9a5a01", "139789a0-75fc-454d-b0b1-fcd2bdbfca21", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "252e59ea-a7d0-4702-96cc-6c7f9943886c", "c3536205-ee63-4414-a7f3-5b3a47e5a767", "admin", "ADMIN" });
        }
    }
}
