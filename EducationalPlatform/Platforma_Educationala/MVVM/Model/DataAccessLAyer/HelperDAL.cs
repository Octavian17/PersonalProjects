﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Platforma_Educationala.MVVM.Model.DataAccessLAyer
{
    class HelperDAL
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["myConStr"].ConnectionString;

        public static SqlConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
    }
}
