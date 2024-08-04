using Mvc_Projetc.data;
using Mvc_Projetc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mvc_Projetc.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        MVC_JobportalEntities mVC_Jobportal = new MVC_JobportalEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admintable admintable)
        {

            if (ModelState.IsValid)
            {
                mVC_Jobportal.Admintables.Add(new Admintable
                {
                    name = admintable.name,
                    email = admintable.email,
                    pass = admintable.pass,
                    phone = admintable.phone
                });
                mVC_Jobportal.SaveChanges();
                FormsAuthentication.SetAuthCookie(admintable.email, false);
                return RedirectToAction("Index", "Category");
            }
            return View();
        }



        [HttpGet]
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(Admintable admintable)
        {
            bool isvalid = mVC_Jobportal.Admintables.Any(x=>x.email == admintable.email && x.pass == admintable.pass);
            if (isvalid)
            {
                FormsAuthentication.SetAuthCookie(admintable.email, true);
                return RedirectToAction("Index", "Category");
            }
            return View();
        }


        [HttpPost]
        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Account");
        }

    }
}