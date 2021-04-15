using Enterprise_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Enterprise_Web.Controllers
{
    public class ReportController : Controller
    {
        WebEnterpriseEntities db = new WebEnterpriseEntities();
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            int bussiness = db.Contributions.Where(x => x.User_Student_Detail.AspNetUser.facID == 3).Count();
            int eventmanage = db.Contributions.Where(x => x.User_Student_Detail.AspNetUser.facID == 4).Count();
            int graphic = db.Contributions.Where(x => x.User_Student_Detail.AspNetUser.facID == 2).Count();
            int it = db.Contributions.Where(x => x.User_Student_Detail.AspNetUser.facID == 1).Count();
            Ratio obj = new Ratio();
            obj.BusinessAdministratione = bussiness;
            obj.EventManagement = eventmanage;
            obj.GraphicDesign = graphic;
            obj.InformationTechnology = it;

            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public class Ratio
        {
            public int BusinessAdministratione { get; set; }
            public int EventManagement { get; set; }
            public int GraphicDesign { get; set; }
            public int InformationTechnology { get; set; }
        
        }
    }
}