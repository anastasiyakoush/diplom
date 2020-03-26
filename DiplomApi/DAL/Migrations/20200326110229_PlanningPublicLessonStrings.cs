using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class PlanningPublicLessonStrings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpectedDate",
                table: "PlanningPublicLessons");

            migrationBuilder.AddColumn<string>(
                name: "Month",
                table: "PlanningPublicLessons",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Month",
                table: "PlanningPublicLessons");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpectedDate",
                table: "PlanningPublicLessons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
