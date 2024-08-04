using Mvc_Projetc.data;
using Mvc_Projetc.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Mvc_Projetc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        Jobsdata jobs = new Jobsdata();
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Const"].ToString());
        SqlCommand cmd = new SqlCommand();

        ApplicationFormdata applicationFormdata = new ApplicationFormdata();    

        public ActionResult Index(string search)
        {
            if (search != null)
            {
                var result = jobs.search(search).ToList();
                return View(result);    
            }

            ViewBag.email = Session["Email"];
            return View(jobs.list().ToList());
        }

        [HttpGet]
        public ActionResult Details(int id) 
        {
          var rseult = jobs.list().FirstOrDefault(x=>x.Id == id);
            return View(rseult);
        }



        [HttpPost]
        [Authorize]
        public ActionResult details()
        {
            return View();
        }
       

        [HttpGet] ///////////// Apply Form \\\\\\\\\\\\\\\\\\\\
        public ActionResult create()
        {
            List<Jobs> jobs = new List<Jobs>();
            cmd = new SqlCommand("select * from job", con);
            cmd.CommandType = System.Data.CommandType.Text;
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Jobs oj = new Jobs
                {
                    Title = dataReader["jtitle"].ToString(),
                    Id = Convert.ToInt16(dataReader["jid"]), 
                    
                };
                jobs.Add(oj);
                
            }
            ViewBag.data = new SelectList(jobs, "Id", "Title");
            return View();  
        }


        [HttpPost]
        public ActionResult create(Applicationform obj , HttpPostedFileBase file)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                var name = Path.GetFileNameWithoutExtension(file.FileName);
                var path = Server.MapPath("~/App_Data/Resume");
                var fullpath = Path.Combine(path, name);

                file.SaveAs(fullpath);

                applicationFormdata.apply(new Applicationform
                {
                    name = obj.name,
                    email = obj.email,
                    education = obj.education,
                    Experience = obj.Experience,
                    jid = obj.jid,
                    resume = name

                });

                return RedirectToAction("Index", "Home");
            }
       
        }
    }
}