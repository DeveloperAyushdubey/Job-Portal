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
    public class Jobsdata
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Const"].ToString());
        SqlCommand cmd = new SqlCommand();

        public void create(Jobs obj)
        {
           
          
                cmd = new SqlCommand("_insertjob", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@title",obj.Title);
                cmd.Parameters.AddWithValue("@companyname",obj.companyname);
                cmd.Parameters.AddWithValue("@skills",obj.skills);
                cmd.Parameters.AddWithValue("@duration",obj.duration);
                cmd.Parameters.AddWithValue("@description",obj.Description);
                cmd.Parameters.AddWithValue("@education",obj.education);
                cmd.Parameters.AddWithValue("@experience",obj.Experience);
                cmd.Parameters.AddWithValue("@location",obj.location);
                cmd.Parameters.AddWithValue("@qualification", obj.qulification);
                cmd.Parameters.AddWithValue("@postion",obj.position);
                cmd.Parameters.AddWithValue("@responsibilities",obj.responsibilities);
                cmd.Parameters.AddWithValue("@city",obj.city);
                cmd.Parameters.AddWithValue("@country",obj.country);
                cmd.Parameters.AddWithValue("@state",obj.state);
                cmd.Parameters.AddWithValue("@ctc",obj.ctc);
                cmd.Parameters.AddWithValue("@id",obj.sid);
         
              
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            
        }



        public List<Jobs> list()
        {
            List<Jobs> list = new List<Jobs>();
            cmd = new SqlCommand("select * from job", con);
            cmd.CommandType = System.Data.CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            foreach (DataRow dr in dataTable.Rows)
            {
                list.Add(new Jobs
                {
                    Id = Convert.ToInt16(dr["jid"]),
                    Title = dr["jtitle"].ToString(),
                    companyname = dr["jcompanyname"].ToString(),
                    duration = dr["jduration"].ToString(),
                    skills = dr["jskills"].ToString(),
                    education = dr["jeducation"].ToString(),
                    state = dr["jstate"].ToString(),
                    country = dr["jcountry"].ToString(),
                    city = dr["jcity"].ToString(),
                    ctc = dr["jctc"].ToString(),
                    Experience = dr["jexperience"].ToString(),
                    responsibilities = dr["jresponsibilities"].ToString(),
                 
                    location = dr["jlocation"].ToString(),
                    Description = dr["jdescription"].ToString(),
                    position = dr["jpostion"].ToString(),
                    qulification = dr["jqualification"].ToString()
                });
            }
            return list;
        }



        public List<Jobs> search(string name)
        {
            List<Jobs> list = new List<Jobs>();
            cmd = new SqlCommand("_searchjob", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@key", name);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            ad.Fill(dataTable);
            foreach (DataRow dr in dataTable.Rows)
            {
                list.Add(new Jobs
                {
                  
                    Title = dr["jtitle"].ToString(),
                    companyname = dr["jcompanyname"].ToString(),
                    
                    skills = dr["jskills"].ToString(),
                   
                    
                 
                    location = dr["jlocation"].ToString(),
                   


                });
            }
            return list;


        }



        public void update(Jobs obj)
        {
            cmd = new SqlCommand("_updatejob", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@title", obj.Title);
            cmd.Parameters.AddWithValue("@skills", obj.skills);
            cmd.Parameters.AddWithValue("@duration", obj.duration);
            cmd.Parameters.AddWithValue("@description", obj.Description);
            cmd.Parameters.AddWithValue("@experience", obj.Experience);
            cmd.Parameters.AddWithValue("@location", obj.location);
            cmd.Parameters.AddWithValue("@qualification", obj.qulification);
            cmd.Parameters.AddWithValue("@responsibilities", obj.responsibilities);
            cmd.Parameters.AddWithValue("@postion", obj.position);

            cmd.Parameters.AddWithValue("@ctc", obj.ctc);
            cmd.Parameters.AddWithValue("@id", obj.Id);
           

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void delete(int id)
        {
            cmd = new SqlCommand("_deletejob", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}