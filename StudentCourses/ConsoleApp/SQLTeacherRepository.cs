using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class SQLTeacherRepository : IRepository<TeacherModel>
    {
        public IEnumerable<TeacherModel> All => throw new NotImplementedException();

        public void AddData(TeacherModel model)
        {
            throw new NotImplementedException();
        }

        public TeacherModel GetByID(int id, string s)
        {
            var teacher = new TeacherModel();

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

                string sql = ("SELECT TOP 1 * FROM Teachers");
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    SqlDataReader rdr = command.ExecuteReader();
                    {
                        if (rdr != null)
                        {
                            rdr.Read();
                            teacher.TeacherId = rdr[0].ToString();
                            teacher.TeacherName = rdr[1].ToString();
                            Console.WriteLine(teacher);
                        }
                    }
                }
            }
            return teacher;
        }
    }
}
