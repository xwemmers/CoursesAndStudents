using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesAndStudents
{
    public class Course
    {
        public Course()
        {
            this.Enrollments = new HashSet<Enrollment>();
        }

        public int CourseID { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
