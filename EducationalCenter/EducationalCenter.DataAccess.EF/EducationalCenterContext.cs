using EducationalCenter.Common.Models;
using EducationalCenter.DataAccess.EF.Extensions;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EducationalCenter.DataAccess.EF
{
    public sealed class EducationalCenterContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<StudentGroup> StudentGroups { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Faculty> Faculties { get; set; }

        public DbSet<Lecture> Lectures { get; set; }

        public DbSet<Log> Logs { get; set; }

        public EducationalCenterContext(DbContextOptions<EducationalCenterContext> options,
            IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Seed();
        }
    }
}
