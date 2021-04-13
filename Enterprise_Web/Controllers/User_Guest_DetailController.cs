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
    public class User_Guest_DetailController : Controller
    {
        private WebEnterpriseEntities db = new WebEnterpriseEntities();

        // GET: User_Guest_Detail
        public ActionResult Index()
        {
            var user_Guest_Detail = db.User_Guest_Detail.Include(u => u.AspNetUser);
            return View(user_Guest_Detail.ToList());
        }

        // GET: User_Guest_Detail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Guest_Detail user_Guest_Detail = db.User_Guest_Detail.Find(id);
            if (user_Guest_Detail == null)
            {
                return HttpNotFound();
            }
            return View(user_Guest_Detail);
        }

        // GET: User_Guest_Detail/Create
        public ActionResult Create()
        {
            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: User_Guest_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userId,gstID,gst_fullname,gst_mail,gst_gender,gst_doB,gst_phone")] User_Guest_Detail user_Guest_Detail)
        {
            if (ModelState.IsValid)
            {
                db.User_Guest_Detail.Add(user_Guest_Detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email", user_Guest_Detail.userId);
            return View(user_Guest_Detail);
        }

        // GET: User_Guest_Detail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Guest_Detail user_Guest_Detail = db.User_Guest_Detail.Find(id);
            if (user_Guest_Detail == null)
            {
                return HttpNotFound();
            }
            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email", user_Guest_Detail.userId);
            return View(user_Guest_Detail);
        }

        // POST: User_Guest_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userId,gstID,gst_fullname,gst_mail,gst_gender,gst_doB,gst_phone")] User_Guest_Detail user_Guest_Detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_Guest_Detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email", user_Guest_Detail.userId);
            return View(user_Guest_Detail);
        }

        // GET: User_Guest_Detail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Guest_Detail user_Guest_Detail = db.User_Guest_Detail.Find(id);
            if (user_Guest_Detail == null)
            {
                return HttpNotFound();
            }
            return View(user_Guest_Detail);
        }

        // POST: User_Guest_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User_Guest_Detail user_Guest_Detail = db.User_Guest_Detail.Find(id);
            db.User_Guest_Detail.Remove(user_Guest_Detail);
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

        public ActionResult GuestDashboard()
        {
            return View();
        }

        public ActionResult GuestContribution(int? id)
        {
            var contributions = db.Contributions.Include(c => c.File).Include(c => c.User_Student_Detail);
            return View(contributions.ToList().Where(item => item.stdID != id));
        }
    }
}
