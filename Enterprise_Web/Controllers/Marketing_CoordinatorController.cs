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
    public class Marketing_CoordinatorController : Controller
    {
        private WebEntepriseEntities db = new WebEntepriseEntities();

        // GET: Marketing_Coordinator
        public ActionResult Index()
        {
            var marketing_Coordinators = db.Marketing_Coordinators.Include(m => m.Faculty);
            return View(marketing_Coordinators.ToList());
        }

        // GET: Marketing_Coordinator/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marketing_Coordinator marketing_Coordinator = db.Marketing_Coordinators.Find(id);
            if (marketing_Coordinator == null)
            {
                return HttpNotFound();
            }
            return View(marketing_Coordinator);
        }

        // GET: Marketing_Coordinator/Create
        public ActionResult Create()
        {
            ViewBag.facID = new SelectList(db.Faculties, "facID", "facName");
            return View();
        }

        // POST: Marketing_Coordinator/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mkcID,mkc_username,mkc_password,mkc_fullname,mkc_mail,mkc_gender,mkc_doB,mkc_phone,facID")] Marketing_Coordinator marketing_Coordinator)
        {
            if (ModelState.IsValid)
            {
                db.Marketing_Coordinators.Add(marketing_Coordinator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.facID = new SelectList(db.Faculties, "facID", "facName", marketing_Coordinator.facID);
            return View(marketing_Coordinator);
        }

        // GET: Marketing_Coordinator/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marketing_Coordinator marketing_Coordinator = db.Marketing_Coordinators.Find(id);
            if (marketing_Coordinator == null)
            {
                return HttpNotFound();
            }
            ViewBag.facID = new SelectList(db.Faculties, "facID", "facName", marketing_Coordinator.facID);
            return View(marketing_Coordinator);
        }

        // POST: Marketing_Coordinator/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mkcID,mkc_username,mkc_password,mkc_fullname,mkc_mail,mkc_gender,mkc_doB,mkc_phone,facID")] Marketing_Coordinator marketing_Coordinator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marketing_Coordinator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.facID = new SelectList(db.Faculties, "facID", "facName", marketing_Coordinator.facID);
            return View(marketing_Coordinator);
        }

        // GET: Marketing_Coordinator/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marketing_Coordinator marketing_Coordinator = db.Marketing_Coordinators.Find(id);
            if (marketing_Coordinator == null)
            {
                return HttpNotFound();
            }
            return View(marketing_Coordinator);
        }

        // POST: Marketing_Coordinator/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Marketing_Coordinator marketing_Coordinator = db.Marketing_Coordinators.Find(id);
            db.Marketing_Coordinators.Remove(marketing_Coordinator);
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
