using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using static Common.Enums;

namespace DAL
{
  public static class DbSeeder
  {
    private static List<IdentityRole> roles = new List<IdentityRole>{
      new IdentityRole{ Id="1", Name="Admin", NormalizedName="ADMIN"},
      new IdentityRole{ Id="2", Name="User", NormalizedName="USER" }
    };

    private static List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>{
      new IdentityUserRole<string>{ UserId="1", RoleId="1"}
    };

    private static IdentityUser GetAdminUser()
    {
      var user = new IdentityUser { Id = "1", UserName = "admin", NormalizedUserName = "ADMIN" };

      var ph = new PasswordHasher<IdentityUser>();
      user.PasswordHash = ph.HashPassword(user, "admin");

      return user;
    }

    //private static List<CiklovayaKomissiya> ciklovayaKomissiyas = new List<CiklovayaKomissiya> {
    //  new CiklovayaKomissiya{ Id=1, Name="Информационные технологии"},
    //  new CiklovayaKomissiya{ Id=2, Name="Физкультура"},
    //  new CiklovayaKomissiya{ Id=3, Name="Естественные науки"}
    //};

    //private static List<DocumentType> documentTypes = new List<DocumentType> {
    //  new DocumentType{ Id=1, Name="Учебная программа"},
    //  new DocumentType{ Id=2, Name="Методическая разработка"},
    //  new DocumentType{ Id=3, Name="Электронный ресурс"}
    //};

    //private static List<Specialnost> specialnosts = new List<Specialnost> {
    //  new Specialnost{ Id=1, Name="ПОИТ", Code="1223554542"},
    //  new Specialnost{ Id=2, Name="ПМС", Code="4321254542"},
    //  new Specialnost{ Id=3, Name="ЭВС", Code="3223554542"}
    //};

    //private static List<ObrazovatelnyjStandart> obrazovatelnyjStandarts = new List<ObrazovatelnyjStandart>
    //{
    //  new ObrazovatelnyjStandart{Id=1, RegistarcionnyjNomer="129 33", SpecialnostId=1, Date=DateTime.Now},
    //  new ObrazovatelnyjStandart{Id=2, RegistarcionnyjNomer="329 33", SpecialnostId=2, Date=DateTime.Now},
    //  new ObrazovatelnyjStandart{Id=3, RegistarcionnyjNomer="145 33", SpecialnostId=3, Date=DateTime.Now}
    //};

    //private static List<TipovojUchebnyjPlan> tipovojUchebnyjPlans = new List<TipovojUchebnyjPlan>
    //{
    //  new TipovojUchebnyjPlan{Id=1,RegistarcionnyjNomer="2229 33", ObrazovatelnyjStandartId=1, Date=DateTime.Now},
    //  new TipovojUchebnyjPlan{Id=2,RegistarcionnyjNomer="33129 33", ObrazovatelnyjStandartId=2, Date=DateTime.Now},
    //  new TipovojUchebnyjPlan{Id=3,RegistarcionnyjNomer="14429 33", ObrazovatelnyjStandartId=3, Date=DateTime.Now}
    //};

    //private static List<UchebnyjPlan> uchebnyjPlans = new List<UchebnyjPlan>
    //{
    //  new UchebnyjPlan{ Id=1, TipovojUchebnyjPlanId=1, Date=DateTime.Now},
    //  new UchebnyjPlan{ Id=2, TipovojUchebnyjPlanId=2, Date=DateTime.Now},
    //  new UchebnyjPlan{ Id=3, TipovojUchebnyjPlanId=3, Date=DateTime.Now},
    //};

    //private static List<Group> groups = new List<Group> {
    //  new Group{ Id=1, Number="62491", SpecialnostId=1},
    //  new Group{ Id=2, Number="62492", SpecialnostId=1},
    //  new Group{ Id=3, Number="7k1391", SpecialnostId=2},
    //  new Group{ Id=4, Number="62191", SpecialnostId=3},
    //};

    //private static List<Teacher> teachers = new List<Teacher>
    //{
    //  new Teacher{Id=1, Surname="Иванова", Name="Лариса", FatherName="Ивановна", Category=Category.First, CiklovayaKomissiyaId=1, PositionId=1, Status=Status.Employee },
    //  new Teacher{Id=2, Surname="Синько", Name="Владислав", FatherName="Ильич", Category=Category.Second, CiklovayaKomissiyaId=2, PositionId=1, Status=Status.Employee },
    //  new Teacher{Id=3, Surname="Поддубный", Name="Игнат", FatherName="Васильевич", Category=Category.Second, CiklovayaKomissiyaId=3, PositionId=1, Status=Status.Employee },
    //  new Teacher{Id=4, Surname="Куц", Name="Мария", FatherName="Антоновна", Category=Category.Superior, CiklovayaKomissiyaId=1, PositionId=1, Status=Status.Employee },
    //  new Teacher{Id=5, Surname="Агнец", Name="Софья", FatherName="Павловна", Category=Category.First, CiklovayaKomissiyaId=2, PositionId=1, Status=Status.Employee },
    //  new Teacher{Id=6, Surname="Зиссер", Name="Юрий", FatherName="Юрьевич", Category=Category.First, CiklovayaKomissiyaId=1, PositionId=1, Status=Status.Employee },
    //  new Teacher{Id=7, Surname="Тирин", Name="Ксения", FatherName="Леопольдовна", Category=Category.First, CiklovayaKomissiyaId=1, PositionId=1, Status=Status.Employee },
    //};

    //private static List<UchebnayaDisciplina> uchebnayaDisciplinas = new List<UchebnayaDisciplina>
    //{
    //  new UchebnayaDisciplina{Id=1, Name="Математика", Component=Component.Obscheobrazovatelnyj, CiklovayaKomissiyaId=1, RegistarcionnyjNomer="22332", UchebnyjPlanId=1},
    //  new UchebnayaDisciplina{Id=2, Name="Информатика", Component=Component.Professonalnyj, CiklovayaKomissiyaId=1, RegistarcionnyjNomer="24332", UchebnyjPlanId=2},
    //  new UchebnayaDisciplina{Id=3, Name="Базы данных", Component=Component.Professonalnyj, CiklovayaKomissiyaId=2, RegistarcionnyjNomer="42332", UchebnyjPlanId=3},
    //  new UchebnayaDisciplina{Id=4, Name="Английсий язык", Component=Component.Professonalnyj, CiklovayaKomissiyaId=2, RegistarcionnyjNomer="522332", UchebnyjPlanId=1},
    //  new UchebnayaDisciplina{Id=5, Name="Русский язык", Component=Component.Obscheobrazovatelnyj, CiklovayaKomissiyaId=1, RegistarcionnyjNomer="442332", UchebnyjPlanId=2},
    //  new UchebnayaDisciplina{Id=6, Name="Компьютерные сети", Component=Component.Professonalnyj, CiklovayaKomissiyaId=2, RegistarcionnyjNomer="52332", UchebnyjPlanId=3},
    //  new UchebnayaDisciplina{Id=7, Name="Физкультура", Component=Component.Obscheobrazovatelnyj, CiklovayaKomissiyaId=3, RegistarcionnyjNomer="22332", UchebnyjPlanId=1},
    //};


    public static void Seed(this ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<IdentityRole>().HasData(roles);
      modelBuilder.Entity<IdentityUser>().HasData(GetAdminUser());
      modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
      //  modelBuilder.Entity<Specialnost>().HasData(specialnosts);
      //  modelBuilder.Entity<ObrazovatelnyjStandart>().HasData(obrazovatelnyjStandarts);
      //  modelBuilder.Entity<TipovojUchebnyjPlan>().HasData(tipovojUchebnyjPlans);
      //  modelBuilder.Entity<UchebnyjPlan>().HasData(uchebnyjPlans);
      ////  modelBuilder.Entity<Group>().HasData(groups);
      //  modelBuilder.Entity<Teacher>().HasData(teachers);
      //  modelBuilder.Entity<UchebnayaDisciplina>().HasData(uchebnayaDisciplinas);
    }
  }
}
