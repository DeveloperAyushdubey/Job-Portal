using Mvc_Projetc.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Mvc_Projetc.data
{
    public class Subcategorydata
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Const"].ToString());
        SqlCommand cmd = new SqlCommand();

        public void create(Subcategory obj)
        {
            cmd = new SqlCommand("_checksubcatgeoryname", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", obj.Name);
           
          
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable(); 
            adapter.Fill(dt);
            if (dt.Rows.Count > 1)
            {

            }
            else
            {
                con.Close();
                cmd = new SqlCommand("_insertsubcategory", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", obj.Name);
                cmd.Parameters.AddWithValue("@status", obj.isstatus ? "Active" : "Inactive");
                cmd.Parameters.AddWithValue("@id", obj.cid);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            }

        

        public List<Subcategory> list()
        {
            List<Subcategory> list = new List<Subcategory>();
            cmd = new SqlCommand("_viewsubcategory", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            foreach (DataRow dr in dataTable.Rows)
            {
                list.Add(new Subcategory
                {
                    Id = Convert.ToInt16(dr["sid"]),
                    Name = dr["sname"].ToString(),
                    status = dr["sstatus"].ToString(),
                    cid = Convert.ToInt16(dr["Cid"])
                });
            }
            return list;
        }



        public List<Subcategory> search(string name)
        {
            List<Subcategory> list = new List<Subcategory>();
            cmd = new SqlCommand(" _searchsubcategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@key", name);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            ad.Fill(dataTable);
            foreach (DataRow dr in dataTable.Rows)
            {
                list.Add(new Subcategory
                {
                    Name = dr["sname"].ToString(),
                    status = dr["sstatus"].ToString(),
                    cid = Convert.ToInt16(dr["Cid"])


                });
            }
            return list;


        }



        public void update(Subcategory obj)
        {
            cmd = new SqlCommand("_updatesubcategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", obj.Name);
            cmd.Parameters.AddWithValue("@status", obj.isstatus ? "Active" : "Inactive");
            cmd.Parameters.AddWithValue("@id", obj.Id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void delete(int id)
        {
            cmd = new SqlCommand("_deletesubcategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }


    }
}