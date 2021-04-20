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
        public ActionResult Dashboard()
        {
            AspNetUser user = db.AspNetUsers.Find(User.Identity.GetUserId());
            var role = user.AspNetRoles.FirstOrDefault();
            switch (role.Id)
            {
                case "1": //if role is admin 
                    return RedirectToRoute("User_Admin_Detail/AdminDashboard");
                    break;
                case "2": //if role is admin 
                    return Redirect("User_Marketing_Manager_Detail/MmDashboard");
                    break;
                case "3": //if role is admin 
                    return RedirectToRoute("User_Marketing_Coordinator_Detail/McDashboard");
                    break;
                case "4": //if role is admin 
                    return RedirectToAction("StudentDashboard");
                    break;
                case "5": //if role is admin 
                    return Redirect("User_Guest_Detail/GuestDashboard");
                    break;
                default:
                    break;
            }
            return View();
        }
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
        
        public ActionResult File()
        {
            var path = Server.MapPath("~/Content/Files/");

            var dir = new DirectoryInfo(path);

            var files = dir.EnumerateFiles().Select(f => f.Name);

            return View(files);
        }

        [HttpPost]
        public ActionResult File(HttpPostedFileBase file)
        {
            var path = Path.Combine(Server.MapPath("~/Content/Files/"), file.FileName);

            var data = new byte[file.ContentLength];
            file.InputStream.Read(data, 0, file.ContentLength);

            using (var sw = new FileStream(path, FileMode.Create))
            {
                sw.Write(data, 0, data.Length);
            }

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["Email"].ToString());
            mailMessage.To.Add("luxubuno2@gmail.com");
            mailMessage.Subject = "Hello There";
            mailMessage.Body = "Hello my friend!";
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32(587));
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Email"].ToString(), ConfigurationManager.AppSettings["Password"].ToString());
            smtpClient.Credentials = credentials;
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);

            return RedirectToAction("File");
        }

       
        public ActionResult Create()
        {
            return View();
        }
        
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

            return Content("Success");
        }


        //Zip & Download all sellected article
        public ActionResult Download()
        {
            string[] imgs = Directory.GetFiles(
                            Server.MapPath("~/images"));
            string[] files = Directory.GetFiles(
                            Server.MapPath("~/Content/Files/"));
            var article = new[] { imgs, files}.SelectMany(id => id).ToList();
            List<string> downloads = new List<string>();
            foreach (string file in files)
            {
                downloads.Add(Path.GetFileName(file));
            }
            return View(downloads);
        }

        [HttpPost]
        public FileResult ProcessForm(List<string> selectedfiles)
        {
            if (System.IO.File.Exists(Server.MapPath
                              ("~/ZipFiles/bundle.zip")))
            {
                System.IO.File.Delete(Server.MapPath
                              ("~/ZipFiles/bundle.zip"));
            }
            ZipArchive zip = ZipFile.Open(Server.MapPath
                     ("~/ZipFiles/bundle.zip"), ZipArchiveMode.Create);
            foreach (string file in selectedfiles)
            {
                zip.CreateEntryFromFile(Server.MapPath
                     ("~/images/" + file), file);
            }
            zip.Dispose();
            string input = "Filename.zip";
            return File(Server.MapPath("~/ZipFiles/bundle.zip"),
                      "application/zip", input);
        }
        //public FileResult ProcessForm()
        //{
        //    string path = ExcelGenerationCode(fileName);
        //    return File(path, "application/vnd.ms-excel", "your download file name");
        //}
        
    }
}