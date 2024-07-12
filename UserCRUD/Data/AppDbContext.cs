using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Mission> Missions { get; set; }
    public DbSet<MissionSkill> MissionSkills { get; set; }
    public DbSet<MissionTheme> MissionThemes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mission>()
            .HasKey(m => m.Id);

        modelBuilder.Entity<MissionSkill>()
            .HasKey(ms => ms.Id);

        modelBuilder.Entity<MissionTheme>()
            .HasKey(mt => mt.Id);

        modelBuilder.Entity<Mission>()
            .HasMany(m => m.MissionSkills)
            .WithOne(ms => ms.Mission)
            .HasForeignKey(ms => ms.MissionId);

        modelBuilder.Entity<MissionSkill>()
            .HasOne(ms => ms.Mission)
            .WithMany(m => m.MissionSkills)
            .HasForeignKey(ms => ms.MissionId);

        modelBuilder.Entity<Mission>()
            .HasMany(m => m.MissionThemes)
            .WithOne(mt => mt.Mission)
            .HasForeignKey(mt => mt.MissionId);

        modelBuilder.Entity<MissionTheme>()
            .HasOne(mt => mt.Mission)
            .WithMany(m => m.MissionThemes)
            .HasForeignKey(mt => mt.MissionId);
    }
}
