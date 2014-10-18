using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentResultInfoApp.BLL;
using StudentResultInfoApp.DAL.DAO;

namespace StudentResultInfoApp.UI
{
    public partial class ResultEntryUI : Form
    {

        private StudentBLL aStudentBll;
        private Student aStudent;

        public ResultEntryUI()
        {
            InitializeComponent();
        }


        private void regNoFindButton_Click(object sender, EventArgs e)
        {
            aStudent = new Student();
            aStudentBll = new StudentBLL();
            
            aStudent.StudentRegNo = studentRegNoTextBox.Text;




            aStudent = aStudentBll.FindStudent(aStudent);



            //show in UI
            studentRegNoTextBox.Text = aStudent.StudentRegNo;
            studentEmailTextBox.Text = aStudent.StudentEmail;
            studentNameTextBox.Text = aStudent.StudentName;
        }

        private void SaveForResultUi_Click(object sender, EventArgs e)
        {
            aStudentBll = new StudentBLL();
            aStudent = new Student();


            aStudent.StudentRegNo = studentRegNoTextBox.Text;
            aStudent.StudentName = studentNameTextBox.Text;
            aStudent.StudentEmail = studentEmailTextBox.Text;
            aStudent.StudentCourse = studentCourseComboBox.Text;
            aStudent.EnrollDate = courseEnrollDateTimePicker.Text;
            aStudent.ScorePersent = Convert.ToDouble(scorePersentTextBox.Text);




            aStudentBll.SaveForResultUi(aStudent);
        }
    }
}
