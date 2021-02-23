using Enterprise_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Enterprise_Web.Controllers
{
    public class HomeController : Controller
    {
        private WebEntepriseEntities2 db = new WebEntepriseEntities2();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password, string roles)
        {
            switch (roles)
            {
                case "1": //if role is Student
                    var obj = db.Students.Where(a => a.std_username.Equals(username) &&
                   a.std_username.Equals(password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["ID"] = obj.stdID.ToString();
                        Session["Student_Username"] = obj.std_username.ToString();
                        return RedirectToAction("Index");
                    }
                    break;
                case "2"://if role is MM
                    var obj2 = db.Marketing_Managers.Where(a => a.mkm_username.Equals(username) &&
                   a.mkm_password.Equals(password)).FirstOrDefault();
                    if (obj2 != null)
                    {
                        Session["ID"] = obj2.mkmID.ToString();
                        Session["Marketing_Managers_UserName"] = obj2.mkm_username.ToString();
                        return RedirectToAction("Index");
                    }
                    break;
                case "3"://if role is MC
                    var obj3 = db.Marketing_Coordinators.Where(a => a.mkc_username.Equals(username) &&
                   a.mkc_password.Equals(password)).FirstOrDefault();
                    if (obj3 != null)
                    {
                        Session["ID"] = obj3.mkcID.ToString();
                        Session["Marketing_Coordinators_UserName"] = obj3.mkc_username.ToString();
                        return RedirectToAction("Index");
                    }
                    break;
                case "4"://if role is admin
                    var obj4 = db.Admins.Where(a => a.admin_username.Equals(username) &&
                    a.admin_password.Equals(password)).FirstOrDefault();
                    if (obj4 != null)
                    {
                        Session["ID"] = obj4.admID.ToString();
                        Session["Trainee_UserName"] = obj4.admin_username.ToString();
                        return RedirectToAction("Index");
                    }
                    break;
                default:
                    break;
            }
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }   

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}