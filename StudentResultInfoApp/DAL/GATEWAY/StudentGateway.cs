using System;
using System.Collections.Generic;
using System.Configuration;
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

        private string TABLE_NAME;



        public StudentGateway()
        {
            //string conn = @"server=OVI;database=AbcUniversity;integrated security =true";
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["con"];

            string connectionString = "";
            TABLE_NAME = "t_Student";

            if (settings != null)
                connectionString = settings.ConnectionString;
            connection = new SqlConnection();
            connection.ConnectionString = connectionString;


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
            string query = string.Format("INSERT INTO t_Student VALUES('{0}','{1}','{2}','{3}','{4}')", aStudent.StudentRegNo,
                aStudent.StudentName, aStudent.StudentEmail,aStudent.StudentCourse,aStudent.EnrollDate);

            SqlCommand command = new SqlCommand(query, connection);

            int affectedRows = command.ExecuteNonQuery();
            connection.Close();
            if (affectedRows > 0)
                return "Insert success";
            return "Something happens wromg";

        }

        public Student FindStudent(Student aStudent)
        {
            string regNo = aStudent.StudentRegNo;
            connection.Open();

            string query = string.Format("SELECT * FROM {0} WHERE Student_RegNo={1} "
                ,TABLE_NAME 
                ,aStudent.StudentRegNo);


            SqlCommand command = new SqlCommand(query , connection);
            SqlDataReader aReader= command.ExecuteReader();


            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    aStudent.StudentEmail = aReader.GetValue(2).ToString();
                    aStudent.StudentName = aReader.GetValue(3).ToString();
                    aStudent.StudentCourse = aReader.GetValue(4).ToString();

                }
            }
            else
            {
                ;
            }


            connection.Close();


            return aStudent;

        }
    }
}
