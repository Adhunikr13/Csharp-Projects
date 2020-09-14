using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3_DisconnectedMode.BLL;
using System.Data.SqlClient;

namespace Lab3_DisconnectedMode.DAL
{
    public static class StudentDB
    {
        public static List<Student> ListRecord()
        {
            List<Student> listS = new List<Student>();
            Student aStudent;
            SqlConnection connDb = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Students",connDb );
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    aStudent = new Student();
                    aStudent.StudentId = Convert.ToInt32(reader["StudentId"]);
                    aStudent.FirstName = reader["FirstName"].ToString();
                    aStudent.LastName = reader["LastName"].ToString();
                    aStudent.Email = reader["Email"].ToString();
                    listS.Add(aStudent);
                }

            }
            else
            {
                listS = null;
            }
            connDb.Close();
            return listS;
        }

    }
}
