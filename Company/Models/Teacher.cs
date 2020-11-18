using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<TeacherStudent> TeacherStudent { get; set; }
    }
}
