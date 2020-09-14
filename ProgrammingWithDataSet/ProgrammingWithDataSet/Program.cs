using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProgrammingWithDataSet
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
              Question 1 
             What is a DataSet ? 

             */
            Console.WriteLine("\n\n\n\tDataSet contains DataTableCollection and their DataRelationCollection ." +
                " It represents a complete set of data including the tables that contain, order, and constraint " +
                "the data, as well as the relationships between the tables.");
            /*Question 2
             
            Declare and create an object of type DataSet and name the object as CollegeDS.
            Display the name of the DataSet object on the screen*/

            DataSet dsCollege = new DataSet("CollegeDS");
            Console.WriteLine("\n\n\n\tThe name of the DataSet object : " + dsCollege.DataSetName);


            /*Question3
             
             Declare and create 3 DataTable objects and name the objects as Students, Courses,
             and StudentCourses respectively.

             */
            DataTable dtStudents = new DataTable("Students");
            DataTable dtCourses = new DataTable("Courses");
            DataTable dtStudentCourses = new DataTable("StudentCourses");

            /*Question 4 
            Add the three DataTable objects (Question 3) to the DataSet object 
            */
            dsCollege.Tables.Add("Students");
            dsCollege.Tables.Add("Courses");
            dsCollege.Tables.Add("StudentCourses");
            /*Question 5 
             Write a code segment to display the number of DataTable objects and all the names of the DataTable objects.*/
            Console.WriteLine("\n\n\ntThe number if DataTable object:" + dsCollege.Tables.Count);
            Console.WriteLine("The names of the datatable objects:");
            /*Console.WriteLine("\n\t" + dtCourses.TableName);
            Console.WriteLine("\n\t" + dtStudents.TableName);
            Console.WriteLine("\n\t" + dtStudentCourses.TableName);*/
            foreach (DataTable dt in dsCollege.Tables)
            {
                Console.WriteLine("\n\t" + dt.TableName);
            }



            /*
             Question 6 
              Write a code segment to define DataColumn objects for the DataTable object Students 
             name the DataColumn objects as StudentId, FirstName and LastName respectively and specify 
             the Data Type for each column.Set the DataColumn object StudentId as primary key. */
            

            DataColumn dcStudentId = new DataColumn("StudentId", typeof(Int32));
            DataColumn dcFirstName = new DataColumn("FirstName", typeof(String));
            DataColumn dcLastName = new DataColumn("LastName", typeof(String));
            dtStudents.Columns.Add(dcStudentId);
            dtStudents.Columns.Add(dcFirstName);
            dtStudents.Columns.Add(dcLastName);

            dtStudents.PrimaryKey = new DataColumn[] { dcStudentId };

            Console.WriteLine("\n\n\nDataTable name :" + dtStudents.TableName);
            Console.WriteLine("\n\n\tColumn Name\t\t\tData Type");
            Console.WriteLine("\n\n\t============\t\t\t============");
            foreach (DataColumn dc in dtStudents.Columns)
            {
                Console.WriteLine("\n\n\t"+dc.ColumnName+"\t\t\t" + dc.DataType);
            }
            /*Question 7 
             Write a code segment to populate the DataTable Students with the following data: */
             DataRow drRow = dtStudents.NewRow();
           /* drRow["StudentId"] = 111111;
            drRow["FirstName"] = 111111;
            drRow["Lastname"] = 111111;
           
            dtStudents.Rows.Add(dtRow);*/
            
            dtStudents.Rows.Add(111111,"john","Abbot");
            dtStudents.Rows.Add(222222,"Mary","Green");
            dtStudents.Rows.Add(333333,"Thomas","Moore");
            /*Write a code segment to define DataColumn objects for the DataTable object Courses ,
             name the DataColumn objects as CourseCode, CourseTitle and TotalHour respectively and 
             specify the Data Type for each column.
             Set the DataColumn object CourseCode as primary key*/
            DataColumn dcCourseCode = new DataColumn("CourseCode", typeof(String));
            DataColumn dcCourseTitle = new DataColumn("CourseTitle", typeof(String));
            DataColumn dcTotalHour = new DataColumn("TotalHour", typeof(Int32));
            dtCourses.Columns.Add(dcCourseCode);
            dtCourses.Columns.Add(dcCourseTitle);
            dtCourses.Columns.Add(dcTotalHour);
            dtCourses.PrimaryKey = new DataColumn[] { dtCourses.Columns["CourseCode"] };

            Console.WriteLine("\n\n\nDataTable name : " + dtCourses.TableName);
            Console.WriteLine("\n\n\tColumn Name\t\t\tData Type");
            Console.WriteLine("\n\n\t===========\t\t\t=========");
            foreach (DataColumn dc in dtCourses.Columns)
            {
                Console.WriteLine("\n\n\t" + dc.ColumnName + "\t\t\t" + dc.DataType);
            }

            //Question 9
            //Write a code segment to populate the DataTable Courses with the following data:
            //CourseCode CourseTitle TotalHour
            //420-P16-AS Structured Programming 90
            //420-P25-AS Introduction to Object Programing 75
            //420-P34-AS Advanced Object Programming 60
            //420-P46-AS Event Programming 90
            //420-P55-AS Internet Programming I 75
            Console.WriteLine("\t\t==========================================");
            dtCourses.Rows.Add("420-P16-AS", "Structured Programming", 90);
            dtCourses.Rows.Add("420-P25-AS", "Introduction to Object Programing", 75);
            dtCourses.Rows.Add("420-P34-AS", "Advanced object programming", 60);
            dtCourses.Rows.Add("420-P46-AS", "Event programming", 90);
            dtCourses.Rows.Add("420-P55-AS", "Internet programming I", 75);
            foreach (DataRow dr in dtCourses.Rows)
            {
                Console.WriteLine("\n\t" + dr["CourseCode"] + "\t\t\t" + dr["CourseTitle"] + "\t\t" + dr["TotalHour"]);
            }
            /*Write a code segment to define DataColumn objects for the DataTable object StudentCourses,
             name the DataColumn objects as StudentId and CourseCode, respectively and specify the Data Type 
             for each column.Set the DataColumn objects   StudentId  and CourseCode as primary key. */
            DataColumn dcStudentIdSC = new DataColumn("StudentId", typeof(Int32));
            DataColumn dcCourseCodeSC = new DataColumn("CourseCode", typeof(String));
            dtStudentCourses.Columns.Add(dcStudentIdSC);
            dtStudentCourses.Columns.Add(dcCourseCodeSC);

           
            dtStudentCourses.PrimaryKey = new DataColumn[] { dcStudentIdSC, dcCourseCodeSC };
           
            ForeignKeyConstraint fk1 = new ForeignKeyConstraint(dtStudents.Columns["StudentId"], dtStudentCourses.Columns["StudentId"]);
            ForeignKeyConstraint fk2 = new ForeignKeyConstraint(dtCourses.Columns["CourseCode"], dtStudentCourses.Columns["CourseCode"]);
            dtStudentCourses.Constraints.Add(fk1);
            dtStudentCourses.Constraints.Add(fk2);

            //DataColumn dcStudentIdSC = new DataColumn("StudentId", typeof(Int32));
            //DataColumn dcCourseCodeSC = new DataColumn("CourseCode", typeof(Int32));
            //dtStudentCourses.Columns.Add(dcStudentIdSC);
            //dtStudentCourses.Columns.Add(dcCourseCodeSC);

            // dsCollege.Relations.Add()

            //Question 11
            //Write a code segment to populate the DataTable StudentCourses with the following data:
            //1111111 420 - P16 - AS
            //2222222 420 - P16 - AS
            //1111111 420 - P25 - AS
            //2222222 420 - P25 - AS
            //3333333 420 - P34 - AS
            //3333333 420 - P55 - AS
            dtStudentCourses.Rows.Add(1111111, "420-P16-AS");
            dtStudentCourses.Rows.Add(1111111, "420-P25-AS");
            dtStudentCourses.Rows.Add(2222222, "420-P16-AS");
            dtStudentCourses.Rows.Add(2222222, "420-P25-AS");
            dtStudentCourses.Rows.Add(3333333, "420-P34-AS");
            dtStudentCourses.Rows.Add(3333333, "420-P55-AS");

            //Question 12
            //Write a code segment to display all the courses registered by a given student.
            //For example: List all the courses for the student John Abbot (StudentId : 1111111)
            // Note : information to be displayed : Course Code      Course Title     Total Hours

            Console.WriteLine("\n\n\n");
            foreach (DataRow drSC in dtStudentCourses.Rows)
            {
                if (Convert.ToInt32(drSC["StudentId"]) == 1111111)
                {
                    foreach (DataRow drC in dtCourses.Rows)
                    {
                        if (drSC["CourseCode"] == drC["CourseCode"])
                        {
                            Console.WriteLine("\n\t\t" + drC["CourseCode"] + "\t\t" + drC["CourseTitle"] + "\t\t" + drC["TotalHour"]);
                        }

                    }

                }

            }


            Console.ReadKey();

        }
    }
}
