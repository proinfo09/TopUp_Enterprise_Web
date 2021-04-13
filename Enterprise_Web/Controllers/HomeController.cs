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

namespace Enterprise_Web.Controllers
{
    public class HomeController : Controller
    {
        private WebEnterpriseEntities db = new WebEnterpriseEntities();
        public ActionResult Index1()
        {
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

        
        public ActionResult Index()
        {
            return View(db.BlogPosts.AsQueryable());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BlogPost post)
        {
            db.BlogPosts.Add(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            return View(db.BlogPosts.Find(id));
        }

        public ActionResult Comments(int? id)
        {
            var comments = db.Comments.Where(x => x.BlogPostID == id).ToArray();
            return Json(comments, JsonRequestBehavior.AllowGet);
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
        //public ActionResult Index()
        //{
        //    return View();
        //}


        //Zip & Download all sellected article
        public ActionResult Download()
        {
            string[] files = Directory.GetFiles(
                            Server.MapPath("~/images"));
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