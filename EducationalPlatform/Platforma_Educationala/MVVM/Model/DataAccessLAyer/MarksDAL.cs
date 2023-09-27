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
    class MarksDAL
    {
        public ObservableCollection<Tuple<Subject, Mark>> GetMarksforStudent(Student student)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetMarksforStudent", con);
                ObservableCollection<Tuple<Subject, Mark>> result = new ObservableCollection<Tuple<Subject, Mark>>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@student_id", student.StudentID);
                cmd.Parameters.Add(paramID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Tuple<Subject, Mark>(
                        new Subject()
                        {
                            SubjectName = reader.GetString(0),
                            Semester = (int)reader[1]
                        },
                        new Mark()
                        {
                            Score = (int)(reader)[2],
                            Thesis = (bool)reader[3],
                            DateTime = reader.GetDateTime(4),
                        }

                        ));
                }
                reader.Close();
                return result;
            }
        }

       
    }
}
