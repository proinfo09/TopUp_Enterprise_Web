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
    public class Closure_DayController : Controller
    {
        private WebEntepriseEntities2 db = new WebEntepriseEntities2();

        // GET: Closure_Day
        public ActionResult Index()
        {
            return View(db.Closure_Days.ToList());
        }

        // GET: Closure_Day/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Closure_Day closure_Day = db.Closure_Days.Find(id);
            if (closure_Day == null)
            {
                return HttpNotFound();
            }
            return View(closure_Day);
        }

        // GET: Closure_Day/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Closure_Day/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "csdID,startDay,endDay,finalDay")] Closure_Day closure_Day)
        {
            if (ModelState.IsValid)
            {
                db.Closure_Days.Add(closure_Day);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(closure_Day);
        }

        // GET: Closure_Day/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Closure_Day closure_Day = db.Closure_Days.Find(id);
            if (closure_Day == null)
            {
                return HttpNotFound();
            }
            return View(closure_Day);
        }

        // POST: Closure_Day/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "csdID,startDay,endDay,finalDay")] Closure_Day closure_Day)
        {
            if (ModelState.IsValid)
            {
                db.Entry(closure_Day).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(closure_Day);
        }

        // GET: Closure_Day/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Closure_Day closure_Day = db.Closure_Days.Find(id);
            if (closure_Day == null)
            {
                return HttpNotFound();
            }
            return View(closure_Day);
        }

        // POST: Closure_Day/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Closure_Day closure_Day = db.Closure_Days.Find(id);
            db.Closure_Days.Remove(closure_Day);
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
