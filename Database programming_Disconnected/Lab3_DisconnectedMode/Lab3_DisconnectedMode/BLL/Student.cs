using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3_DisconnectedMode.DAL;

namespace Lab3_DisconnectedMode.BLL
{
    public class Student
    {
        private int studentId;
        private string firstName;
        private string lastName;
        private string email;

        public int StudentId { get => studentId; set => studentId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public List<Student> ListStudent()
        {
            return (StudentDB.ListRecord());
        }
    }
}
