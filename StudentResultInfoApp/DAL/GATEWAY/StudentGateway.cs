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
        private string TABLE_NAME1;



        public StudentGateway()
        {
            //string conn = @"server=OVI;database=AbcUniversity;integrated security =true";
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



        public string Save(Student aStudent)
        {
            connection.Open();
            string query =

                string.Format("INSERT INTO t_Course VALUES('{0}','{1}','{2}')",
                                                            aStudent.StudentCourse, aStudent.StudentRegNo,aStudent.EnrollDate);
                  

            SqlCommand command = new SqlCommand(query, connection);

            int affectedRows = command.ExecuteNonQuery();
            connection.Close();




            if (affectedRows > 0)
                return "Insert success";
            return "Something happens wromg";




        }
        public string SaveForResultUi(Student aStudent)
        {
            connection.Open();
            string query =
                string.Format("UPDATE t_Student SET Student_Score_Persent ='{0}',Enroll_Date='{1}' " +
                              "WHERE Student_RegNo = '{2}'",aStudent.ScorePersent,aStudent.EnrollDate ,aStudent.StudentRegNo);

            SqlCommand command = new SqlCommand(query, connection);

            int affectedRows = command.ExecuteNonQuery();



            
            connection.Close();



            if (affectedRows > 0 )
                return "Insert success";



            return "could not Insert";

        }




        public List<Course> GetAllCourse()
        {
            connection.Open();
            string querry = string.Format("SELECT * FROM t_Course");
            SqlCommand command = new SqlCommand(querry, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<Course> cousres = new List<Course>();
            if (aReader.HasRows)
            {

                while (aReader.Read())
                {
                    Course aCourse = new Course();
                    aCourse.CourseName = aReader[1].ToString();
                    cousres.Add(aCourse);
                }


            }

            connection.Close();
            return cousres;
        }



        public Student FindStudent(Student aStudent)
        {
            
            
            string regNo = aStudent.StudentRegNo;
            connection.Open();

            string query = string.Format("SELECT * FROM {0} WHERE Student_RegNo={1}",TABLE_NAME
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

        public List<Student> ShowStudentInfoListView(Student aStudent)
        {
            connection.Open();
            string querry = string.Format("SELECT * FROM t_Course");
            SqlCommand command = new SqlCommand(querry, connection);
            
            SqlDataReader aReader = command.ExecuteReader();
            
            
            List<Student> students = new List<Student>();
            
            //ListView students = new ListView();
            
            
            
            if (aReader.HasRows)
            {

                while (aReader.Read())
                {
                   
                }

            }
            connection.Close();
            //return students;
            return aStudent;

        }

        public void DoSomething()
        {
            connection.Open();
            string querry = string.Format("SELECT * FROM t_Course");
            SqlCommand command = new SqlCommand(querry, connection);

            SqlDataReader aReader = command.ExecuteReader();


            List<Student> students = new List<Student>();

            //ListView students = new ListView();



            if (aReader.HasRows)
            {

                while (aReader.Read())
                {

                }

            }
            connection.Close();
           
        }
    }
}
