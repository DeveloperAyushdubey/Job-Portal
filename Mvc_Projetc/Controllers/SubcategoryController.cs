using Mvc_Projetc.data;
using Mvc_Projetc.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Mvc_Projetc.Controllers
{
    public class SubcategoryController : Controller
    {
        // GET: Subcategory
        Subcategorydata subcategorydata = new Subcategorydata();
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Const"].ToString());
        SqlCommand cmd = new SqlCommand();
        public ActionResult Index()
        {
            return View(subcategorydata.list().ToList());
        }


        [HttpGet]
        public ActionResult create()
        {
            List<Category> categories = new List<Category>();   
            cmd = new SqlCommand("_viewcategory", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) 
            {
              Category category = new Category
              {
                  name = reader["cname"].ToString(), 
                  id  = Convert.ToInt32(reader["cid"].ToString())
                  
              };
                categories.Add(category);   
            }
            ViewBag.data = new SelectList(categories, "id","name");
            
            return View();
        }


        [HttpPost]  
        public ActionResult create(Subcategory obj)
        {
            subcategorydata.create(obj);
            return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult Edit(int id) 
        {
            return View(subcategorydata.list().FirstOrDefault(x=>x.Id == id));
        }

        [HttpPost]  
        public ActionResult edit(Subcategory obj)
        {
            subcategorydata.update(obj);    
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Delete(int id) 
        {
            return View(subcategorydata.list().FirstOrDefault(x=>x.Id == id));

        }

        [HttpPost]  
        public ActionResult delete(int id)
        {

            subcategorydata.delete(id);
            return RedirectToAction("Index");   
        }
    }
}