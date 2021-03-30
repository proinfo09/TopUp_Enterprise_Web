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
    public class User_Admin_DetailController : Controller
    {
        private WebEnterpriseEntities db = new WebEnterpriseEntities();

        [Authorize(Roles = "Admin")]
        // GET: User_Admin_Detail
        public ActionResult Index()
        {
            var user_Admin_Detail = db.User_Admin_Detail.Include(u => u.AspNetUser);
            return View(user_Admin_Detail.ToList());
        }

        // GET: User_Admin_Detail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Admin_Detail user_Admin_Detail = db.User_Admin_Detail.Find(id);
            if (user_Admin_Detail == null)
            {
                return HttpNotFound();
            }
            return View(user_Admin_Detail);
        }

        // GET: User_Admin_Detail/Create
        public ActionResult Create()
        {
            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: User_Admin_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userId,admID,admin_fullname,admin_mail,admin_gender,admin_doB,admin_phone")] User_Admin_Detail user_Admin_Detail)
        {
            if (ModelState.IsValid)
            {
                db.User_Admin_Detail.Add(user_Admin_Detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email", user_Admin_Detail.userId);
            return View(user_Admin_Detail);
        }

        // GET: User_Admin_Detail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Admin_Detail user_Admin_Detail = db.User_Admin_Detail.Find(id);
            if (user_Admin_Detail == null)
            {
                return HttpNotFound();
            }
            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email", user_Admin_Detail.userId);
            return View(user_Admin_Detail);
        }

        // POST: User_Admin_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userId,admID,admin_fullname,admin_mail,admin_gender,admin_doB,admin_phone")] User_Admin_Detail user_Admin_Detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_Admin_Detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email", user_Admin_Detail.userId);
            return View(user_Admin_Detail);
        }

        // GET: User_Admin_Detail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Admin_Detail user_Admin_Detail = db.User_Admin_Detail.Find(id);
            if (user_Admin_Detail == null)
            {
                return HttpNotFound();
            }
            return View(user_Admin_Detail);
        }

        // POST: User_Admin_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User_Admin_Detail user_Admin_Detail = db.User_Admin_Detail.Find(id);
            db.User_Admin_Detail.Remove(user_Admin_Detail);
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
    }
}
