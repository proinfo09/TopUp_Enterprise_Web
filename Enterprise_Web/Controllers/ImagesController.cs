using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Enterprise_Web.Models;

namespace Enterprise_Web.Controllers
{
    public class ImagesController : Controller
    {
        private WebEnterpriseEntities db = new WebEnterpriseEntities();
        
         [HttpGet]
         public ActionResult Add()
        {
            ViewBag.consID= new SelectList(db.Contributions, "consID", "cons_Name");
            return View();
        }

        [HttpPost]
        public ActionResult Add(Image imageModel)
        {
            ViewBag.consID = new SelectList(db.Contributions, "consID", "cons_Name");
            string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
            string extention = Path.GetExtension(imageModel.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("mmddyy") + extention;
            imageModel.ContentType = "~/~?Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/~/Images/"), fileName);
            imageModel.ImageFile.SaveAs(fileName);
            db.Images.Add(imageModel);
            db.SaveChanges();
            ModelState.Clear();
            return View();
        }
        [HttpGet]
        public ActionResult View(int id)
        {
            Image imageModel = new Image();
            imageModel = db.Images.Where(x => x.imgID == id).FirstOrDefault();

            return View(imageModel);
        }
        
    }    
}
