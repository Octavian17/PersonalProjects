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
    class MaterialsDAL
    {

        public ObservableCollection<Tuple<Subject, ClassroomSubjectTeacher>> GetMaterials(Student student)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetMaterials", con);
                ObservableCollection<Tuple<Subject, ClassroomSubjectTeacher>> result = new ObservableCollection<Tuple<Subject, ClassroomSubjectTeacher>>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@classroom_id", student.ClassroomID);
                cmd.Parameters.Add(paramID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Tuple<Subject, ClassroomSubjectTeacher>(
                        new Subject()
                        {
                            SubjectName = reader.GetString(0),
                            Semester = (int)reader[1]
                        },
                        new ClassroomSubjectTeacher()
                        {
                            Material = reader["material"] as string,
                            MaterialName = reader["material_name"] as string
                        }

                        ));
                }
                reader.Close();
                return result;
            }
        }
    }
}
