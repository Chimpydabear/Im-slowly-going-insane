using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public static class DataGenerator
    {
        public static string GenerateName()
        {
            //List<string> FirstNames = new List<string>();
            //FirstNames.Add();

            //string 

            var allMyName = "AAAA,BBBB,CCCC,DDDD,FFFF,GGGG,HHHH,JJJJ,KKKK,LLLL,MMMM,NNNN,OOOO,PPPP,QQQQ,RRRR,SSSS,TTTT,UUUU";

            string[] firstnames = allMyName.Split(',');

            var muh = firstnames.ToList();
            var numberOfElements = muh.Count();

            var allMyLastName = "AAEE,AAII,AAOO,EEII,EEOO,EEAA,IIOO,IIEE,IIAA,OOEE,OOII,OOAA";
            string[] lastnames = allMyLastName.Split(',');
            var meh = allMyLastName.ToList();
            var numberofLastNames = meh.Count();
            // List<string> LastNames = new List<string>();
            // LastNames.Add();

            List<int> Id = new List<int>();
            Random rng = new Random();
            for (int i = 0; i < 10; i++)
            {
                Id.Add(rng.Next(1000, 10000));
            }

            List<DateTime> DateOfBirth = new List<DateTime>();
            Random rngdate = new Random();
            DateTime RandomDay()
            {
                DateTime start = new DateTime(1990, 1, 1);
                int range = (DateTime.Today - start).Days;
                for (int a = 0; a < 10; a++)
                {
                    DateOfBirth.Add(start.AddDays(rngdate.Next(range)));

                }
                return start.AddDays(rngdate.Next(range));
            }

            var connection = new SqlConnectionStringBuilder()
            {
                DataSource = "localhost",
                IntegratedSecurity = true,
                ConnectTimeout = 30,
                InitialCatalog = "StudentCourses"
            };

            List<int> TeacherId = new List<int>();

            using (SqlConnection conn = new SqlConnection(connection.ToString()))
            {
                conn.Open();

                string sqlteach = ("SELECT Id FROM Teachers");
                var cmd = new SqlCommand(sqlteach, conn);
                cmd.CommandType = System.Data.CommandType.Text;
                using (SqlDataReader TeacherID = cmd.ExecuteReader())
                {
                    if (TeacherID.HasRows)
                    {
                        while (TeacherID.Read())
                        {
                            int TID = TeacherID.GetInt32(TeacherID.GetOrdinal("Id"));
                            TeacherId.Add(TID);
                        }
                    }
                }
                private static Random randTID = new Random();
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = randTID.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    
                using (SqlCommand command = new SqlCommand("INSERT INTO Students (FirstName, TeacherId) VALUES (@FirstName)", conn))
                {
                    //command.Parameters.AddWithValue(@Id, I);
                    command.Parameters.AddWithValue("@FirstName", muh.First());
                    //command.Parameters.AddWithValue("@LastName", LastNames.First());
                    //command.Parameters.AddWithValue("@DateOfBirth", RandomDay().ToString());
                    //command.Parameters.AddWithValue(@TeacherId, TeacherId.ToString());
                    command.ExecuteNonQuery();
                    conn.Close();
                }

                return "";
       


