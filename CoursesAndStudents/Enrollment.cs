using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesAndStudents
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentID { get; set; }


        [ForeignKey(nameof(Student))]
        public int StudentID { get; set; }

        public virtual Student? Student { get; set; }


        [ForeignKey(nameof(Course))]
        public int CourseID { get; set; }

        public virtual Course? Course { get; set; }
    }


    public class Enrollment2
    {

        [Key]
        [ForeignKey(nameof(Student))]
        public int StudentID { get; set; }

        public virtual Student? Student { get; set; }


        [Key]
        [ForeignKey(nameof(Course))]
        public int CourseID { get; set; }

        public virtual Course? Course { get; set; }
    }
}
