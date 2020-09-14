using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab3_DisconnectedMode.BLL;

namespace Lab3_DisconnectedMode.GUI
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        private void buttonListStudent_Click(object sender, EventArgs e)
        {
            Student aStudent = new Student();
            dataGridViewStudent.DataSource = aStudent.ListStudent();
           

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int searchId = Convert.ToInt32(textBoxStudentId.Text);
            foreach (DataRow dr in dtStudents.Rows)
            {
               
                if (searchId == Convert.ToInt32(dr["StudentId"]))
                {
                    textBoxStudentId.Text = dr["StudentId"].ToString();
                    textBoxFirstName.Text = dr["FirstName"].ToString();
                    textBoxLastName.Text = dr["LastName"].ToString();
                    textBoxEmail.Text = dr["Email"].ToString();
                    break;
                }
            }
            MessageBox.Show("Student not found!","Invalid Student Id",MessageBoxButtons.OK,)
        }

        private void buttonUpdateDB_Click(object sender, EventArgs e)
        {
            sqlBuilder
        }
    }
}
