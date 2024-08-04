using Mvc_Projetc.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Mvc_Projetc.data
{
    public class userlogindata
    {

        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Const"].ToString());
        SqlCommand cmd = new SqlCommand();

        //public void create(Userlogin userlogin)
        //{
        //    cmd = new SqlCommand("_insertuser",con);
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@name",userlogin.username);
        //    cmd.Parameters.AddWithValue("@email",userlogin.Email);
        //    cmd.Parameters.AddWithValue("@phone",userlogin.mobile);
        //    cmd.Parameters.AddWithValue("@resumeimage",userlogin.resume);
        //    cmd.Parameters.AddWithValue("@photo",userlogin.Photo);
        //    cmd.Parameters.AddWithValue("@education", userlogin.education);
        //    cmd.Parameters.AddWithValue("@age",userlogin.age);
        //    cmd.Parameters.AddWithValue("@pass",userlogin.password);
        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}


        //public List<Userlogin> list() 
        //{
        // List<Userlogin> list = new List<Userlogin>();  
        //  cmd = new SqlCommand("select * from usertable",con);
        //    cmd.CommandType = System.Data.CommandType.Text;
        //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //    DataTable dataTable = new DataTable();
        //    adapter.Fill(dataTable);
        //    foreach (DataRow dr in dataTable.Rows)
        //    {
        //        list.Add(new Userlogin
        //        {
        //            username = dr["name"].ToString(),
        //            Email = dr["email"].ToString(),
        //            password = dr["pass"].ToString(),
        //            education = dr["education"].ToString(),
        //            Photo = dr["Photo"].ToString(),
        //            resume = dr["resumeimage"].ToString(),
        //            mobile = dr["phone"].ToString(),
        //            age = Convert.ToInt32(dr["age"]),

        //        });
        //    }
        //    return list;

        //}



        //public void login(Userlogin userlogin)
        //{
        //    cmd = new SqlCommand("_Loginuser", con);
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@email", userlogin.Email);
        //    cmd.Parameters.AddWithValue("@pass", userlogin.password);
        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();    
        //}
    }
}