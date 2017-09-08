using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;


namespace ConsoleApp
{
    public class SQLStudentRepository : IRepository<StudentModel>
    {

        public IEnumerable<StudentModel> All { get; }


        public void AddData(StudentModel model)
        {
            throw new NotImplementedException();
        }

        public StudentModel GetByID(int id, string s)
        {
            var student = new StudentModel();
            

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

                    string sql = ("SELECT TOP 1 * FROM Students");
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        command.CommandType = System.Data.CommandType.Text;
                        SqlDataReader rdr = command.ExecuteReader();
                        {
                            if (rdr != null)
                            {
                                rdr.Read();
                                student.StudentId = rdr[0].ToString();
                                student.FirstName = rdr[1].ToString();
                                student.LastName = rdr[2].ToString();
                                student.DateOfBirth = rdr[3].ToString();
                                Console.WriteLine(student);
                            }
                        }
                    }
                }
            return student;
            }
        }
    }

