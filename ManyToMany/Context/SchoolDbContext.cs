using ManyToMany.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToMany.Context
{
    internal class SchoolDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = . ; DataBase = School ; Trusted_Connection = true ; Encrypt = False");
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Course { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //1st way
            //modelBuilder.Entity<Student>()
            //    .HasMany(S => S.Courses)
            //    .WithMany(C => C.Students);//there is no representation  for many to many relation in DB

            //make composite primary key
            modelBuilder.Entity<StudentCourse>()
                .HasKey(SC => new { SC.StudentId, SC.CourseId });
            //Relations bet entities and Relation ENtity
            modelBuilder.Entity<Course>().HasMany(S => S.studentCourses)
                                         .WithOne(SC => SC.Course)
                                         .IsRequired(true)//should have a value
                                         .HasForeignKey(SC => SC.CourseId);

            modelBuilder.Entity<Student>().HasMany(S => S.studentCourses)
                                        .WithOne(SC => SC.Student)
                                        .IsRequired(true)//should have a value
                                        .HasForeignKey(SC => SC.StudentId);

            modelBuilder.Entity<CourseIns>()
               .HasKey(SC => new { SC.CourseId, SC.InsId });

            modelBuilder.Entity<Instructor>().HasMany(S => S.CourseIns)
                                             .WithOne(C => C.instructor)
                                             .IsRequired(true)
                                             .HasForeignKey(I => I.InsId);
            modelBuilder.Entity<Course>().HasMany(S => S.courseIns)
                                        .WithOne(SC => SC.Course)
                                        .IsRequired(true)//should have a value
                                        .HasForeignKey(SC => SC.CourseId);



            base.OnModelCreating(modelBuilder);
        }
    }

}
