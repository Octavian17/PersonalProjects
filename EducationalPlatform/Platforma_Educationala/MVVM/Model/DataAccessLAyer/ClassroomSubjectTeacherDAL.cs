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
    class ClassroomSubjectTeacherDAL
    {
        public ObservableCollection<Tuple<ClassroomSubjectTeacher, string, string, string>> GetAllRelationsWithClassSubTeach()
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllRelationsWithClassSubTeach", con);
                ObservableCollection<Tuple<ClassroomSubjectTeacher, string, string, string>> result = new ObservableCollection<Tuple<ClassroomSubjectTeacher, string, string, string>>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    result.Add(new Tuple<ClassroomSubjectTeacher, string, string, string>(
                        new ClassroomSubjectTeacher()
                        {
                            ClassroomID = (int)reader[0],
                            SubjectID = (int)reader[1],
                            TeacherID = (int)reader[2],
                            Material = reader["material"].ToString(),
                            MaterialName = reader["material_name"].ToString(),
                            Thesis = reader.GetBoolean(5)
                        }, reader.GetString(6), reader.GetString(7)+"/sem" + (int)reader[10], reader.GetString(8) + " " + reader.GetString(9)));
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public void InsertClassroomSubjectTeacher(ClassroomSubjectTeacher classroomSubjectTeacher)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertClassroom_Subject_Teacher", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIDClassroom = new SqlParameter("@classroom_id", classroomSubjectTeacher.ClassroomID);
                SqlParameter paramIdSubject = new SqlParameter("@subject_id", classroomSubjectTeacher.SubjectID);
                SqlParameter paramIDTeacher = new SqlParameter("@teacher_id", classroomSubjectTeacher.TeacherID);           
                SqlParameter paramThesis = new SqlParameter("@thesis", classroomSubjectTeacher.Thesis);                
                SqlParameter paramMaterial = new SqlParameter();
                paramMaterial.ParameterName = "@material";                
                if (String.IsNullOrEmpty(classroomSubjectTeacher.Material))
                {
                    paramMaterial.Value = DBNull.Value;
                }
                else
                {
                    paramMaterial.Value = classroomSubjectTeacher.Material;
                }
                SqlParameter paramMaterialName = new SqlParameter();
                paramMaterialName.ParameterName = "@material_name";
                if (String.IsNullOrEmpty(classroomSubjectTeacher.MaterialName))
                {
                    paramMaterialName.Value = DBNull.Value;
                }
                else
                {
                    paramMaterialName.Value = classroomSubjectTeacher.MaterialName;
                }
                cmd.Parameters.Add(paramIDClassroom);
                cmd.Parameters.Add(paramIdSubject);
                cmd.Parameters.Add(paramIDTeacher);
                cmd.Parameters.Add(paramMaterial);
                cmd.Parameters.Add(paramMaterialName);
                cmd.Parameters.Add(paramThesis);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteClassroomSubjectTeacher(ClassroomSubjectTeacher classroomSubjectTeacher)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteClassroom_Subject_Teacher", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdClassroom = new SqlParameter("@classroom_id", classroomSubjectTeacher.ClassroomID);
                SqlParameter paramIdSubject = new SqlParameter("@subject_id", classroomSubjectTeacher.SubjectID);
                SqlParameter paramIdTeacher = new SqlParameter("@teacher_id", classroomSubjectTeacher.TeacherID);
                cmd.Parameters.Add(paramIdClassroom);
                cmd.Parameters.Add(paramIdSubject);
                cmd.Parameters.Add(paramIdTeacher);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyClassroomSubjectTeacher(ClassroomSubjectTeacher classroomSubjectTeacher)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateClassroom_Subject_Teacher", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIDClassroom = new SqlParameter("@classroom_id", classroomSubjectTeacher.ClassroomID);
                SqlParameter paramIdSubject = new SqlParameter("@subject_id", classroomSubjectTeacher.SubjectID);
                SqlParameter paramIDTeacher = new SqlParameter("@teacher_id", classroomSubjectTeacher.TeacherID);
                SqlParameter paramMaterial = new SqlParameter();
                paramMaterial.ParameterName = "@material";
                if (String.IsNullOrEmpty(classroomSubjectTeacher.Material))
                {
                    paramMaterial.Value = DBNull.Value;
                }
                else
                {
                    paramMaterial.Value = classroomSubjectTeacher.Material;
                }
                SqlParameter paramMaterialName = new SqlParameter();
                paramMaterialName.ParameterName = "@material_name";
                if (String.IsNullOrEmpty(classroomSubjectTeacher.MaterialName))
                {
                    paramMaterialName.Value = DBNull.Value;
                }
                else
                {
                    paramMaterialName.Value = classroomSubjectTeacher.MaterialName;
                }
                SqlParameter paramThesis = new SqlParameter("@thesis", classroomSubjectTeacher.Thesis);

                cmd.Parameters.Add(paramIDClassroom);
                cmd.Parameters.Add(paramIdSubject);
                cmd.Parameters.Add(paramIDTeacher);
                cmd.Parameters.Add(paramMaterial);
                cmd.Parameters.Add(paramMaterialName);
                cmd.Parameters.Add(paramThesis);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
