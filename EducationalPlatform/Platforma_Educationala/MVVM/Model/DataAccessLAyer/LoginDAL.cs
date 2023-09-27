using Platforma_Educationala.MVVM.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platforma_Educationala.MVVM.Model.DataAccessLAyer
{
    class LoginDAL
    {
        public Student VerifyLoginStudent(string email,string password)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand("VerifyLoginStudent", con);
                Student result = new Student();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramEmail = new SqlParameter("@email", email);
                SqlParameter paramPassword = new SqlParameter("@password", password);
                cmd.Parameters.Add(paramEmail);
                cmd.Parameters.Add(paramPassword);
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student s = new Student();
                    s.StudentID = (int)(reader[0]);
                    s.Email= reader.GetString(1);
                    s.Password = reader.GetString(2);
                    s.FirstName = reader.GetString(3);
                    s.LastName = reader.GetString(4);
                    s.Phone = reader.GetString(5);
                    s.ClassroomID = (int)(reader[6]);
                    result = s;
                }
                reader.Close();
                return result;
            }            
        }

        public Teacher VerifyLoginTeacher(string email, string password)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand("VerifyLoginTeacher", con);
                Teacher result = new Teacher();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramEmail = new SqlParameter("@email", email);
                SqlParameter paramPassword = new SqlParameter("@password", password);
                cmd.Parameters.Add(paramEmail);
                cmd.Parameters.Add(paramPassword);
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Teacher t = new Teacher();
                    t.TeacherID = (int)(reader[0]);
                    t.Email = reader.GetString(1);
                    t.Password = reader.GetString(2);
                    t.FirstName = reader.GetString(3);
                    t.LastName = reader.GetString(4);
                    t.Phone = reader.GetString(5);
                    result = t;                   
                }
                reader.Close();
                return result;
            }           
        }

        public Teacher VerifyLoginClassMaster(string email, string password)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand("VerifyLoginClassMaster", con);
                Teacher result = new Teacher();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramEmail = new SqlParameter("@email", email);
                SqlParameter paramPassword = new SqlParameter("@password", password);
                cmd.Parameters.Add(paramEmail);
                cmd.Parameters.Add(paramPassword);
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Teacher t = new Teacher();
                    t.TeacherID = (int)(reader[0]);
                    t.Email = reader.GetString(1);
                    t.Password = reader.GetString(2);
                    t.FirstName = reader.GetString(3);
                    t.LastName = reader.GetString(4);
                    t.Phone = reader.GetString(5);
                    result = t;
                }
                reader.Close();
                return result;
            }
        }
    }
}
