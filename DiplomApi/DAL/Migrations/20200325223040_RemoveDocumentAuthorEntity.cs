using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class RemoveDocumentAuthorEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentsAuthors_Documents_DocumentId",
                table: "DocumentsAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentsAuthors_Teachers_TeacherId",
                table: "DocumentsAuthors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentsAuthors",
                table: "DocumentsAuthors");

            migrationBuilder.DropIndex(
                name: "IX_DocumentsAuthors_TeacherId",
                table: "DocumentsAuthors");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DocumentsAuthors");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "DocumentsAuthors",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DocumentId",
                table: "DocumentsAuthors",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentsAuthors",
                table: "DocumentsAuthors",
                columns: new[] { "TeacherId", "DocumentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentsAuthors_Documents_DocumentId",
                table: "DocumentsAuthors",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentsAuthors_Teachers_TeacherId",
                table: "DocumentsAuthors",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentsAuthors_Documents_DocumentId",
                table: "DocumentsAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentsAuthors_Teachers_TeacherId",
                table: "DocumentsAuthors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentsAuthors",
                table: "DocumentsAuthors");

            migrationBuilder.AlterColumn<int>(
                name: "DocumentId",
                table: "DocumentsAuthors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "DocumentsAuthors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DocumentsAuthors",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentsAuthors",
                table: "DocumentsAuthors",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentsAuthors_TeacherId",
                table: "DocumentsAuthors",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentsAuthors_Documents_DocumentId",
                table: "DocumentsAuthors",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentsAuthors_Teachers_TeacherId",
                table: "DocumentsAuthors",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
