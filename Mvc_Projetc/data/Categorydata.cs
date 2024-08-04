using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Mvc_Projetc.Models;

namespace Mvc_Projetc.data
{
    public class Categorydata
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Const"].ToString());
        SqlCommand cmd = new SqlCommand();

        public void create(Category obj)
        {
            cmd =  new SqlCommand("_checkname",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", obj.name);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {

            }
            else
            {
                con.Close();    
                cmd = new SqlCommand("_insertcategory", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", obj.name);
                cmd.Parameters.AddWithValue("@name", obj.isstatus ? "Active" : "Inactive");
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public List<Category> list()
        {
            List<Category> list = new List<Category>();
            cmd = new SqlCommand("_viewcategory", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            foreach (DataRow dr in dataTable.Rows)
            {
                list.Add(new Category
                {
                    name = dr["cname"].ToString(),
                    status = dr["cstatus"].ToString()
                });
            }
            return list;
        }



        public List<Category> search(string name)
        {
            List<Category> list = new List<Category>();
            cmd = new SqlCommand("_searchcategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@key", name);
            SqlDataAdapter ad= new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();  
            ad.Fill(dataTable);
            foreach (DataRow dr in dataTable.Rows)
            {
                list.Add(new Category
                {
                    name = dr["Cname"].ToString(),
                    status = dr["Cstatus"].ToString()

                });
            }
            return list;
           
            
        }



        public void update(Category obj)
        {
            cmd = new SqlCommand("_updatecategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", obj.name);
            cmd.Parameters.AddWithValue("@name", obj.isstatus ? "Active" : "Inactive");
            cmd.Parameters.AddWithValue("@name", obj.id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void delete(int id)
        {
            cmd = new SqlCommand("_deletecategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
