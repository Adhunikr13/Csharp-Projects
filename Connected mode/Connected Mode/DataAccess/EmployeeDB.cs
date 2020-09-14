using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Lab1_ConnectedMode.DataAccess;
using Lab1_ConnectedMode.Business;
using System.Windows.Forms;


namespace Lab1_ConnectedMode.DataAccess
{
  public static  class EmployeeDB
    {
        //public static void SaveRecord(Employee emp)
        //{
        //    //connect the database
        //    SqlConnection connDB = UtilityDB.ConnectDB();

        //    //create and customize the object of type SqlConnection
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = connDB;
        //    cmd.CommandText = "INSERT INTO Employee VALUES ("+emp.EmployeeId+",'"+emp.FirstName+"','"+emp.LastName+"','"+emp.JobTitle+"')";
        //    cmd.ExecuteNonQuery();

        //    //close the database
        //    connDB.Close() ;
        //}
       public static void SaveRecord(Employee emp)
        {
            //connect the database
            SqlConnection connDB = UtilityDB.ConnectDB();

            //create and customize the object
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
             
            cmd.CommandText = "INSERT INTO Employees(EmployeeId,FirstName,LastName,JobTitle)" +
                                " VALUES (@EmployeeId,@FirstName,@LastName,@JobTitle)";

            cmd.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
            cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmd.Parameters.AddWithValue("@LastName", emp.LastName);
            cmd.Parameters.AddWithValue("@JobTitle", emp.JobTitle);
            cmd.ExecuteNonQuery();

            //close the connection
            connDB.Close();
        }
        public static List<Employee> GetRecordList()
        {
            List<Employee> listEmp = new List<Employee>();
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Employees",connDB);
            SqlDataReader reader = cmd.ExecuteReader();
            Employee emp;

            if (reader.HasRows)
            {
                while (reader.Read())
                { 
                emp = new Employee();//create the object here, not outside
                emp.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                emp.FirstName = reader["FirstName"].ToString();
                emp.LastName = reader["LastName"].ToString();
                emp.JobTitle = reader["JobTitle"].ToString();
                listEmp.Add(emp);

                }
            }
            else
            {
                listEmp = null;
            }
            
            return listEmp;
        }
        public static bool IsUniqueId(int tempId)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "SELECT * FROM Employees " +
                             " WHERE EmployeeId =" + tempId;
            int id = Convert.ToInt32( cmd.ExecuteScalar());
            if (id != 0)
            {
                connDB.Close();
                return false;
            }
            connDB.Close();
            return true;
        }

        public static Employee SearchRecord(int searchId)
        {
            Employee emp = new Employee();
            SqlConnection sqlConn = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConn;
            cmd.CommandText = "SELECT * from Employees " +
                                "WHERE EmployeeId = @EmployeeId ";
            cmd.Parameters.AddWithValue("@EmployeeId",searchId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                emp.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                emp.FirstName = reader["FirstName"].ToString();
                emp.LastName = reader["LastName"].ToString();
                emp.JobTitle=reader["JobTitle"].ToString();

            }
            else
            {
                emp = null;
            }

            return emp;
        }
        public static List<Employee> SearchRecord(string input)
        {
            List<Employee> listEmp = new List<Employee>();
            List<Employee> listTemp = new List<Employee>();
            Employee emp = new Employee();
            listEmp = emp.GetEmployeeList();
            Employee emp2;
                if (listEmp !=null)
            {
                foreach (Employee anEmp in listEmp)
                {
                   // if (anEmp.FirstName.ToUpper() == input.ToUpper())
                    if ((input.ToUpper()== anEmp.FirstName.ToUpper()) || (input.ToUpper() ==anEmp.LastName.ToUpper()))
                        {
                        emp2 = new Employee();
                        emp2.EmployeeId = Convert.ToInt32(anEmp.EmployeeId);
                        emp2.FirstName = anEmp.FirstName;
                        emp2.LastName = anEmp.LastName;
                        emp2.JobTitle = anEmp.JobTitle;
                        listTemp.Add(emp2);
                    }
                }

            }

            return listTemp;


        }
        public static void UpdateRecord (Employee emp)
        {
            //connect the database
            SqlConnection connDB = UtilityDB.ConnectDB();

            //create and customize the object
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "Update Employees " +
                                "SET FirstName = @FirstName, " +
                                    "LastName = @LastName, " +
                                    "JobTitle = @JobTitle " +
                                    "WHERE EmployeeId = @EmployeeId ";
           // MessageBox.Show(cmd.CommandText);
            cmd.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
            cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmd.Parameters.AddWithValue("@LastName", emp.LastName);
            cmd.Parameters.AddWithValue("@JobTitle", emp.JobTitle);
            cmd.ExecuteNonQuery();

            //close connection
            connDB.Close();

        }

        public static void DeleteRecord(int id)
        {
            SqlConnection connDb = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDb;
            cmd.CommandText = "delete from Employees where EmployeeId = @EmployeeId";
            cmd.Parameters.AddWithValue("@EmployeeId", id);
            cmd.ExecuteNonQuery();
            connDb.Close();
        }

    }


}

