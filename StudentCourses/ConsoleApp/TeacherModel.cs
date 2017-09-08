using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class TeacherModel
    {
        public string TeacherId { get; set; }
        public string TeacherName { get; set; }
        public List<StudentModel> Students { get; set; }
    }
}
