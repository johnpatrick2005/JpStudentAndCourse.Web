﻿// <auto-generated />
using System;
using JpStudentAndCourse.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JpStudentAndCourse.EntityFramework.Migrations
{
    [DbContext(typeof(DefaultDbContext))]
    partial class DefaultDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("JpStudentAndCourse.Models.Course", b =>
                {
                    b.Property<Guid>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = new Guid("e93a68e0-0da6-457e-aa06-9fe70eb9ef73"),
                            Credits = 3,
                            Title = "Math 101"
                        },
                        new
                        {
                            CourseId = new Guid("66e5658e-d236-4112-bfa7-5cb9d21df0d8"),
                            Credits = 4,
                            Title = "History 201"
                        });
                });

            modelBuilder.Entity("JpStudentAndCourse.Models.Student", b =>
                {
                    b.Property<Guid>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("CourseId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("StudentId");

                    b.HasIndex("CourseId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = new Guid("ceca5b65-004c-4eb0-98f1-10f7ca1c682b"),
                            Email = "alice@example.com",
                            Name = "Alice Johnson"
                        },
                        new
                        {
                            StudentId = new Guid("4aca3b20-bfe2-467a-8f60-6c04a7ad7848"),
                            Email = "bob@example.com",
                            Name = "Bob Smith"
                        });
                });

            modelBuilder.Entity("JpStudentAndCourse.Models.Student", b =>
                {
                    b.HasOne("JpStudentAndCourse.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId");

                    b.Navigation("Course");
                });
#pragma warning restore 612, 618
        }
    }
}
