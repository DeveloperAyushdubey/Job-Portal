using Mvc_Projetc.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Mvc_Projetc.data
{
    public class Accountsdata
    {

        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Const"].ToString());
        SqlCommand cmd = new SqlCommand();

        public void create(Admin admin)
        {
            cmd = new SqlCommand("_insertadmin", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", admin.name);
            cmd.Parameters.AddWithValue("@email", admin.email);
            cmd.Parameters.AddWithValue("@phone", admin.phone);
             cmd.Parameters.AddWithValue("@pass", admin.password);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}