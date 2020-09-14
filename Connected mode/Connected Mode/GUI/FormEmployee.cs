using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab1_ConnectedMode.Validation;
using Lab1_ConnectedMode.Business;

namespace Lab1_ConnectedMode.GUI
{
    public partial class FormEmployee : Form
    {
        public FormEmployee()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure", "you want to exit", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();

            }
            else
            {
                return;
            }

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(UtilityDB.ConnectDB().State.ToString());
            string input = "";
            Employee emp = new Employee();
            input = textBoxEmpId.Text.Trim();
            if (!Validator.IsValidId(input, 4))
            {
                textBoxEmpId.Clear();
                textBoxEmpId.Focus();
                return;

            }
            int tempId= Convert.ToInt32(textBoxEmpId.Text.Trim());
            if (!(emp.IsUniqueEmployeeId(tempId)))
            {
                MessageBox.Show("This Employee ID already exists!","Duplicate Employee ID",MessageBoxButtons.OK,MessageBoxIcon.Error);
                textBoxEmpId.Clear();
                textBoxEmpId.Focus();
                return;
            }

            input = textBoxFirstName.Text.Trim();
            if (!(Validator.IsValidName(input)))
            {
                textBoxFirstName.Clear();
                textBoxFirstName.Focus();
                return;

            }


            input = textBoxLastName.Text.Trim();
            if (!(Validator.IsValidName(input)))
            {
                textBoxLastName.Clear();
                textBoxLastName.Focus();
                return;
            }

            input = textBoxJobTitle.Text.Trim();
            if (!(Validator.IsValidName(input)))
            {
                textBoxJobTitle.Clear();
                textBoxJobTitle.Focus();
                return;
            }

            // valid data
           // Employee emp = new Employee();
            emp.EmployeeId = Convert.ToInt32(textBoxEmpId.Text.Trim());
            emp.FirstName = textBoxFirstName.Text.Trim();
            emp.LastName = textBoxLastName.Text.Trim();
            emp.JobTitle = textBoxJobTitle.Text.Trim();
            emp.SaveEmployee(emp);
            MessageBox.Show("Employee record has been saved successfully.", "Employee Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
    

           

        }

        private void buttonListAll_Click(object sender, EventArgs e)
        {
            listViewEmployee.Items.Clear();
            Employee emp = new Employee();
            List<Employee> listEmp = emp.GetEmployeeList();
           if (listEmp != null)
            {
                foreach (Employee empItem in listEmp)
                {
                    ListViewItem item = new ListViewItem(empItem.EmployeeId.ToString());
                    item.SubItems.Add(empItem.FirstName);
                    item.SubItems.Add(empItem.LastName);
                    item.SubItems.Add(empItem.JobTitle);
                    listViewEmployee.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("No Employee Data in the database.", "No Employee Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }

        }

        private void comboBoxOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexSelected = comboBoxOption.SelectedIndex;
            switch (indexSelected)
            {
                case 1: //search by EmployeeId
                    labelMessage.Text = "Please enter Employee Id";
                    textBoxInput.Clear();
                    textBoxInput.Focus();
                    break;
                case 2: //search by FirstName
                    labelMessage.Text = "Please enter First Name";
                    textBoxInput.Clear();
                    textBoxInput.Focus();
                    break;
                case 3://search by LastName
                    labelMessage.Text = "Please enter Last Name";
                    textBoxInput.Clear();
                    textBoxInput.Focus();
                    break;
                default:
                    labelMessage.Text = "Please select the search option";
                    break;
               
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int selectedIndex = comboBoxOption.SelectedIndex;

            switch (selectedIndex)
            {
                case 1://search by Employee ID
                    if (!(Validator.IsValidId(textBoxInput.Text.Trim())))
                    {
                        textBoxInput.Clear();
                        textBoxInput.Focus();
                        return;
                    }
                    Employee emp = new Employee();
                    emp = emp.SearchEmployee(Convert.ToInt32(textBoxInput.Text.Trim()));
                    if (emp != null)
                    {
                        textBoxEmpId.Text = emp.EmployeeId.ToString();
                        textBoxFirstName.Text = emp.FirstName;
                        textBoxLastName.Text = emp.LastName;
                        textBoxJobTitle.Text = emp.JobTitle;
                    }
                    else
                    {
                        textBoxInput.Clear();
                        textBoxInput.Focus();
                        string error = "Record not found !" + "\n" + "Please enter Employee Id again.";
                        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
                case 2: //search by First Name
                    if (!(Validator.IsValidName(textBoxInput.Text.Trim())))
                    {
                        textBoxInput.Clear();
                        textBoxInput.Focus();
                        return;
                    }
                    Employee tempEmp = new Employee();
                    List<Employee> listTemp = tempEmp.SearchEmployee(textBoxInput.Text.Trim());
                    listViewEmployee.Items.Clear();
                    if (listTemp !=null)
                    {
                        foreach (Employee anEmp in listTemp)
                        {
                            ListViewItem item = new ListViewItem(anEmp.EmployeeId.ToString());
                            item.SubItems.Add(anEmp.FirstName);
                            item.SubItems.Add(anEmp.LastName);
                            item.SubItems.Add(anEmp.JobTitle);
                            listViewEmployee.Items.Add(item);
                        }

                    }
                    else
                    {

                    }
                    break;
                case 3: //search by Last Name
                    if (!(Validator.IsValidName(textBoxInput.Text.Trim())))
                    {
                        textBoxInput.Clear();
                        textBoxInput.Focus();
                        return;
                    }
                    Employee tempEmp2 = new Employee();
                    List<Employee> listTemp2 = tempEmp2.SearchEmployee(textBoxInput.Text.Trim());
                    listViewEmployee.Items.Clear();
                    if (listTemp2 != null)
                    {
                        foreach (Employee anEmp in listTemp2)
                        {
                            ListViewItem item = new ListViewItem(anEmp.EmployeeId.ToString());
                            item.SubItems.Add(anEmp.FirstName);
                            item.SubItems.Add(anEmp.LastName);
                            item.SubItems.Add(anEmp.JobTitle);
                            listViewEmployee.Items.Add(item);
                        }

                    }
                    else
                    {

                    }
                    break;
                default:
                    break;
            }

            


        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string input = "";
            Employee emp = new Employee();
            input = textBoxEmpId.Text.Trim();
            if (!Validator.IsValidId(input, 4))
            {
                textBoxEmpId.Clear();
                textBoxEmpId.Focus();
                return;

            }
            emp.EmployeeId = Convert.ToInt32(textBoxEmpId.Text.Trim());
            emp.FirstName = textBoxFirstName.Text.Trim();
            emp.LastName = textBoxLastName.Text.Trim();
            emp.JobTitle = textBoxJobTitle.Text.Trim();

            emp.UpdateEmployee(emp);

            MessageBox.Show("Employee Record updated successfully!","Update Record",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure", "You want to delete?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Employee emp = new Employee();
                emp.DeleteEmployee(Convert.ToInt32(textBoxEmpId.Text));
                MessageBox.Show("Employee Record deleted successfully!", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                return;
            }
        }

        private void pictureBoxPhoto_Click(object sender, EventArgs e)
        {

        }
    }
}
