using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentResultInfoApp.DAL.GATEWAY
{
    class ResultGateWay
    {

        private SqlConnection connection;
        string  TABLE_NAME;
        string TABLE_NAME1 ;
        ResultGateWay()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["con"];

            string connectionString = "";
            TABLE_NAME = "t_Student";
            TABLE_NAME1 = "t_Course";

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
                connection.Close();
                return true;
            }
            connection.Close();
            return false;
        }

        public string InsertIntoResult(Student aStudent)
        {

            connection.Open();

            string query = string.Format("INSERT INTO t_Result VALUES('{0}','{1}')", aStudent.RegNo, aStudent.ResulttScore);

            SqlCommand command = new SqlCommand(query, connection);
            int affectedRows = command.ExecuteNonQuery();
            connection.Close();




            if (affectedRows > 0)
                return "Insert success";
            return "Something happens wromg";

        }

    }
}
