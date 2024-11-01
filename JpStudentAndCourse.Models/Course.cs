using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JpStudentAndCourse.Models
{
    public class Course
    {
        public Guid CourseId { get; set; }
        public string? Title { get; set; } 
        public int Credits { get; set; }
    }
}
