using EducationalCenter.Model;
using Microsoft.EntityFrameworkCore;

namespace EducationalCenter.Data
{
    public sealed class EducationalCenterContext: DbContext
    {
        public DbSet<Student> Students { get; set; }

        public EducationalCenterContext( DbContextOptions<EducationalCenterContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
