using Platforma_Educationala.MVVM.Model.DataAccessLAyer;
using Platforma_Educationala.MVVM.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platforma_Educationala.MVVM.Model.BusinessLogicLayer
{
    class LoginBLL
    {
        LoginDAL loginDAL = new LoginDAL();

        public Student VerifyLoginStudent(string email, string password)
        {
            return loginDAL.VerifyLoginStudent(email, password);
        }

        public Teacher VerifyLoginTeacher(string email, string password)
        {
            return loginDAL.VerifyLoginTeacher(email, password);   
        }

        public Teacher VerifyLoginClassMaster(string email, string password)
        {
            return loginDAL.VerifyLoginClassMaster(email, password);
        }
    }
}
