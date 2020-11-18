using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Models
{
    public class TeacherStudent
    {
        public int StudentId { get; set; } //foreign key property
        public Student Student { get; set; } //Reference navigation property
        public int TeacherId { get; set; }//foreign key property
        public Teacher Teacher { get; set; }
    }
}
