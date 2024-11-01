using JpStudentAndCourse.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace JpStudentAndCourse.EntityFramework
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = Guid.NewGuid(), Name = "Alice Johnson", Email = "alice@example.com" },
                new Student { StudentId = Guid.NewGuid(), Name = "Bob Smith", Email = "bob@example.com" }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = Guid.NewGuid(), Title = "Math 101", Credits = 3 },
                new Course { CourseId = Guid.NewGuid(), Title = "History 201", Credits = 4 }
            );
        }
    }
}
