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
    class TeacherDAL
    {
        public ObservableCollection<Teacher> GetAllTeachers()
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllTeachers", con);
                ObservableCollection<Teacher> result = new ObservableCollection<Teacher>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Teacher t = new Teacher();
                    t.TeacherID = (int)reader[0];
                    t.Email = reader.GetString(1);
                    t.Password = reader.GetString(2);
                    t.FirstName = reader.GetString(3);
                    t.LastName = reader.GetString(4);
                    t.Phone = reader.GetString(5);
                    result.Add(t);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public ObservableCollection<Teacher> GetAllClassmasters()
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllClassmasters", con);
                ObservableCollection<Teacher> result = new ObservableCollection<Teacher>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Teacher t = new Teacher();
                    t.TeacherID = (int)reader[0];
                    t.Email = reader.GetString(1);
                    t.Password = reader.GetString(2);
                    t.FirstName = reader.GetString(3);
                    t.LastName = reader.GetString(4);
                    t.Phone = reader.GetString(5);
                    result.Add(t);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public ObservableCollection<Tuple<Teacher, string>> GetAllTeachersExtendedName()
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllTeachers", con);
                ObservableCollection<Tuple<Teacher, string>> result = new ObservableCollection<Tuple<Teacher, string>>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Teacher t = new Teacher();
                    t.TeacherID = (int)reader[0];
                    t.Email = reader.GetString(1);
                    t.Password = reader.GetString(2);
                    t.FirstName = reader.GetString(3);
                    t.LastName = reader.GetString(4);
                    t.Phone = reader.GetString(5);
                    string name = t.FirstName + " " + t.LastName;
                    result.Add(new Tuple<Teacher, string>(t, name));                    
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public ObservableCollection<Tuple<Teacher,string>> GetAllClassmastersExtendedName()
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllClassmasters", con);
                ObservableCollection<Tuple<Teacher, string>> result = new ObservableCollection<Tuple<Teacher, string>>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Teacher t = new Teacher();
                    t.TeacherID = (int)reader[0];
                    t.Email = reader.GetString(1);
                    t.Password = reader.GetString(2);
                    t.FirstName = reader.GetString(3);
                    t.LastName = reader.GetString(4);
                    t.Phone = reader.GetString(5);
                    string name = t.FirstName + " " + t.LastName;
                    result.Add(new Tuple<Teacher,string>(t,name));
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public void InsertTeacher(Teacher teacher)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertTeacher", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramEmail = new SqlParameter("@e", teacher.Email);
                SqlParameter paramPassword = new SqlParameter("@pass", teacher.Password);
                SqlParameter paramFN = new SqlParameter("@fn", teacher.FirstName);
                SqlParameter paramLN = new SqlParameter("@ln", teacher.LastName);
                SqlParameter paramPhone = new SqlParameter("@p", teacher.Phone);                
                cmd.Parameters.Add(paramEmail);
                cmd.Parameters.Add(paramPassword);
                cmd.Parameters.Add(paramFN);
                cmd.Parameters.Add(paramLN);
                cmd.Parameters.Add(paramPhone);                
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteTeacher(Teacher teacher)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteTeacher", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdTeacher = new SqlParameter("@teacher_id", teacher.TeacherID);
                cmd.Parameters.Add(paramIdTeacher);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyTeacher(Teacher teacher)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateTeacher", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdTeacher = new SqlParameter("@teacher_id", teacher.TeacherID);
                SqlParameter paramEmail = new SqlParameter("@e", teacher.Email);
                SqlParameter paramPassword = new SqlParameter("@pass", teacher.Password);
                SqlParameter paramFN = new SqlParameter("@fn", teacher.FirstName);
                SqlParameter paramLN = new SqlParameter("@ln", teacher.LastName);
                SqlParameter paramPhone = new SqlParameter("@p", teacher.Phone);               
                cmd.Parameters.Add(paramIdTeacher);
                cmd.Parameters.Add(paramEmail);
                cmd.Parameters.Add(paramPassword);
                cmd.Parameters.Add(paramFN);
                cmd.Parameters.Add(paramLN);
                cmd.Parameters.Add(paramPhone);                
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
