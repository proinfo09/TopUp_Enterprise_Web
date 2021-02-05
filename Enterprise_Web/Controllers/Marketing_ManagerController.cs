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
    public class Marketing_ManagerController : Controller
    {
        private WebEntepriseEntities2 db = new WebEntepriseEntities2();

        // GET: Marketing_Manager
        public ActionResult Index()
        {
            return View(db.Marketing_Managers.ToList());
        }

        // GET: Marketing_Manager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marketing_Manager marketing_Manager = db.Marketing_Managers.Find(id);
            if (marketing_Manager == null)
            {
                return HttpNotFound();
            }
            return View(marketing_Manager);
        }

        // GET: Marketing_Manager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marketing_Manager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mkmID,mkm_username,mkm_password,mkm_fullname,mkm_mail,mkm_gender,mkm_doB,mkm_phone")] Marketing_Manager marketing_Manager)
        {
            if (ModelState.IsValid)
            {
                db.Marketing_Managers.Add(marketing_Manager);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(marketing_Manager);
        }

        // GET: Marketing_Manager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marketing_Manager marketing_Manager = db.Marketing_Managers.Find(id);
            if (marketing_Manager == null)
            {
                return HttpNotFound();
            }
            return View(marketing_Manager);
        }

        // POST: Marketing_Manager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mkmID,mkm_username,mkm_password,mkm_fullname,mkm_mail,mkm_gender,mkm_doB,mkm_phone")] Marketing_Manager marketing_Manager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marketing_Manager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(marketing_Manager);
        }

        // GET: Marketing_Manager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marketing_Manager marketing_Manager = db.Marketing_Managers.Find(id);
            if (marketing_Manager == null)
            {
                return HttpNotFound();
            }
            return View(marketing_Manager);
        }

        // POST: Marketing_Manager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Marketing_Manager marketing_Manager = db.Marketing_Managers.Find(id);
            db.Marketing_Managers.Remove(marketing_Manager);
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
