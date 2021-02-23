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
    public class StudentsController : Controller
    {
        private WebEntepriseEntities2 db = new WebEntepriseEntities2();

        // GET: Students
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.Faculty);
            return View(students);
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Student student)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                var obj = db.Students.Where(a => a.std_username.Equals(student.std_username) &&
                                     a.std_password.Equals(student.std_password)).FirstOrDefault();
                if (obj != null)
                {
                    Session["StudentID"] = obj.stdID.ToString();
                    Session["Student_UserName"] = obj.std_username.ToString();
                    return RedirectToAction("StaffDashBoard");
                }
            }
            return View(student);
        }

        public ActionResult Style_Index()
        {
            var students = db.Students.Include(s => s.Faculty);
            return View(students);
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.facID = new SelectList(db.Faculties, "facID", "facName");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "stdID,std_username,std_password,std_fullname,std_mail,std_gender,std_doB,std_phone,facID")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.facID = new SelectList(db.Faculties, "facID", "facName", student.facID);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.facID = new SelectList(db.Faculties, "facID", "facName", student.facID);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "stdID,std_username,std_password,std_fullname,std_mail,std_gender,std_doB,std_phone,facID")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.facID = new SelectList(db.Faculties, "facID", "facName", student.facID);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ContributionsManagement()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult StudentDashBoard()
        { 
            return View();
        }

        public ActionResult ChangePassword()
        {
                return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(string old_password, string new_password, string confirm_password)
        {
            string std_username = Session["Student_UserName"].ToString();
            var obj = db.Students.Where(a => a.std_username.Equals(std_username) &&
                    a.std_username.Equals(old_password)).FirstOrDefault();
            if (obj != null)
            {
                if (new_password.Equals(confirm_password))
                {
                    obj.std_username = new_password;
                    db.SaveChanges();
                    return RedirectToAction("StudentDashBoard");
                }
            }
            ViewData["Message"] = "Old password is not correct or New password" + "Confirm New Password are not match";
            return View();
        }

        public ActionResult StudentProfile()
        {
            int stdId = Convert.ToInt32(Session["ID"]);
            //if (stdId == 0)
            //{
            //    return RedirectToAction("Login", "Home");
            //}
            return View(db.Students.Find(stdId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StudentProfile([Bind(Include = "stdID,std_username,std_password,std_fullname,std_mail,std_gender,std_doB,std_phone,facID")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("UpdateInfo");
            }
            return View(student);
        }
    }
}
