﻿// <auto-generated />
using System;
using DAL.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20200427141442_PlanninglessonMonth")]
    partial class PlanninglessonMonth
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Entities.CiklovayaKomissiya", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CiklovyeKomissii");
                });

            modelBuilder.Entity("DAL.Entities.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<int?>("DocumentTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistarcionnyjNomer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UchebnayaDisciplinaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DocumentTypeId");

                    b.HasIndex("UchebnayaDisciplinaId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("DAL.Entities.DocumentAuthor", b =>
                {
                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<int>("DocumentId")
                        .HasColumnType("int");

                    b.HasKey("TeacherId", "DocumentId");

                    b.HasIndex("DocumentId");

                    b.ToTable("DocumentsAuthors");
                });

            modelBuilder.Entity("DAL.Entities.DocumentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DocumentTypes");
                });

            modelBuilder.Entity("DAL.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UchebnyjPlanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UchebnyjPlanId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("DAL.Entities.ObrazovatelnyjStandart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistarcionnyjNomer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SpecialnostId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpecialnostId");

                    b.ToTable("ObrazovatelnyeStandarty");
                });

            modelBuilder.Entity("DAL.Entities.PlanningPublicLesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("PlanningPublicLessons");
                });

            modelBuilder.Entity("DAL.Entities.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("DAL.Entities.PublicLesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnalisUroka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("MetodicheskieNarabotki")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.Property<string>("Topic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UchebnayaDisciplinaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("TeacherId");

                    b.HasIndex("UchebnayaDisciplinaId");

                    b.ToTable("PublicLessons");
                });

            modelBuilder.Entity("DAL.Entities.Specialnost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Specialnosti");
                });

            modelBuilder.Entity("DAL.Entities.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<int?>("CiklovayaKomissiyaId")
                        .HasColumnType("int");

                    b.Property<string>("FatherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PositionId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CiklovayaKomissiyaId");

                    b.HasIndex("PositionId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("DAL.Entities.TipovojUchebnyjPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ObrazovatelnyjStandartId")
                        .HasColumnType("int");

                    b.Property<string>("RegistarcionnyjNomer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ObrazovatelnyjStandartId");

                    b.ToTable("TipovyeUchebnyePlany");
                });

            modelBuilder.Entity("DAL.Entities.UchebnayaDisciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("All")
                        .HasColumnType("int");

                    b.Property<int?>("CiklovayaKomissiyaId")
                        .HasColumnType("int");

                    b.Property<int>("Component")
                        .HasColumnType("int");

                    b.Property<int>("KursovoeProectirovanie")
                        .HasColumnType("int");

                    b.Property<int>("Laboratornye")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Practika")
                        .HasColumnType("int");

                    b.Property<int?>("UchebnyjPlanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CiklovayaKomissiyaId");

                    b.HasIndex("UchebnyjPlanId");

                    b.ToTable("UchebnyeDiscipliny");
                });

            modelBuilder.Entity("DAL.Entities.UchebnyjPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistarcionnyjNomer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TipovojUchebnyjPlanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipovojUchebnyjPlanId");

                    b.ToTable("UchebnyePlany");
                });

            modelBuilder.Entity("DAL.Entities.Document", b =>
                {
                    b.HasOne("DAL.Entities.DocumentType", "DocumentType")
                        .WithMany("Documents")
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DAL.Entities.UchebnayaDisciplina", "UchebnayaDisciplina")
                        .WithMany()
                        .HasForeignKey("UchebnayaDisciplinaId");
                });

            modelBuilder.Entity("DAL.Entities.DocumentAuthor", b =>
                {
                    b.HasOne("DAL.Entities.Document", "Document")
                        .WithMany("DocumentAuthors")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.Teacher", "Teacher")
                        .WithMany("DocumentAuthors")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Entities.Group", b =>
                {
                    b.HasOne("DAL.Entities.UchebnyjPlan", "UchebnyjPlan")
                        .WithMany("Groups")
                        .HasForeignKey("UchebnyjPlanId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("DAL.Entities.ObrazovatelnyjStandart", b =>
                {
                    b.HasOne("DAL.Entities.Specialnost", "Specialnost")
                        .WithMany("ObrazovatelnyjStandarts")
                        .HasForeignKey("SpecialnostId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("DAL.Entities.PlanningPublicLesson", b =>
                {
                    b.HasOne("DAL.Entities.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Entities.PublicLesson", b =>
                {
                    b.HasOne("DAL.Entities.Group", "Group")
                        .WithMany("PublicLessons")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DAL.Entities.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");

                    b.HasOne("DAL.Entities.UchebnayaDisciplina", "UchebnayaDisciplina")
                        .WithMany()
                        .HasForeignKey("UchebnayaDisciplinaId");
                });

            modelBuilder.Entity("DAL.Entities.Teacher", b =>
                {
                    b.HasOne("DAL.Entities.CiklovayaKomissiya", "CiklovayaKomissiya")
                        .WithMany("Teachers")
                        .HasForeignKey("CiklovayaKomissiyaId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DAL.Entities.Position", "Position")
                        .WithMany("Teachers")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("DAL.Entities.TipovojUchebnyjPlan", b =>
                {
                    b.HasOne("DAL.Entities.ObrazovatelnyjStandart", "ObrazovatelnyjStandart")
                        .WithMany("TipovojUchebnyjPlans")
                        .HasForeignKey("ObrazovatelnyjStandartId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("DAL.Entities.UchebnayaDisciplina", b =>
                {
                    b.HasOne("DAL.Entities.CiklovayaKomissiya", "CiklovayaKomissiya")
                        .WithMany("UchebnayaDisciplinas")
                        .HasForeignKey("CiklovayaKomissiyaId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DAL.Entities.UchebnyjPlan", "UchebnyjPlan")
                        .WithMany("UchebnayaDisciplinas")
                        .HasForeignKey("UchebnyjPlanId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("DAL.Entities.UchebnyjPlan", b =>
                {
                    b.HasOne("DAL.Entities.TipovojUchebnyjPlan", "TipovojUchebnyjPlan")
                        .WithMany("UchebnyjPlans")
                        .HasForeignKey("TipovojUchebnyjPlanId")
                        .OnDelete(DeleteBehavior.SetNull);
                });
#pragma warning restore 612, 618
        }
    }
}
