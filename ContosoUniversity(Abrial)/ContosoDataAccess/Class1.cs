using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ContosoUniversityModel;
namespace ContosoDataAccess
{
    public class CourseDataAccess
    {
        private string connectionString = "Data Source=EUNTEO\\MSSQLSERVER01;Initial Catalog=ContosoDB;Integrated Security=True";

        #region Course
        public List<Course> getCourses()
        {
            List<Course> courses = new List<Course>();

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.CommandText = "select id, Coursename from tblCourse";
            comm.Connection = conn;
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                Course temp = new Course();
                temp.id = Convert.ToInt32(dr["id"]);
                temp.Course_name = dr["CourseName"].ToString();
                courses.Add(temp);
            }
            //Step 4: Close Connection
            conn.Close();
            return courses;
        }

        public List<Course> noduplicateCourses() // created a new function to check for duplicate records
        {
            List<Course> courses = new List<Course>();

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.CommandText = "select Distinct(Coursename) from tblCourse";
            comm.Connection = conn;
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                Course temp = new Course();
                temp.Course_name = dr["CourseName"].ToString();
                courses.Add(temp);
            }
            //Step 4: Close Connection
            conn.Close();
            return courses;
        }
        public bool SaveCourse(Course c)
        {

            //Step 1: open the connection
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            //step 2: create SQL insert into
            SqlCommand comm = new SqlCommand();
            comm.CommandText = "insert into tblcourse(coursename) values('" + c.Course_name + "')";
            comm.Connection = conn;

            //Step 3 : Executed
            comm.ExecuteNonQuery();

            //Step 4: Close Connection
            conn.Close();
            return true;
        }
        public bool FindCourses(string courseName)
        {

            List<Course> courses = new List<Course>();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.CommandText = "select Id from tblCourse where CourseName = '" + courseName + "'";
            comm.Connection = conn;
            SqlDataReader dr = comm.ExecuteReader();
            int id = Convert.ToInt32(dr["id"]);
            if (Convert.ToInt32(dr["count"]) == 0)
            {
                conn.Close();
                return false;
            }

            conn.Close();
            return true;
        }
        #endregion

    }

    public class StudentDataAccess
    {
        private string connectionString = "Data Source=EUNTEO\\MSSQLSERVER01;Initial Catalog=ContosoDB;Integrated Security=True";
     
        public List<Student> getStudents()
        {
            List<Student> students = new List<Student>();

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.CommandText = "select Distinct(StudentName),StudentMarks from tblStudent";
            comm.Connection = conn;
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                Student s_temp = new Student();
                //s_temp.id = Convert.ToInt32(dr["id"]);
                s_temp.name = dr["StudentName"].ToString();
                s_temp.marks = Convert.ToInt32(dr["StudentMarks"]);
                students.Add(s_temp);
                
            }
            //Step 4: Close Connection
            conn.Close();
            return students;
        }

        public bool SaveStudent(Student s)
        {

            //Step 1: open the connection
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            //step 2: create SQL insert into
            SqlCommand comm = new SqlCommand();

            comm.CommandText = "insert into tblStudent(StudentName,StudentMarks) values('"+s.name +"','"+s.marks+"')";
 ;
            comm.Connection = conn;

            //Step 3 : Executed
            comm.ExecuteNonQuery();

            //Step 4: Close Connection
            conn.Close();
            return true;
        }
        public bool FindStudents(string studentName)
        {

            List<Course> courses = new List<Course>();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.CommandText = "select Id from tblStudent where StudentName = '" + studentName + "'";
            comm.Connection = conn;
            SqlDataReader dr = comm.ExecuteReader();
            int id = Convert.ToInt32(dr["id"]);
            if (Convert.ToInt32(dr["count"]) == 0)
            {
                conn.Close();
                return false;
            }
            

            conn.Close();
            return true;
        }
       

    }
}








//public bool Add() { }

