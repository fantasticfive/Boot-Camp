using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentResultInfoApp.DAL.DAO;
using StudentResultInfoApp.DAL.GATEWAY;

namespace StudentResultInfoApp.BLL
{
    class StudentBLL
    {
		

	
        StudentGateway aStudentGateway =new StudentGateway();
        public string Save(Student aStudent)
        {
            if (aStudent.StudentRegNo == string.Empty 
                || aStudent.StudentName == string.Empty 
                || aStudent.StudentEmail == string.Empty 
                || aStudent.StudentCourse==string.Empty
                || aStudent.EnrollDate ==string.Empty)
            {
                return "please fill up all field";
            }
            else
            {
                if (HasThisRegNoValid(aStudent.StudentRegNo))
                {


                    return aStudentGateway.Save(aStudent);
                   
                    
                }
                else
                {
                    return "RegNo not exist";
                }


            }
        }




        private bool HasThisRegNoValid(string studentRegNo)
        {
            return aStudentGateway.HasThisRegNoValid(studentRegNo);
        }



        public Student FindStudent(Student aStudent)
        {
           
            Student nowInUiStudent = new Student();


            aStudent = aStudentGateway.FindStudent(aStudent);

            return aStudent;
        }

        public bool CheckForResultUi(string studentScorePersent)
        {
            if (studentScorePersent == string.Empty)
            {
                return false;
            }
            return true;
        }

        public string SaveForResultUi(Student aStudent, Result aResult)
        {

           

            if (aStudent.StudentRegNo == string.Empty
               || aStudent.StudentName == string.Empty
               || aStudent.StudentEmail == string.Empty
               || aStudent.StudentCourse == string.Empty
               || aStudent.EnrollDate == string.Empty)
            {
                return "please fill up all field";
            }
            else
            {
                if (!HasThisRegNoValid(aStudent.StudentRegNo))
                {
                    return "RegNo address already exist";
                }
                else
                {
                    return aStudentGateway.SaveForResultUi(aStudent);
                   
                }


            }
        }

        public List<Student> ShoInListViewFromDB(Student aStudent1)
        {
            List<Student> students = new List<Student>();
            
			ListViewItem item2 = new ListViewItem();
		
			ListViewItem item = new ListViewItem();
            StudentBLL aStudentBll;

            students = aStudentBll.ShowStudentInfoListView();
            foreach (Student aStudent in students)
            {
                item.Text = aStudent.ToString();
                item.SubItems.Add(aStudent.ToString());

            }

            studentEnrollCourseListView.Items.Add(item.ToString());
            return aStudentGateway.ShowStudentInfoListView(aStudent1);
        }
    }
}
