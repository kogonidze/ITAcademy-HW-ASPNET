using EducationalCenter.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace EducationalCenter.DataAccess.EF
{
    public sealed class EducationalCenterContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public EducationalCenterContext(DbContextOptions<EducationalCenterContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
