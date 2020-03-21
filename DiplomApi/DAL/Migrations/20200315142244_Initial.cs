using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CiklovyeKomissii",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CiklovyeKomissii", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialnosti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialnosti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    FatherName = table.Column<string>(nullable: true),
                    Category = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    PositionId = table.Column<int>(nullable: false),
                    CiklovayaKomissiyaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_CiklovyeKomissii_CiklovayaKomissiyaId",
                        column: x => x.CiklovayaKomissiyaId,
                        principalTable: "CiklovyeKomissii",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teachers_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObrazovatelnyeStandarty",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistarcionnyjNomer = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Link = table.Column<string>(nullable: true),
                    SpecialnostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObrazovatelnyeStandarty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObrazovatelnyeStandarty_Specialnosti_SpecialnostId",
                        column: x => x.SpecialnostId,
                        principalTable: "Specialnosti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipovyeUchebnyePlany",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistarcionnyjNomer = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Link = table.Column<string>(nullable: true),
                    ObrazovatelnyjStandartId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipovyeUchebnyePlany", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipovyeUchebnyePlany_ObrazovatelnyeStandarty_ObrazovatelnyjStandartId",
                        column: x => x.ObrazovatelnyjStandartId,
                        principalTable: "ObrazovatelnyeStandarty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UchebnyePlany",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistarcionnyjNomer = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Link = table.Column<string>(nullable: true),
                    TipovojUchebnyjPlanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UchebnyePlany", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UchebnyePlany_TipovyeUchebnyePlany_TipovojUchebnyjPlanId",
                        column: x => x.TipovojUchebnyjPlanId,
                        principalTable: "TipovyeUchebnyePlany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(nullable: false),
                    UchebnyjPlanId = table.Column<int>(nullable: true),
                    SpecialnostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Specialnosti_SpecialnostId",
                        column: x => x.SpecialnostId,
                        principalTable: "Specialnosti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Groups_UchebnyePlany_UchebnyjPlanId",
                        column: x => x.UchebnyjPlanId,
                        principalTable: "UchebnyePlany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UchebnyeDiscipliny",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    RegistarcionnyjNomer = table.Column<string>(nullable: true),
                    Laboratornye = table.Column<int>(nullable: false),
                    Practika = table.Column<int>(nullable: false),
                    KursovoeProectirovanie = table.Column<int>(nullable: false),
                    Component = table.Column<int>(nullable: false),
                    UchebnyjPlanId = table.Column<int>(nullable: false),
                    CiklovayaKomissiyaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UchebnyeDiscipliny", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UchebnyeDiscipliny_CiklovyeKomissii_CiklovayaKomissiyaId",
                        column: x => x.CiklovayaKomissiyaId,
                        principalTable: "CiklovyeKomissii",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UchebnyeDiscipliny_UchebnyePlany_UchebnyjPlanId",
                        column: x => x.UchebnyjPlanId,
                        principalTable: "UchebnyePlany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    RegistarcionnyjNomer = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Link = table.Column<string>(nullable: true),
                    DocumentTypeId = table.Column<int>(nullable: false),
                    UchebnayaDisciplinaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_DocumentTypes_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_UchebnyeDiscipliny_UchebnayaDisciplinaId",
                        column: x => x.UchebnayaDisciplinaId,
                        principalTable: "UchebnyeDiscipliny",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicLessons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Topic = table.Column<string>(nullable: true),
                    MetodicheskieNarabotki = table.Column<int>(nullable: false),
                    AnalisUroka = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: true),
                    TeacherId = table.Column<int>(nullable: true),
                    UchebnayaDisciplinaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicLessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicLessons_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PublicLessons_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PublicLessons_UchebnyeDiscipliny_UchebnayaDisciplinaId",
                        column: x => x.UchebnayaDisciplinaId,
                        principalTable: "UchebnyeDiscipliny",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocumentsAuthors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(nullable: true),
                    DocumentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentsAuthors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentsAuthors_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentsAuthors_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentTypeId",
                table: "Documents",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_UchebnayaDisciplinaId",
                table: "Documents",
                column: "UchebnayaDisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentsAuthors_DocumentId",
                table: "DocumentsAuthors",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentsAuthors_TeacherId",
                table: "DocumentsAuthors",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_SpecialnostId",
                table: "Groups",
                column: "SpecialnostId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_UchebnyjPlanId",
                table: "Groups",
                column: "UchebnyjPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ObrazovatelnyeStandarty_SpecialnostId",
                table: "ObrazovatelnyeStandarty",
                column: "SpecialnostId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicLessons_GroupId",
                table: "PublicLessons",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicLessons_TeacherId",
                table: "PublicLessons",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicLessons_UchebnayaDisciplinaId",
                table: "PublicLessons",
                column: "UchebnayaDisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_CiklovayaKomissiyaId",
                table: "Teachers",
                column: "CiklovayaKomissiyaId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_PositionId",
                table: "Teachers",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_TipovyeUchebnyePlany_ObrazovatelnyjStandartId",
                table: "TipovyeUchebnyePlany",
                column: "ObrazovatelnyjStandartId");

            migrationBuilder.CreateIndex(
                name: "IX_UchebnyeDiscipliny_CiklovayaKomissiyaId",
                table: "UchebnyeDiscipliny",
                column: "CiklovayaKomissiyaId");

            migrationBuilder.CreateIndex(
                name: "IX_UchebnyeDiscipliny_UchebnyjPlanId",
                table: "UchebnyeDiscipliny",
                column: "UchebnyjPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_UchebnyePlany_TipovojUchebnyjPlanId",
                table: "UchebnyePlany",
                column: "TipovojUchebnyjPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentsAuthors");

            migrationBuilder.DropTable(
                name: "PublicLessons");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "DocumentTypes");

            migrationBuilder.DropTable(
                name: "UchebnyeDiscipliny");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "CiklovyeKomissii");

            migrationBuilder.DropTable(
                name: "UchebnyePlany");

            migrationBuilder.DropTable(
                name: "TipovyeUchebnyePlany");

            migrationBuilder.DropTable(
                name: "ObrazovatelnyeStandarty");

            migrationBuilder.DropTable(
                name: "Specialnosti");
        }
    }
}
