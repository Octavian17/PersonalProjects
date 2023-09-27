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
    class SubjectDAL
    {
        public ObservableCollection<Tuple<Subject, string>> GetSubjectsForTeacher(Teacher teacher)
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetSubjectsForTeacher", con);
                cmd.CommandType = CommandType.StoredProcedure;
                ObservableCollection<Tuple<Subject, string>> result = new ObservableCollection<Tuple<Subject, string>>();
                SqlParameter paramIdTeacher = new SqlParameter("@id_teacher", teacher.TeacherID);
                cmd.Parameters.Add(paramIdTeacher);               
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Subject s = new Subject();
                    s.SubjectID = (int)reader[0];
                    s.SubjectName = reader.GetString(1);
                    s.Semester = (int)reader[2];
                    string n = s.SubjectName + " sem " + s.Semester;
                    result.Add(new Tuple<Subject, string > (s,n));
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public ObservableCollection<Subject> GetAllSubjects()
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllSubjects", con);
                ObservableCollection<Subject> result = new ObservableCollection<Subject>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Subject s = new Subject();
                    s.SubjectID = (int)reader[0];
                    s.SubjectName = reader.GetString(1);
                    s.Semester = (int)reader[2];
                    result.Add(s);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public ObservableCollection<Tuple<Subject,string>> GetAllSubjectsExtended()
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllSubjects", con);
                ObservableCollection<Tuple<Subject, string>> result = new ObservableCollection<Tuple<Subject, string>>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Subject s = new Subject();
                    s.SubjectID = (int)reader[0];
                    s.SubjectName = reader.GetString(1);
                    s.Semester = (int)reader[2];
                    string c = s.SubjectName + "/sem" + s.Semester;
                    result.Add(new Tuple<Subject,string>(s,c));
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public void InsertSubject(Subject subject)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramName = new SqlParameter("@subject_name", subject.SubjectName);
                SqlParameter paramSemester = new SqlParameter("@semester", subject.Semester);
                cmd.Parameters.Add(paramName);
                cmd.Parameters.Add(paramSemester);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteSubject(Subject subject)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdSubject = new SqlParameter("@subject_id", subject.SubjectID);
                cmd.Parameters.Add(paramIdSubject);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifySubject(Subject subject)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateSubject", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdSubject = new SqlParameter("@subject_id", subject.SubjectID);
                SqlParameter paramName = new SqlParameter("@subject_name", subject.SubjectName);
                SqlParameter paramSemester = new SqlParameter("@semester", subject.Semester);

                cmd.Parameters.Add(paramIdSubject);
                cmd.Parameters.Add(paramName);
                cmd.Parameters.Add(paramSemester);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
