using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ChangeDbRestrictions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_DocumentTypes_DocumentTypeId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_UchebnyeDiscipliny_UchebnayaDisciplinaId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Specialnosti_SpecialnostId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_UchebnyePlany_UchebnyjPlanId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_ObrazovatelnyeStandarty_Specialnosti_SpecialnostId",
                table: "ObrazovatelnyeStandarty");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicLessons_Groups_GroupId",
                table: "PublicLessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_CiklovyeKomissii_CiklovayaKomissiyaId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Positions_PositionId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_TipovyeUchebnyePlany_ObrazovatelnyeStandarty_ObrazovatelnyjStandartId",
                table: "TipovyeUchebnyePlany");

            migrationBuilder.DropForeignKey(
                name: "FK_UchebnyeDiscipliny_CiklovyeKomissii_CiklovayaKomissiyaId",
                table: "UchebnyeDiscipliny");

            migrationBuilder.DropForeignKey(
                name: "FK_UchebnyeDiscipliny_UchebnyePlany_UchebnyjPlanId",
                table: "UchebnyeDiscipliny");

            migrationBuilder.DropForeignKey(
                name: "FK_UchebnyePlany_TipovyeUchebnyePlany_TipovojUchebnyjPlanId",
                table: "UchebnyePlany");

            migrationBuilder.DropIndex(
                name: "IX_Groups_SpecialnostId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "RegistarcionnyjNomer",
                table: "UchebnyeDiscipliny");

            migrationBuilder.DropColumn(
                name: "SpecialnostId",
                table: "Groups");

            migrationBuilder.AlterColumn<int>(
                name: "TipovojUchebnyjPlanId",
                table: "UchebnyePlany",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UchebnyjPlanId",
                table: "UchebnyeDiscipliny",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CiklovayaKomissiyaId",
                table: "UchebnyeDiscipliny",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "All",
                table: "UchebnyeDiscipliny",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ObrazovatelnyjStandartId",
                table: "TipovyeUchebnyePlany",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "Teachers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CiklovayaKomissiyaId",
                table: "Teachers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SpecialnostId",
                table: "ObrazovatelnyeStandarty",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UchebnayaDisciplinaId",
                table: "Documents",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DocumentTypeId",
                table: "Documents",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_DocumentTypes_DocumentTypeId",
                table: "Documents",
                column: "DocumentTypeId",
                principalTable: "DocumentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_UchebnyeDiscipliny_UchebnayaDisciplinaId",
                table: "Documents",
                column: "UchebnayaDisciplinaId",
                principalTable: "UchebnyeDiscipliny",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_UchebnyePlany_UchebnyjPlanId",
                table: "Groups",
                column: "UchebnyjPlanId",
                principalTable: "UchebnyePlany",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ObrazovatelnyeStandarty_Specialnosti_SpecialnostId",
                table: "ObrazovatelnyeStandarty",
                column: "SpecialnostId",
                principalTable: "Specialnosti",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicLessons_Groups_GroupId",
                table: "PublicLessons",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_CiklovyeKomissii_CiklovayaKomissiyaId",
                table: "Teachers",
                column: "CiklovayaKomissiyaId",
                principalTable: "CiklovyeKomissii",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Positions_PositionId",
                table: "Teachers",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TipovyeUchebnyePlany_ObrazovatelnyeStandarty_ObrazovatelnyjStandartId",
                table: "TipovyeUchebnyePlany",
                column: "ObrazovatelnyjStandartId",
                principalTable: "ObrazovatelnyeStandarty",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_UchebnyeDiscipliny_CiklovyeKomissii_CiklovayaKomissiyaId",
                table: "UchebnyeDiscipliny",
                column: "CiklovayaKomissiyaId",
                principalTable: "CiklovyeKomissii",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_UchebnyeDiscipliny_UchebnyePlany_UchebnyjPlanId",
                table: "UchebnyeDiscipliny",
                column: "UchebnyjPlanId",
                principalTable: "UchebnyePlany",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_UchebnyePlany_TipovyeUchebnyePlany_TipovojUchebnyjPlanId",
                table: "UchebnyePlany",
                column: "TipovojUchebnyjPlanId",
                principalTable: "TipovyeUchebnyePlany",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_DocumentTypes_DocumentTypeId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_UchebnyeDiscipliny_UchebnayaDisciplinaId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_UchebnyePlany_UchebnyjPlanId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_ObrazovatelnyeStandarty_Specialnosti_SpecialnostId",
                table: "ObrazovatelnyeStandarty");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicLessons_Groups_GroupId",
                table: "PublicLessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_CiklovyeKomissii_CiklovayaKomissiyaId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Positions_PositionId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_TipovyeUchebnyePlany_ObrazovatelnyeStandarty_ObrazovatelnyjStandartId",
                table: "TipovyeUchebnyePlany");

            migrationBuilder.DropForeignKey(
                name: "FK_UchebnyeDiscipliny_CiklovyeKomissii_CiklovayaKomissiyaId",
                table: "UchebnyeDiscipliny");

            migrationBuilder.DropForeignKey(
                name: "FK_UchebnyeDiscipliny_UchebnyePlany_UchebnyjPlanId",
                table: "UchebnyeDiscipliny");

            migrationBuilder.DropForeignKey(
                name: "FK_UchebnyePlany_TipovyeUchebnyePlany_TipovojUchebnyjPlanId",
                table: "UchebnyePlany");

            migrationBuilder.DropColumn(
                name: "All",
                table: "UchebnyeDiscipliny");

            migrationBuilder.AlterColumn<int>(
                name: "TipovojUchebnyjPlanId",
                table: "UchebnyePlany",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UchebnyjPlanId",
                table: "UchebnyeDiscipliny",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CiklovayaKomissiyaId",
                table: "UchebnyeDiscipliny",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistarcionnyjNomer",
                table: "UchebnyeDiscipliny",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ObrazovatelnyjStandartId",
                table: "TipovyeUchebnyePlany",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "Teachers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CiklovayaKomissiyaId",
                table: "Teachers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SpecialnostId",
                table: "ObrazovatelnyeStandarty",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecialnostId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UchebnayaDisciplinaId",
                table: "Documents",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DocumentTypeId",
                table: "Documents",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_SpecialnostId",
                table: "Groups",
                column: "SpecialnostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_DocumentTypes_DocumentTypeId",
                table: "Documents",
                column: "DocumentTypeId",
                principalTable: "DocumentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_UchebnyeDiscipliny_UchebnayaDisciplinaId",
                table: "Documents",
                column: "UchebnayaDisciplinaId",
                principalTable: "UchebnyeDiscipliny",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Specialnosti_SpecialnostId",
                table: "Groups",
                column: "SpecialnostId",
                principalTable: "Specialnosti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_UchebnyePlany_UchebnyjPlanId",
                table: "Groups",
                column: "UchebnyjPlanId",
                principalTable: "UchebnyePlany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ObrazovatelnyeStandarty_Specialnosti_SpecialnostId",
                table: "ObrazovatelnyeStandarty",
                column: "SpecialnostId",
                principalTable: "Specialnosti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicLessons_Groups_GroupId",
                table: "PublicLessons",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_CiklovyeKomissii_CiklovayaKomissiyaId",
                table: "Teachers",
                column: "CiklovayaKomissiyaId",
                principalTable: "CiklovyeKomissii",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Positions_PositionId",
                table: "Teachers",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TipovyeUchebnyePlany_ObrazovatelnyeStandarty_ObrazovatelnyjStandartId",
                table: "TipovyeUchebnyePlany",
                column: "ObrazovatelnyjStandartId",
                principalTable: "ObrazovatelnyeStandarty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UchebnyeDiscipliny_CiklovyeKomissii_CiklovayaKomissiyaId",
                table: "UchebnyeDiscipliny",
                column: "CiklovayaKomissiyaId",
                principalTable: "CiklovyeKomissii",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UchebnyeDiscipliny_UchebnyePlany_UchebnyjPlanId",
                table: "UchebnyeDiscipliny",
                column: "UchebnyjPlanId",
                principalTable: "UchebnyePlany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UchebnyePlany_TipovyeUchebnyePlany_TipovojUchebnyjPlanId",
                table: "UchebnyePlany",
                column: "TipovojUchebnyjPlanId",
                principalTable: "TipovyeUchebnyePlany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
