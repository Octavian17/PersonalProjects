using Platforma_Educationala.MVVM.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platforma_Educationala.MVVM.Model.DataAccessLAyer
{
    class StudentDAL
    {

        public ObservableCollection<Tuple<Student,string>> GetStudentsforSubject(Subject subject)
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetStudentsforSubject", con);
                ObservableCollection<Tuple<Student, string>> result = new ObservableCollection<Tuple<Student, string>>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIDSubject = new SqlParameter("@id_subject", subject.SubjectID);
                cmd.Parameters.Add(paramIDSubject);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Student s = new Student();
                    s.StudentID = (int)reader[0];
                    s.Email = reader.GetString(1);
                    s.Password = reader.GetString(2);
                    s.FirstName = reader.GetString(3);
                    s.LastName = reader.GetString(4);
                    s.Phone = reader.GetString(5);
                    s.ClassroomID = (int)reader[6];
                    string c = s.FirstName + " " + s.LastName;
                    result.Add(new Tuple<Student, string>(s, c));
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public ObservableCollection<Tuple<Student, string>> GetAllStudentsAndClassroom()
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllStudentsAndClassroom", con);
                ObservableCollection<Tuple<Student, string>> result = new ObservableCollection<Tuple<Student, string>>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Student s = new Student();
                    s.StudentID = (int)reader[0];
                    s.Email = reader.GetString(1);
                    s.Password = reader.GetString(2);
                    s.FirstName = reader.GetString(3);
                    s.LastName= reader.GetString(4);
                    s.Phone = reader.GetString(5);
                    s.ClassroomID= (int)reader[6];                   
                    string c= reader.GetString(7);
                    result.Add(new Tuple<Student,string>(s,c));
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public void InsertStudent(Student student)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramEmail = new SqlParameter("@e", student.Email);
                SqlParameter paramPassword= new SqlParameter("@pass",student.Password);
                SqlParameter paramFN= new SqlParameter("@fn",student.FirstName);
                SqlParameter paramLN= new SqlParameter("@ln",student.LastName);
                SqlParameter paramPhone= new SqlParameter("@p",student.Phone);
                SqlParameter paramClassroom= new SqlParameter("@cl_id",student.ClassroomID);             
                cmd.Parameters.Add(paramEmail);
                cmd.Parameters.Add(paramPassword);
                cmd.Parameters.Add(paramFN);
                cmd.Parameters.Add(paramLN);
                cmd.Parameters.Add(paramPhone);
                cmd.Parameters.Add(paramClassroom);                
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteStudent(Student student)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdStudent = new SqlParameter("@student_id", student.StudentID);
                cmd.Parameters.Add(paramIdStudent);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyStudent(Student student)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateStudent", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdStudent = new SqlParameter("@student_id", student.StudentID);
                SqlParameter paramEmail = new SqlParameter("@e", student.Email);
                SqlParameter paramPassword = new SqlParameter("@pass", student.Password);
                SqlParameter paramFN = new SqlParameter("@fn", student.FirstName);
                SqlParameter paramLN = new SqlParameter("@ln", student.LastName);
                SqlParameter paramPhone = new SqlParameter("@p", student.Phone);
                SqlParameter paramClassroom = new SqlParameter("@cl_id", student.ClassroomID);
                cmd.Parameters.Add(paramIdStudent);
                cmd.Parameters.Add(paramEmail);
                cmd.Parameters.Add(paramPassword);
                cmd.Parameters.Add(paramFN);
                cmd.Parameters.Add(paramLN);
                cmd.Parameters.Add(paramPhone);
                cmd.Parameters.Add(paramClassroom);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

