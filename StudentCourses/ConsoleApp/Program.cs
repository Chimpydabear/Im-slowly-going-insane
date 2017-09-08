using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.SqlTypes;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            DataGenerator.GenerateName();
            IRepository<StudentModel> studrepo = new SQLStudentRepository();
            IRepository<CourseModel> courserepo = new SQLCourseRepository();
            IRepository<TeacherModel> teacherrepo = new SQLTeacherRepository();

            Console.WriteLine("Press 1 for students, press 2 for teachers, press 3 for courses");
            Console.Write("Please enter your selection: ");

            string caseswitch = Console.ReadLine();

            switch (caseswitch)
            {
                case "1":
                    var student = studrepo.GetByID(1, caseswitch);
                    Console.WriteLine("ID: " + student.StudentId);
                    Console.WriteLine("Student name: " + student.FirstName + " " + student.LastName);
                    Console.WriteLine("Date of birth: " + student.DateOfBirth);
                    break;

                case "2":
                    var teacher = teacherrepo.GetByID(1, caseswitch);
                    Console.WriteLine("ID: " + teacher.TeacherId);
                    Console.WriteLine("Name: " + teacher.TeacherName);
                    break;

                case "3":
                    var course = courserepo.GetByID(1, caseswitch);
                    Console.WriteLine("ID: " + course.CourseId);
                    Console.WriteLine("Description: " + course.Description);
                    break;

                default:
                    Console.WriteLine("Please enter a valid number");
                    Console.ReadLine();
                    break;
            }

            Console.WriteLine("Press any key to terminate the program");
            Console.ReadKey();
        }
        public static void AddData()
        {
        }
    }

}
