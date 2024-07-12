using Microsoft.EntityFrameworkCore;
using MissionApi.Models;

namespace MissionApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Mission> Missions { get; set; }
        public DbSet<MissionTheme> MissionThemes { get; set; }
    }
}
