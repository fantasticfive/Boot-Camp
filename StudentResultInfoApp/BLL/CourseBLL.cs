using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentResultInfoApp.DAL.DAO;
using StudentResultInfoApp.DAL.GATEWAY;

namespace StudentResultInfoApp.BLL
{
    class CourseBLL
    {
        private CourseGateWay aCourseGateWay;


        public CourseBLL()
        {
            aCourseGateWay = new CourseGateWay();
        }

        public List<Course> ShoInListViewFromDB(Student aStudent)
        {
            List<Course> courses  =new List<Course>();


            courses = aCourseGateWay.ShoInListViewFromDB(aStudent);
            return courses;
        }

        public void DoWrong()
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
