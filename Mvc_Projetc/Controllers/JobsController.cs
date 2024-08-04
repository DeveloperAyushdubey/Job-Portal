using Mvc_Projetc.data;
using Mvc_Projetc.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Mvc_Projetc.Controllers
{
    public class JobsController : Controller
    {
        // GET: Jobs
        Jobsdata jobsdata = new Jobsdata();
       
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Const"].ToString());
        SqlCommand cmd = new SqlCommand();

        public ActionResult Index(string search)
        {
            if (search != null)
            {
                var result = jobsdata.search(search).ToList();
                return View(result);    
            }
            return View(jobsdata.list().ToList());
        }

        [HttpGet]  
        public ActionResult create()
        {
            List<Subcategory> obj = new List<Subcategory>();    
            cmd = new SqlCommand("select * from subcategory",con);
            cmd.CommandType = System.Data.CommandType.Text; 
          con.Open();
            SqlDataReader dataReader  = cmd.ExecuteReader();
            while (dataReader.Read()) 
            {
              Subcategory subcategory = new Subcategory
              {
                  Name = dataReader["sname"].ToString(),
                  Id = Convert.ToInt32(dataReader["sid"].ToString())
              };  
                obj.Add(subcategory);
            }
            ViewBag.data = new SelectList(obj, "Id", "Name");
           
            return View();  
        }
        [HttpPost]
        public ActionResult create(Jobs jobs) 
        {
            if (ModelState.IsValid)
            {
                jobsdata.create(jobs);
                return RedirectToAction("Index");
            }
            return View();  
        }
        [HttpGet]
        public ActionResult delete(int id) 
        {
         var result = jobsdata.list().FirstOrDefault(x=> x.Id == id);   
            return View(result);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            jobsdata.delete(id);
            return RedirectToAction("Index");   
        }

        [HttpGet]
        public ActionResult update(int id)
        {
            var result = jobsdata.list().FirstOrDefault(x=>x.Id == id);

            return View(result);
        }
        [HttpPost]  
        public ActionResult Update(Jobs jobs)
        {
            if (ModelState.IsValid) 
            {
                jobsdata.update(jobs);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult details(int id)
        {
           var result = jobsdata.list().FirstOrDefault(x=>x.Id==id);
            return View(result);    
        }
    }
}