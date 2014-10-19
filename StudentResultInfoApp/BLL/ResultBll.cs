using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentResultInfoApp.DAL.DAO;
using StudentResultInfoApp.DAL.GATEWAY;

namespace StudentResultInfoApp.BLL
{
    class ResultBll
    {

        StudentGateway aStudentGateway = new StudentGateway();
        ResultGateWay aResultGateWay = new ResultGateWay();


        public bool SaveFromResultUi(Result aResult)
        {
            ResultGateWay aResultGateWay = new ResultGateWay();
            if (!HasThisRegNoValid(aStudent.StudentRegNo))
            {
                return "RegNo address already exist";
            }
            else
            {
                return aStudentGateway.SaveForResultUi(aStudent);

            }
        }
        private bool HasThisRegNoValid(string studentRegNo)
        {
            return aStudentGateway.HasThisRegNoValid(studentRegNo);
        }
        
    }
}
