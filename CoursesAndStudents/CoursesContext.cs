using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesAndStudents
{
    class CoursesContext : DbContext
    {
        public CoursesContext() 
        {
            Database.EnsureCreated();
        }

        public DbSet<Course>? Courses { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<Enrollment>? Enrollments { get; set; }
        public DbSet<Enrollment2>? Enrollments2 { get; set; }

        // Dit project is hier te downloaden:
        // https://www.xanderwemmers.nl/CoursesAndStudents.zip


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Check bij jezelf even wat de juiste Data Source zou moeten zijn...
            optionsBuilder.UseSqlServer(@"Data Source=.\sqlexpress; Initial Catalog=CoursesCompany; Integrated Security=True").UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var st1 = new Student { StudentID = 1, Firstname = "Harald", Lastname = "" };
            var st2 = new Student { StudentID = 2, Firstname = "Nina", Lastname = "" };
            var st3 = new Student { StudentID = 3, Firstname = "Koen", Lastname = "" };
            var st4 = new Student { StudentID = 4, Firstname = "Hans-Peter", Lastname = "" };
            var st5 = new Student { StudentID = 5, Firstname = "Reinier", Lastname = "" };
            var st6 = new Student { StudentID = 6, Firstname = "Klaas", Lastname = "" };
            var st7 = new Student { StudentID = 7, Firstname = "Stefan", Lastname = "" };
            var st8 = new Student { StudentID = 8, Firstname = "Johan", Lastname = "" };
            var st9 = new Student { StudentID = 9, Firstname = "Tom", Lastname = "" };
            var st10 = new Student { StudentID = 10, Firstname = "Hendrik-Jan", Lastname = "" };

            var c1 = new Course { CourseID = 1, Name = "ASP.NET" };
            var c2 = new Course { CourseID = 2, Name = "HTML" };
            var c3 = new Course { CourseID = 3, Name = "Xamarin" };
            var c4 = new Course { CourseID = 4, Name = "Angular" };
            var c5 = new Course { CourseID = 5, Name = "Blazor"};

            var en1 = new Enrollment { EnrollmentID = 1, CourseID = 2, StudentID = 3 };
            var en2 = new Enrollment { EnrollmentID = 2, CourseID = 3, StudentID = 9 };
            var en3 = new Enrollment { EnrollmentID = 3, CourseID = 5, StudentID = 7 };

            // Dit werkt helaas niet...
            // Tijdens het seeden moet je altijd gebruik maken van de IDs
            var en4 = new Enrollment { EnrollmentID = 4, Course = c4, Student = st7 };

            modelBuilder.Entity<Student>().HasData(st1, st2, st3, st4, st5, st6, st7, st8, st9, st10);
            modelBuilder.Entity<Course>().HasData(c1, c2, c3, c4, c5);
            modelBuilder.Entity<Enrollment>().HasData(en1, en2, en3);

            // Omdat dit een samengestelde key is moet het in deze Fluent API
            // Dit kan niet met Data Annotations in de class zelf
            modelBuilder.Entity<Enrollment2>().HasKey(x => new { x.CourseID, x.StudentID });

            var en5 = new Enrollment2 { CourseID = 1, StudentID = 1 };
            modelBuilder.Entity<Enrollment2>().HasData(en5);



            // Dit werkt niet in deze seed functie
            //c1.Students.Add(st1);
            //st1.Courses.Add(c1);
        }
    }
}
