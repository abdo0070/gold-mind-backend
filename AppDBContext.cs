using GoldenMind.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldenMind
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> users { get; set; }
        public DbSet<DoctorModel> doctors { get; set; }
    }
}
