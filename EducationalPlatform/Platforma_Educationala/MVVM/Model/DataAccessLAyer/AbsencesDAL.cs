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
    class AbsencesDAL
    {

        public void InsertAttendence(Attendence attendence)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {               
                SqlCommand cmd = new SqlCommand("InsertAttendence", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramDate = new SqlParameter("@date", attendence.Date);
                SqlParameter paramIDStudent = new SqlParameter("@student_id", attendence.StudentID);
                SqlParameter parammotivated = new SqlParameter("@motivated", attendence.Motivated);
                SqlParameter paranmotivable = new SqlParameter("@motivable", attendence.Motivable);
                SqlParameter paramIdSubject = new SqlParameter("@subject_id", attendence.SubjectID);                
                cmd.Parameters.Add(paramDate);
                cmd.Parameters.Add(paramIDStudent);
                cmd.Parameters.Add(parammotivated);
                cmd.Parameters.Add(paranmotivable);
                cmd.Parameters.Add(paramIdSubject);                
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyAttendence(Attendence attendence)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateAttendence", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramDate = new SqlParameter("@date", attendence.Date);
                SqlParameter paramIDStudent = new SqlParameter("@student_id", attendence.StudentID);
                SqlParameter parammotivated = new SqlParameter("@motivated", attendence.Motivated);
                SqlParameter paranmotivable = new SqlParameter("@motivable", attendence.Motivable);
                SqlParameter paramIdSubject = new SqlParameter("@subject_id", attendence.SubjectID);
                cmd.Parameters.Add(paramDate);
                cmd.Parameters.Add(paramIDStudent);
                cmd.Parameters.Add(parammotivated);
                cmd.Parameters.Add(paranmotivable);
                cmd.Parameters.Add(paramIdSubject);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public ObservableCollection<Tuple<Subject, Attendence>> GetAbsencesforStudent(Student student)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAbsencesforStudent", con);
                ObservableCollection<Tuple<Subject, Attendence>> result = new ObservableCollection<Tuple<Subject, Attendence>>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@student_id", student.StudentID);
                cmd.Parameters.Add(paramID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Tuple<Subject, Attendence>(
                        new Subject()
                        {
                            SubjectName = reader.GetString(0),
                            Semester= (int)reader[1]
                        },
                        new Attendence()
                        {
                            DateTime = reader.GetDateTime(2),
                            Motivable = (bool)reader[3],
                            Motivated = (bool)reader[4]    
                        }

                        ));
                }
                reader.Close();
                return result;
            }
        }


        public ObservableCollection< Attendence> GetStudentAbsencesforSubject(Student student,Subject subject)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetStudentAbsencesforSubject", con);
                ObservableCollection<Attendence> result = new ObservableCollection<Attendence>();
                cmd.CommandType = CommandType.StoredProcedure;               
                SqlParameter paramIDSubject = new SqlParameter("@id_subject", subject.SubjectID);
                SqlParameter paramIDStudent = new SqlParameter("@id_student", student.StudentID);
                cmd.Parameters.Add(paramIDSubject);
                cmd.Parameters.Add(paramIDStudent);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Attendence()
                        {
                            AttendenceID=(int?)reader[0],
                            DateTime = reader.GetDateTime(1),
                            StudentID=(int?)reader[2],
                            Motivable = (bool)reader[3],
                            Motivated = (bool)reader[4],
                            SubjectID=(int?)reader[5]
                        });
                }
                reader.Close();
                return result;
            }
        }

    }
}
