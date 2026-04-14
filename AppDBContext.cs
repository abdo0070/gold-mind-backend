using GoldenMind.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldenMind
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions opt) : base(opt)
        {
        }
        public DbSet<Patient> patiens { get; set; }
        public DbSet<CareGaver> careGavers { get; set; }
        public DbSet<Alarms> alarms { get; set; }

    }
}
