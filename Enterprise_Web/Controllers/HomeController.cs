using Enterprise_Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PusherServer;
using System.IO.Compression;
using System.Net.Mail;
using System.Configuration;
using Microsoft.AspNet.Identity;

namespace Enterprise_Web.Controllers
{
    public class HomeController : Controller
    {
        private WebEnterpriseEntities db = new WebEnterpriseEntities();
        public ActionResult Index()
        {
            AspNetUser user = db.AspNetUsers.Find(User.Identity.GetUserId());
            var role = user.AspNetRoles.FirstOrDefault();
            switch (role.Id)
            {
                case "1": //if role is Admin 
                    return RedirectToAction("AdminDashboard", "User_Admin_Detail");
                    break;
                case "2": //if role is Marketing_Manager 
                    return RedirectToAction("MmDashBoard", "User_Marketing_Manager_Detail");
                    break;
                case "3": //if role is Marketing_Coordinator 
                    return RedirectToAction("McDashboard", "User_Marketing_Coordinator_Detail");
                    break;
                case "4": //if role is Student 
                    return RedirectToAction("StudentDashboard", "User_Student_Detail");
                    break;
                case "5": //if role is Guest 
                    return RedirectToAction("GuestDashboard", "User_Guest_Detail");
                    break;
                default:
                    break;
            }
            return View();
        }

        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult ClosureDate()
        {
            Closure_Day closure = db.Closure_Days.Find(
                
                
                
                );
            return Json(closure, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> Comment(Comment data)
        {
            db.Comments.Add(data);
            db.SaveChanges();
            var options = new PusherOptions();
            options.Cluster = "ap1";
            var pusher = new Pusher("1185884", "9711cf863b669984e1f2", "73a4067f2b75a0bfe4eb", options);
            ITriggerResult result = await pusher.TriggerAsync("asp_channel", "asp_event", data);
            return Content("ok");
        }
        public ActionResult TermCondi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TermCondi(TermCondiModels viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            return RedirectToAction("StudentDashboard", "User_Student_Detail");
        }

        public ActionResult Contact()
        {
            return View();
        }
        //public FileResult ProcessForm()
        //{
        //    string path = ExcelGenerationCode(fileName);
        //    return File(path, "application/vnd.ms-excel", "your download file name");
        //}
        
    }
}