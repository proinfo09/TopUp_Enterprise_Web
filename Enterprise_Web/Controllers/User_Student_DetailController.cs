using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Enterprise_Web.Models;
using Microsoft.AspNet.Identity;

namespace Enterprise_Web.Controllers
{
    public class User_Student_DetailController : Controller
    {
        private WebEnterpriseEntities db = new WebEnterpriseEntities();

        // GET: User_Student_Detail
        public ActionResult Index()
        {
            var user_Student_Detail = db.User_Student_Detail.Include(u => u.AspNetUser);
            return View(user_Student_Detail.ToList());
        }

        // GET: User_Student_Detail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Student_Detail user_Student_Detail = db.User_Student_Detail.Find(id);
            if (user_Student_Detail == null)
            {
                return HttpNotFound();
            }
            return View(user_Student_Detail);
        }

        // GET: User_Student_Detail/Create
        public ActionResult Create()
        {
            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: User_Student_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userId,stdID,std_fullname,std_mail,std_gender,std_doB,std_phone")] User_Student_Detail user_Student_Detail)
        {
            if (ModelState.IsValid)
            {
                db.User_Student_Detail.Add(user_Student_Detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email", user_Student_Detail.userId);
            return View(user_Student_Detail);
        }

        // GET: User_Student_Detail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Student_Detail user_Student_Detail = db.User_Student_Detail.Find(id);
            if (user_Student_Detail == null)
            {
                return HttpNotFound();
            }
            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email", user_Student_Detail.userId);
            return View(user_Student_Detail);
        }

        // POST: User_Student_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userId,stdID,std_fullname,std_mail,std_gender,std_doB,std_phone")] User_Student_Detail user_Student_Detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_Student_Detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email", user_Student_Detail.userId);
            return View(user_Student_Detail);
        }

        // GET: User_Student_Detail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Student_Detail user_Student_Detail = db.User_Student_Detail.Find(id);
            if (user_Student_Detail == null)
            {
                return HttpNotFound();
            }
            return View(user_Student_Detail);
        }

        // POST: User_Student_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User_Student_Detail user_Student_Detail = db.User_Student_Detail.Find(id);
            db.User_Student_Detail.Remove(user_Student_Detail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: User_Student_Detail
        public ActionResult StudentDashboard()
        {
            return View();
        }

        // GET: User_Student_Detail/Details/5
        public ActionResult StudentProfile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Student_Detail user_Student_Detail = db.User_Student_Detail.Find(id);
            if (user_Student_Detail == null)
            {
                return HttpNotFound();
            }
            return View(user_Student_Detail);
        }

        public ActionResult StudentContribution()
        {

            var userId = User.Identity.GetUserId();
            var contributions = db.Contributions.Include(c => c.File).Include(c => c.Image).Include(c => c.User_Student_Detail);
            if (userId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser user = db.AspNetUsers.Find(userId);
            var std = user.User_Student_Detail.FirstOrDefault();
            
            if (std == null)
            {
                return HttpNotFound();
            }
            return View(contributions.ToList().Where(item => item.stdID == std.stdID));
        }

        public ActionResult CreateContribution()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateContribution(ContributionViewModels model, HttpPostedFileBase file, HttpPostedFileBase imgfile)
        {
            Image image = new Image();
            Models.File title = new Models.File();
            Contribution contribution = new Contribution();
            if (ModelState.IsValid)
            {
                //add file doc
                var path = Path.Combine(Server.MapPath("~/Content/Files/"), file.FileName);

                var data = new byte[file.ContentLength];
                file.InputStream.Read(data, 0, file.ContentLength);

                using (var sw = new FileStream(path, FileMode.Create))
                {
                    sw.Write(data, 0, data.Length);
                }
                if (file != null)
                {
                    title.file_Title = file.FileName;
                }
                db.Files.Add(title);
                db.SaveChanges();

                //add image

                if (imgfile != null)
                {
                    imgfile.SaveAs(HttpContext.Server.MapPath("~/image/")+ imgfile.FileName);
                    image.img_Title = imgfile.FileName;
                }
                db.Images.Add(image);
                db.SaveChanges();
                

                int latestFileId = image.imgID;
                int latestImageId = title.fileID;

                contribution.consID = model.consID;
                contribution.cons_Name = model.cons_Name;
                contribution.cons_comment = model.cons_comment;
                contribution.cons_status = model.cons_status;
                contribution.cons_submit = model.cons_submit;
                contribution.fileID = latestFileId;
                contribution.imgID = latestImageId;
                contribution.stdID = model.stdID;
                db.Contributions.Add(contribution);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fileID = new SelectList(db.Files, "fileID", "file_Title", contribution.fileID);
            ViewBag.imgID = new SelectList(db.Images, "imgID", "img_Title", contribution.imgID);
            ViewBag.stdID = new SelectList(db.User_Student_Detail, "stdID", "userId", contribution.stdID);
            return View(contribution);
        }
    }
}
