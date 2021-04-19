using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Enterprise_Web.Models;
using Microsoft.AspNet.Identity;

namespace Enterprise_Web.Controllers
{
    public class User_Marketing_Coordinator_DetailController : Controller
    {
        private WebEnterpriseEntities db = new WebEnterpriseEntities();

        // GET: User_Marketing_Coordinator_Detail
        public ActionResult Index()
        {
            var user_Marketing_Coordinator_Detail = db.User_Marketing_Coordinator_Detail.Include(u => u.AspNetUser);
            return View(user_Marketing_Coordinator_Detail.ToList());
        }

        // GET: User_Marketing_Coordinator_Detail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Marketing_Coordinator_Detail user_Marketing_Coordinator_Detail = db.User_Marketing_Coordinator_Detail.Find(id);
            if (user_Marketing_Coordinator_Detail == null)
            {
                return HttpNotFound();
            }
            return View(user_Marketing_Coordinator_Detail);
        }

        // GET: User_Marketing_Coordinator_Detail/Create
        public ActionResult Create()
        {
            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: User_Marketing_Coordinator_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userId,mkcID,mkc_fullname,mkc_mail,mkc_gender,mkc_doB,mkc_phone")] User_Marketing_Coordinator_Detail user_Marketing_Coordinator_Detail)
        {
            if (ModelState.IsValid)
            {
                db.User_Marketing_Coordinator_Detail.Add(user_Marketing_Coordinator_Detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email", user_Marketing_Coordinator_Detail.userId);
            return View(user_Marketing_Coordinator_Detail);
        }

        // GET: User_Marketing_Coordinator_Detail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Marketing_Coordinator_Detail user_Marketing_Coordinator_Detail = db.User_Marketing_Coordinator_Detail.Find(id);
            if (user_Marketing_Coordinator_Detail == null)
            {
                return HttpNotFound();
            }
            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email", user_Marketing_Coordinator_Detail.userId);
            return View(user_Marketing_Coordinator_Detail);
        }

        // POST: User_Marketing_Coordinator_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userId,mkcID,mkc_fullname,mkc_mail,mkc_gender,mkc_doB,mkc_phone")] User_Marketing_Coordinator_Detail user_Marketing_Coordinator_Detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_Marketing_Coordinator_Detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email", user_Marketing_Coordinator_Detail.userId);
            return View(user_Marketing_Coordinator_Detail);
        }

        // GET: User_Marketing_Coordinator_Detail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Marketing_Coordinator_Detail user_Marketing_Coordinator_Detail = db.User_Marketing_Coordinator_Detail.Find(id);
            if (user_Marketing_Coordinator_Detail == null)
            {
                return HttpNotFound();
            }
            return View(user_Marketing_Coordinator_Detail);
        }

        // POST: User_Marketing_Coordinator_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User_Marketing_Coordinator_Detail user_Marketing_Coordinator_Detail = db.User_Marketing_Coordinator_Detail.Find(id);
            db.User_Marketing_Coordinator_Detail.Remove(user_Marketing_Coordinator_Detail);
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

        public ActionResult McDashboard()
        {           
            return View();
        }

        public ActionResult McProfile(int? id)
        {
            var userId = User.Identity.GetUserId();
            if (userId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser user = db.AspNetUsers.Find(userId);
            var mkc = user.User_Marketing_Coordinator_Detail.FirstOrDefault();
            if (mkc == null)
            {
                return HttpNotFound();
            }
            return View(mkc);
        }

        

    }
}
