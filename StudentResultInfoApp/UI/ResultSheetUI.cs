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
using StudentResultInfoApp.DAL.GATEWAY;

namespace StudentResultInfoApp.UI
{
    public partial class ResultSheetUI : Form
    {
        
        private Student aStudent;
        private StudentBLL aStudentBll;
        private Result aResult;
        public ResultSheetUI()
        {
            InitializeComponent();
        }

        private void findButtonInResultSheet_Click(object sender, EventArgs e)
        {
             aStudent = new Student();
            aStudentBll = new StudentBLL();
            aResult = new Result();
            aStudent.StudentRegNo = studentRegNoTextBoxInResultSheet.Text;


            aStudent = aStudentBll.FindStudent(aStudent);
            

            //show in UI
            studentRegNoTextBoxInResultSheet.Text = aStudent.StudentRegNo;
            studentEmailTextBoxInResultSheet.Text = aStudent.StudentEmail;
            studentNameTextBoxInResultSheet.Text = aStudent.StudentName;

            double result = aResult.CalculateAvg(aStudent);

            averageScoreTextBoxInResultSheet.Text = result.ToString();

            string grade = aResult.CalculateGrade(result);
            gradeLetterTextBox.Text = grade;

            aStudent.DoSomething();

            DoWhat();
        }

        private void DoWhat()
        {
            public double CalculateAvg(Student aStudent)
        {
            aResultGateWay = new ResultGateWay();
            List<double> allResult = new List<double>();

            
            allResult = aResultGateWay.GetAllScore(aStudent);

            double total = 0;

            foreach (double d in allResult)
            {
            total += d;
            }


            double avgResult = total/allResult.Count;


            return avgResult;
        }

        public string CalculateGrade(double score)
        {
            if (score >= 90)
                return "A";
            else if(score >= 70 && score < 90)
            {
                return "B";
            }
            else if (score >= 50 && score < 70)
            {
                return "C";
            }
            else
            {
                return "F";
            }
        }
        }
    }
    }
}
