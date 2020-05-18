using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class RolesSeed1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "3573dcce-b1f6-47cf-89bf-cb4af27b1cb1", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "9cc094bd-437e-4f25-b0f8-c8c5134fdae1", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ebc61ad-bc70-4bdf-99fd-70cde3371753", "ADMIN", "AQAAAAEAACcQAAAAEOvaXy6KCiVHvypw292W1+DGf3kzsG7mWIWOVYgUcDI0qCe+thaaFZi1mdUBC+DQOA==", "dd12bd7e-371a-43db-9e13-7c482fdb32cf" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "693dc604-0b79-48de-a585-aa87e7e18aac", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "1f513b1b-5f0b-4864-9797-d81d9224845d", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "94642037-8459-4a09-9513-eb2e52331cd8", null, "AQAAAAEAACcQAAAAEFxiIXSzRbxy+odly8VkPGyltgf8pQ28kiPgGF7b5cmPU620Y/DXoU0PEsbfPEeUkA==", "fc8598ba-d411-462d-b66f-339041247cfc" });
        }
    }
}
