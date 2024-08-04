using Mvc_Projetc.data;
using Mvc_Projetc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Projetc.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
      
        // GET: Category
        Categorydata categorydata = new Categorydata();
        public ActionResult Index(string search)
        {
            if (search != null)
            {
                var result = categorydata.search(search).ToList();
                return View(result);    
            }

            return View(categorydata.list().ToList());
        }

        [HttpGet]
        public ActionResult create() 
        {
            return View();
        }


        [HttpPost]
        public ActionResult create(Category obj)
        {
            categorydata.create(obj);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id) 
        {
          var result = categorydata.list().FirstOrDefault(x => x.id == id); 
            return View(result);    
        }

        [HttpPost]
        public ActionResult edit(Category obj) 
        {
          categorydata.update(obj);
            return RedirectToAction("Index");   
        }


        [HttpGet]
        public ActionResult delete(int id) 
        {
         var result = categorydata.list().FirstOrDefault(y => y.id == id);  
            return View(result);    
        }

        [HttpPost]  
        public ActionResult Delete(int id)
        {
            categorydata.delete(id);
            return RedirectToAction("Index");   
        }
    }
}