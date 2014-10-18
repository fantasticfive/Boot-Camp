using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentResultInfoApp.DAL.DAO
{
    public class Student
    {
        public string Student_RegNo { get; set; }
        public string  Student_Name { get; set; }
        public string Student_Email { get; set; }
        public string  Student_Course { get; set; }
        public string  Enroll_Date { get; set; }

        public Student(string regNo,string name,string email,string course,string date):this()
        {
            Student_RegNo = regNo;
            Student_Name = name;
            Student_Email = email;
            Student_Course = course;
            Enroll_Date = date;

        }

        public Student()
        {

        }
    }
}
