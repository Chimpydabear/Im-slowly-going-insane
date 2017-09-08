using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class SQLCourseRepository : IRepository<CourseModel>
    {

        public IEnumerable<StudentModel> All { get; }

        IEnumerable<CourseModel> IRepository<CourseModel>.All => throw new NotImplementedException();

        public void AddData(StudentModel model)
        {
            throw new NotImplementedException();
        }

        public void AddData(CourseModel model)
        {
            throw new NotImplementedException();
        }

        public CourseModel GetByID(int id, string s)
        {
            var course = new CourseModel();


            var connection = new SqlConnectionStringBuilder()
            {
                DataSource = "localhost",
                IntegratedSecurity = true,
                ConnectTimeout = 30,
                InitialCatalog = "StudentCourses"
            };

            using (SqlConnection conn = new SqlConnection(connection.ToString()))
            {
                conn.Open();

                string sql = ("SELECT TOP 1 * FROM Courses");
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    SqlDataReader rdr = command.ExecuteReader();
                    {
                        if (rdr != null)
                        {
                            rdr.Read();
                            course.CourseId = rdr[0].ToString();
                            course.Description = rdr[1].ToString();
                            Console.WriteLine(course);
                        }
                    }
                }
            }
            return course;
        }
    }
}

