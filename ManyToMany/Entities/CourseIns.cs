using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToMany.Entities
{
    internal class CourseIns
    {
        public int InsId { get; set; }
        public int CourseId { get; set; }
        public decimal Evaluate { get; set; }
        public Course Course { get; set; }
        public Instructor instructor { get; set; }

    }
}