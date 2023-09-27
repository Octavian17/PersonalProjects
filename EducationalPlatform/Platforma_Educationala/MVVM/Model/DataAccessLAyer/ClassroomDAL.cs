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
    class ClassroomDAL
    {
        public ObservableCollection<Classroom> GetAllClasses()
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllClasses", con);
                ObservableCollection<Classroom> result = new ObservableCollection<Classroom>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Classroom c = new Classroom();
                    c.ClassroomID = (int)reader[0];
                    c.Grade = reader.GetString(1);
                    c.Specialization = reader.GetString(2);
                    c.Classmaster = (int)reader[3];
                    result.Add(c);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public void InsertClassroom(Classroom classroom)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertClassroom", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramgrade = new SqlParameter("@grade", classroom.Grade);
                SqlParameter paramSpecialization = new SqlParameter("@specialization", classroom.Specialization);
                SqlParameter paramClassmaster = new SqlParameter("@classmaster", classroom.Classmaster);

                cmd.Parameters.Add(paramgrade);
                cmd.Parameters.Add(paramSpecialization);
                cmd.Parameters.Add(paramClassmaster);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteClassroom(Classroom classroom)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteClassroom", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdClassroom = new SqlParameter("@classroom_id", classroom.ClassroomID);
                cmd.Parameters.Add(paramIdClassroom);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyClassroom(Classroom classroom)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateClassroom", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdClassroom = new SqlParameter("@classroom_id", classroom.ClassroomID);
                SqlParameter paramGrade = new SqlParameter("@grade", classroom.Grade);
                SqlParameter paramSpecialization = new SqlParameter("@specialization", classroom.Specialization);
                SqlParameter paramClassmaster = new SqlParameter("@classmaster", classroom.Classmaster);

                cmd.Parameters.Add(paramIdClassroom);
                cmd.Parameters.Add(paramGrade);
                cmd.Parameters.Add(paramSpecialization);
                cmd.Parameters.Add(paramClassmaster);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public ObservableCollection<Tuple<Classroom, string>> GetAllClassroomsAndClassmaster()
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllClassroomsAndClassmaster", con);
                ObservableCollection<Tuple<Classroom, string>> result = new ObservableCollection<Tuple<Classroom, string>>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Classroom c = new Classroom();
                    c.ClassroomID = (int)reader[0];
                    c.Grade = reader.GetString(1);
                    c.Specialization = reader.GetString(2);
                    c.Classmaster = (int)reader[3];
                    string cm = reader.GetString(4) + " " + reader.GetString(5);
                    result.Add(new Tuple<Classroom, string>(c, cm));
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
