using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToMany.Entities
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? Age { get; set; }
       // public ICollection<Course> Courses { get; set; } = new HashSet<Course>();//Navigational property(Many)

        
        public ICollection<StudentCourse> studentCourses { get; set; } = new HashSet<StudentCourse>();
    }
}
