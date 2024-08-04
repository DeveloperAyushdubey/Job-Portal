using Mvc_Projetc.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Mvc_Projetc.data
{
    public class ApplicationFormdata
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Const"].ToString());
        SqlCommand cmd = new SqlCommand();


        public void  apply(Applicationform obj)
        {
            cmd = new SqlCommand("_insertApplyjob",con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", obj.name);
            cmd.Parameters.AddWithValue("@email", obj.email);
            cmd.Parameters.AddWithValue("@education", obj.education);
            cmd.Parameters.AddWithValue("@jid", obj.jid);
            cmd.Parameters.AddWithValue("@Experience", obj.Experience);
            cmd.Parameters.AddWithValue("@resume", obj.resume);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}