using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class MinorChanges1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_UchebnyePlany_UchebnyjPlanId",
                table: "Groups");

            migrationBuilder.AlterColumn<int>(
                name: "UchebnyjPlanId",
                table: "Groups",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AlterColumn<int>(
                name: "UchebnyjPlanId",
                table: "Groups",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_UchebnyePlany_UchebnyjPlanId",
                table: "Groups",
                column: "UchebnyjPlanId",
                principalTable: "UchebnyePlany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
