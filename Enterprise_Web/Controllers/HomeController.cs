using Enterprise_Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PusherServer;


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
    }
}