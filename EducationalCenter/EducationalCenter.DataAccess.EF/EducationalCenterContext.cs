﻿using EducationalCenter.Common.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EducationalCenter.DataAccess.EF
{
    public sealed class EducationalCenterContext : IdentityDbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<StudentGroup> StudentGroups { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Faculty> Faculties { get; set; }

        public DbSet<Lecture> Lectures { get; set; }

        public EducationalCenterContext(DbContextOptions<EducationalCenterContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Department>().HasData(new Department { Id = 1, Name = "Philology" });
            builder.Entity<Department>().HasData(new Department { Id = 2, Name = "Algebras" });

            builder.Entity<Faculty>().HasData(new Faculty { Id = 1, Name = "Applied Math" });
            builder.Entity<Faculty>().HasData(new Faculty { Id = 2, Name = "Information technologies" });
        }
    }
}
