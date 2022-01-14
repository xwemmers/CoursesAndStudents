using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesAndStudents
{
    public class Student
    {
        public Student()
        {
            this.Enrollments = new HashSet<Enrollment>();
        }


        public int StudentID { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
