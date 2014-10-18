using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentResultInfoApp.DAL.DAO;
using StudentResultInfoApp.DAL.GATEWAY;

namespace StudentResultInfoApp.BLL
{
    class StudentBLL
    {
        StudentGateway aStudentGateway =new StudentGateway();
        public string Save(Student aStudent)
        {
            if (aStudent.Student_RegNo == string.Empty || aStudent.Student_Name == string.Empty || aStudent.Student_Email == string.Empty || aStudent.Student_Course==string.Empty|| aStudent.Enroll_Date ==string.Empty)
            {
                return "please fill up all field";
            }
            else
            {
                if (!HasThisRegNoValid(aStudent.Student_RegNo))
                {
                    return aStudentGateway.Save(aStudent);
                }
                else
                {
                    return "RegNo address already exist";
                }


            }
        }

        private bool HasThisRegNoValid(string studentRegNo)
        {
            return aStudentGateway.HasThisRegNoValid(studentRegNo);
        }
    }
}
