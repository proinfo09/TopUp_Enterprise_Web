using Enterprise_Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Enterprise_Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
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
        public ActionResult Index()
        {
            return View();
        }
    }
}