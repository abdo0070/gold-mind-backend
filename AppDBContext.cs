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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(d => d.Doctor)
                .WithMany(u => u.patients)
                .HasForeignKey(u => u.DoctorId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
