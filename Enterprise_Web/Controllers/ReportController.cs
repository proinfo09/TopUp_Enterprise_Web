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
        [HttpGet]
        public ActionResult Index()
        {
            //var total = db.Contributions.Where(x => x.consID.Equals("Total")).Count();
            return View();
        }
        public ActionResult GetDataTable()
        {
            int total = db.Contributions.Count();
            int selected = db.Contributions.Where(x => x.cons_status == "Selected").Count();
            int pending = db.Contributions.Where(x => x.cons_status == "Pending").Count();
            Report obj = new Report();
            obj.total = total;
            obj.selected = selected;
            obj.pending = pending;
            return Json(obj, JsonRequestBehavior.AllowGet);
            var Total = db.Contributions.Where(x => x.consID.Equals("Contribution")).Count();
            return View(Total);
        }
        

            
        public ActionResult GetDataChart()
        {
            int bussiness = db.Contributions.Where(x => x.User_Student_Detail.AspNetUser.facID == 3).Count();
            int eventmanage = db.Contributions.Where(x => x.User_Student_Detail.AspNetUser.facID == 4).Count();
            int graphic = db.Contributions.Where(x => x.User_Student_Detail.AspNetUser.facID == 2).Count();
            int it = db.Contributions.Where(x => x.User_Student_Detail.AspNetUser.facID == 1).Count();
            Ratio obj = new Ratio();
            obj.BusinessAdministration = bussiness;
            obj.EventManagement = eventmanage;
            obj.GraphicDesign = graphic;
            obj.InformationTechnology = it;

            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public class Ratio
        {
            public int BusinessAdministration { get; set; }
            public int EventManagement { get; set; }
            public int GraphicDesign { get; set; }
            public int InformationTechnology { get; set; }
        }
        public class Report
        {
            public int total { get; set; }
            public int selected { get; set; }
            public int pending { get; set; }
        }


    }
}