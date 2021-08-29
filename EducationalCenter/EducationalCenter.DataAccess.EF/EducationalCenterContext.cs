using EducationalCenter.Common.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EducationalCenter.DataAccess.EF
{
    public sealed class EducationalCenterContext : IdentityDbContext
    {
        public DbSet<Student> Students { get; set; }

        public EducationalCenterContext(DbContextOptions<EducationalCenterContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
