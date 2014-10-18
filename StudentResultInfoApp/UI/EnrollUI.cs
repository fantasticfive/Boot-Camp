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
        public EnrollUI()
        {
            InitializeComponent();
        }

        private void regNoFindButton_Click(object sender, EventArgs e)
        {

        }

        private void studentCourseEnrollButton_Click(object sender, EventArgs e)
        {
            Student aStudent = new Student();
            aStudent.Student_RegNo = studentRegNoTextBox.Text;
            aStudent.Student_Name = studentNameTextBox.Text;
            aStudent.Student_Email = studentEmailTextBox.Text;
            aStudent.Student_Course = studentCourseComboBox.Text;
            aStudent.Enroll_Date = courseEnrollDateTimePicker.Text;

           String msg = aStudentBll.Save(aStudent);
            MessageBox.Show(msg);
        }
    }
}
