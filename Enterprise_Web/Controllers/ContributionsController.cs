using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Enterprise_Web.Models;

namespace Enterprise_Web.Controllers
{
    public class ContributionsController : Controller
    {
        private WebEnterpriseEntities db = new WebEnterpriseEntities();

        // GET: Contributions
        public ActionResult Index()
        {
            var contributions = db.Contributions.Include(c => c.File).Include(c => c.Image).Include(c => c.User_Student_Detail);
            return View(contributions.ToList());
        }

        // GET: Contributions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contribution contribution = db.Contributions.Find(id);
            if (contribution == null)
            {
                return HttpNotFound();
            }
            return View(contribution);
        }

        // GET: Contributions/Create
        public ActionResult Create()
        {
            ViewBag.fileID = new SelectList(db.Files, "fileID", "file_Title");
            ViewBag.imgID = new SelectList(db.Images, "imgID", "img_Title");
            ViewBag.stdID = new SelectList(db.User_Student_Detail, "stdID", "userId");
            return View();
        }

        // POST: Contributions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "consID,cons_Name,cons_comment,cons_submit,cons_status,imgID,stdID,fileID")] Contribution contribution)
        {
            if (ModelState.IsValid)
            {
                db.Contributions.Add(contribution);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fileID = new SelectList(db.Files, "fileID", "file_Title", contribution.fileID);
            ViewBag.imgID = new SelectList(db.Images, "imgID", "img_Title", contribution.imgID);
            ViewBag.stdID = new SelectList(db.User_Student_Detail, "stdID", "userId", contribution.stdID);
            return View(contribution);
        }

        // GET: Contributions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contribution contribution = db.Contributions.Find(id);
            if (contribution == null)
            {
                return HttpNotFound();
            }
            ViewBag.fileID = new SelectList(db.Files, "fileID", "file_Title", contribution.fileID);
            ViewBag.imgID = new SelectList(db.Images, "imgID", "img_Title", contribution.imgID);
            ViewBag.stdID = new SelectList(db.User_Student_Detail, "stdID", "userId", contribution.stdID);
            return View(contribution);
        }

        // POST: Contributions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "consID,cons_Name,cons_comment,cons_submit,cons_status,imgID,stdID,fileID")] Contribution contribution)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contribution).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fileID = new SelectList(db.Files, "fileID", "file_Title", contribution.fileID);
            ViewBag.imgID = new SelectList(db.Images, "imgID", "img_Title", contribution.imgID);
            ViewBag.stdID = new SelectList(db.User_Student_Detail, "stdID", "userId", contribution.stdID);
            return View(contribution);
        }

        // GET: Contributions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contribution contribution = db.Contributions.Find(id);
            if (contribution == null)
            {
                return HttpNotFound();
            }
            return View(contribution);
        }

        // POST: Contributions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contribution contribution = db.Contributions.Find(id);
            db.Contributions.Remove(contribution);
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
        public ActionResult ContributionManagments()
        {
            var contributions = db.Contributions.Include(c => c.File).Include(c => c.Image).Include(c => c.User_Student_Detail);
            return View(contributions.ToList());
        }
    }
}
