using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JpStudentAndCourse.Models
{
    public class Student
    {
        public Guid StudentId { get; set; }
        public string? Name { get; set; } 
        public string? Email { get; set; } 
        public Course? Course { get; set; }
    }
}
