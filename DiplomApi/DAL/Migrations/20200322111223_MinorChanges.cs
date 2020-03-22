using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class MinorChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_UchebnyePlany_UchebnyjPlanId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Groups");

            migrationBuilder.AlterColumn<int>(
                name: "UchebnyjPlanId",
                table: "Groups",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Groups",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_UchebnyePlany_UchebnyjPlanId",
                table: "Groups",
                column: "UchebnyjPlanId",
                principalTable: "UchebnyePlany",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_UchebnyePlany_UchebnyjPlanId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Groups");

            migrationBuilder.AlterColumn<int>(
                name: "UchebnyjPlanId",
                table: "Groups",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_UchebnyePlany_UchebnyjPlanId",
                table: "Groups",
                column: "UchebnyjPlanId",
                principalTable: "UchebnyePlany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
