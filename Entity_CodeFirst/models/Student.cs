using System;
using System.Collections.Generic;
using System.Text;

namespace Entity_CodeFirst.models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}
