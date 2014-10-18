using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentResultInfoApp.DAL.DAO;

namespace StudentResultInfoApp.DAL.GATEWAY
{
    class StudentGateway
    {
        private SqlConnection connection;

        public StudentGateway()
        {
            string conn = @"server=OVI;database=AbcUniversity;integrated security =true";
            connection = new SqlConnection();
            connection.ConnectionString = conn;


        }

        public bool HasThisRegNoValid(string studentRegNo)
        {
           
            connection.Open();
            string query = string.Format("SELECT * FROM t_Student WHERE Student_RegNo='{0}' ", studentRegNo);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            if (aReader.HasRows)
            {
                return true;
            }
            return false;
        }

        public string Save(Student aStudent)
        {
            connection.Open();
            string query = string.Format("INSERT INTO t_Student VALUES('{0}','{1}','{2}','{3}','{4}')", aStudent.Student_RegNo,
                aStudent.Student_Name, aStudent.Student_Email,aStudent.Student_Course,aStudent.Enroll_Date);

            SqlCommand command = new SqlCommand(query, connection);

            int affectedRows = command.ExecuteNonQuery();
            connection.Close();
            if (affectedRows > 0)
                return "Insert success";
            return "Something happens wromg";

        }
    }
}
