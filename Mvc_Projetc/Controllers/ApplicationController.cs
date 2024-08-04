using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Projetc.Controllers
{
    public class ApplicationController : Controller
    {
        // GET: Application
        MVC_JobportalEntities obj = new MVC_JobportalEntities();  
        public ActionResult Index()
        {

            return View(obj.ApplyApplications.ToList());
        }
    }
}