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
    public partial class EnrollUI : Form
    {
        StudentBLL  aStudentBll = new StudentBLL();
        private Student nowInStudent;
        private Student aStudent;

        public EnrollUI()
        {
            InitializeComponent();
        }

        private void studentCourseEnrollButton_Click(object sender, EventArgs e)
        {
           aStudent = new Student();


            aStudent.StudentRegNo = studentRegNoTextBox.Text;
            aStudent.StudentName = studentNameTextBox.Text;
            aStudent.StudentEmail = studentEmailTextBox.Text;
            aStudent.StudentCourse = studentCourseComboBox.Text;
            aStudent.EnrollDate = courseEnrollDateTimePicker.Text;

           String msg = aStudentBll.Save(aStudent);
            MessageBox.Show(msg);
        }





        private void regNoFindButton_Click(object sender, EventArgs e)
        {
            aStudent = new Student();
            aStudent.StudentRegNo = studentRegNoTextBox.Text;


            
            MessageBox.Show(aStudent.StudentRegNo);
            aStudent = aStudentBll.FindStudent(aStudent);

            

            //show in UI
            studentRegNoTextBox.Text = aStudent.StudentRegNo;
            studentEmailTextBox.Text = aStudent.StudentEmail;
            studentNameTextBox.Text = aStudent.StudentName;
            
        }

    }
}
