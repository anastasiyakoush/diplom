using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.DAL
{
  public class ApplicationContext : DbContext
  {
    public ApplicationContext(DbContextOptions options) : base(options) { }

    public DbSet<CiklovayaKomissiya> CiklovyeKomissii { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<DocumentAuthor> DocumentsAuthors { get; set; }
    public DbSet<DocumentType> DocumentTypes { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<ObrazovatelnyjStandart> ObrazovatelnyeStandarty { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<PublicLesson> PublicLessons { get; set; }
    public DbSet<Specialnost> Specialnosti { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<TipovojUchebnyjPlan> TipovyeUchebnyePlany { get; set; }
    public DbSet<UchebnayaDisciplina> UchebnyeDiscipliny { get; set; }
    public DbSet<UchebnyjPlan> UchebnyePlany { get; set; }
    public DbSet<PlanningPublicLesson> PlanningPublicLessons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<DocumentAuthor>().HasKey(x => new { x.TeacherId, x.DocumentId });

      modelBuilder.Entity<DocumentAuthor>()
          .HasOne(x => x.Teacher)
          .WithMany(x => x.DocumentAuthors)
          .HasForeignKey(x => x.TeacherId);

      modelBuilder.Entity<DocumentAuthor>()
          .HasOne(x => x.Document)
          .WithMany(x => x.DocumentAuthors)
          .HasForeignKey(x => x.DocumentId);

      modelBuilder.Entity<Teacher>()
        .HasOne(x => x.CiklovayaKomissiya)
        .WithMany(x => x.Teachers)
        .OnDelete(DeleteBehavior.SetNull);

      modelBuilder.Entity<Teacher>()
        .HasOne(x => x.Position)
        .WithMany(x => x.Teachers)
        .OnDelete(DeleteBehavior.SetNull);

      modelBuilder.Entity<UchebnayaDisciplina>()
        .HasOne(x => x.UchebnyjPlan)
        .WithMany(x => x.UchebnayaDisciplinas)
        .OnDelete(DeleteBehavior.SetNull);

      modelBuilder.Entity<UchebnayaDisciplina>()
        .HasOne(x => x.CiklovayaKomissiya)
        .WithMany(x => x.UchebnayaDisciplinas)
        .OnDelete(DeleteBehavior.SetNull);

      modelBuilder.Entity<Document>()
        .HasOne(x => x.DocumentType)
        .WithMany(x => x.Documents)
        .OnDelete(DeleteBehavior.SetNull);

      modelBuilder.Entity<PublicLesson>()
        .HasOne(x => x.Group)
        .WithMany(x => x.PublicLessons)
        .OnDelete(DeleteBehavior.SetNull);

      modelBuilder.Entity<ObrazovatelnyjStandart>()
        .HasOne(x => x.Specialnost)
        .WithMany(x => x.ObrazovatelnyjStandarts)
        .OnDelete(DeleteBehavior.SetNull);

      modelBuilder.Entity<UchebnyjPlan>()
        .HasOne(x => x.TipovojUchebnyjPlan)
        .WithMany(x => x.UchebnyjPlans)
        .OnDelete(DeleteBehavior.SetNull);

      modelBuilder.Entity<TipovojUchebnyjPlan>()
        .HasOne(x => x.ObrazovatelnyjStandart)
        .WithMany(x => x.TipovojUchebnyjPlans)
        .OnDelete(DeleteBehavior.SetNull);

      modelBuilder.Entity<Group>()
        .HasOne(x => x.UchebnyjPlan)
        .WithMany(x => x.Groups)
        .OnDelete(DeleteBehavior.SetNull);
    }
  }
}
