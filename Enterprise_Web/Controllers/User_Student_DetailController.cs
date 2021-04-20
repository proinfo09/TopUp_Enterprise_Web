using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Enterprise_Web.Models;
using Microsoft.AspNet.Identity;
using OfficeOpenXml;
using PusherServer;

namespace Enterprise_Web.Controllers
{
    public class User_Student_DetailController : Controller
    {
        private WebEnterpriseEntities db = new WebEnterpriseEntities();

        // GET: User_Student_Detail
        public ActionResult Index()
        {
            var user_Student_Detail = db.User_Student_Detail.Include(u => u.AspNetUser);
            ViewBag.roleID = new SelectList(db.AspNetRoles, "Id", "Name");
            //ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email", user_Student_Detail.userId);
            return View(user_Student_Detail.ToList());
        }

        public ActionResult Export()
        {
            var user_Student_Detail = db.User_Student_Detail.Include(u => u.AspNetUser);
            List<UserViewModel> userViews = db.User_Student_Detail.Select(x => new UserViewModel
            {
                userId = x.userId,
                stdID = x.stdID,
                std_fullname = x.std_fullname,
                std_mail = x.std_mail,
                std_gender = x.std_gender,
                std_phone = x.std_phone,
                std_doB = x.std_doB

            }).ToList();
            return View(userViews);
        }

        public void ExportToExcel()
        {
            List<UserViewModel> userViews = db.User_Student_Detail.Select(x => new UserViewModel
            {
                userId = x.userId,
                stdID = x.stdID,
                std_fullname = x.std_fullname,
                std_mail = x.std_mail,
                std_gender = x.std_gender,
                std_phone = x.std_phone,
                std_doB = x.std_doB

            }).ToList();

            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");

            ws.Cells["A1"].Value = "Report";
            ws.Cells["B1"].Value = "Report1";

            ws.Cells["A2"].Value = "Date";
            ws.Cells["B2"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);

            ws.Cells["A4"].Value = "userId";
            ws.Cells["B4"].Value = "stdID";
            ws.Cells["C4"].Value = "std_fullname";
            ws.Cells["D4"].Value = "std_mail";
            ws.Cells["E4"].Value = "std_gender";
            ws.Cells["F4"].Value = "std_phone";
            ws.Cells["G4"].Value = "std_doB";

            int rowStart = 5;
            foreach (var item in userViews)
            {
                ws.Cells[string.Format("A{0}", rowStart)].Value = item.userId;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.stdID;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.std_fullname;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.std_mail;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.std_gender;
                ws.Cells[string.Format("F{0}", rowStart)].Value = item.std_phone;
                ws.Cells[string.Format("G{0}", rowStart)].Value = item.std_doB;
                rowStart++;
            }

            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();

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
                return RedirectToAction("Index", "Home");
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
        public ActionResult StudentProfile()
        {
            var userId = User.Identity.GetUserId();
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
            return View(std);
        }

        public ActionResult StudentContribution()
        {

            var userId = User.Identity.GetUserId();
            var contributions = db.Contributions.Include(c => c.File).Include(c => c.User_Student_Detail);
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
        public ActionResult CreateContribution(ContributionViewModels model, HttpPostedFileBase file)
        {
            var userId = User.Identity.GetUserId();
            AspNetUser user = db.AspNetUsers.Find(userId);
            var std = user.User_Student_Detail.FirstOrDefault();
            Models.File title = new Models.File();
            Contribution contribution = new Contribution();
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
            var lastFileId = title.fileID;
            contribution.consID = model.consID;
            contribution.cons_Name = model.cons_Name;
            contribution.cons_comment = model.cons_comment;
            contribution.cons_status = ContributionViewModels.Available;
            contribution.cons_submit = DateTime.Now;
            contribution.stdID = std.stdID;
            contribution.fileID = lastFileId;
            db.Contributions.Add(contribution);
            db.SaveChanges();

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["Email"].ToString());
            mailMessage.To.Add("duonghieu0402@gmail.com");
            mailMessage.Subject = "Comment Student Contribution";
            mailMessage.Body = "Student " + std.std_fullname + " just upload the contribution please comment within 14 days.";
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32(587));
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Email"].ToString(), ConfigurationManager.AppSettings["Password"].ToString());
            smtpClient.Credentials = credentials;
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);

            return RedirectToAction("StudentDashboard");

            //var facID = user.Faculty.facID;
            //var roleId = 2;
            //AspNetUser userMc = db.AspNetUsers.AspNetRoles.Find(roleId);
            //var role = user.AspNetRoles.Where(c => c.Id == "2").FirstOrDefault();

        }

        // GET: Contributions/Edit/5
        public ActionResult EditContribution(int? id)
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
            ViewBag.stdID = new SelectList(db.User_Student_Detail, "stdID", "userId", contribution.stdID);
            return View(contribution);
        }

        // POST: Contributions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditContribution([Bind(Include = "consID,cons_Name,cons_comment,cons_submit,cons_status,stdID,fileID")] Contribution contribution)
        {
            if (ModelState.IsValid)
            {
                contribution.cons_submit = DateTime.Now;
                db.Entry(contribution).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fileID = new SelectList(db.Files, "fileID", "file_Title", contribution.fileID);
            ViewBag.stdID = new SelectList(db.User_Student_Detail, "stdID", "userId", contribution.stdID);
            return View(contribution);
        }

        // GET: CreateImage
        public ActionResult CreateImage(int? id)
        {
            Contribution contribution = db.Contributions.Find(id);
            return View(db.Images.ToList().Where(item => item.consID == contribution.consID));
        }

        [HttpPost]
        public ActionResult CreateImage(HttpPostedFileBase postedFile, int id)
        {
            byte[] bytes;
            using (BinaryReader br = new BinaryReader(postedFile.InputStream))
            {
                bytes = br.ReadBytes(postedFile.ContentLength);
            }
            var path = Path.Combine(Server.MapPath("~/Content/Files/"), postedFile.FileName);

            var data = new byte[postedFile.ContentLength];
            postedFile.InputStream.Read(data, 0, postedFile.ContentLength);

            using (var sw = new FileStream(path, FileMode.Create))
            {
                sw.Write(data, 0, data.Length);
            }
            db.Images.Add(new Image
            {
                consID = id,
                img_Title = Path.GetFileName(postedFile.FileName),
                ContentType = postedFile.ContentType,
                Data = bytes
            });
            db.SaveChanges();
            return RedirectToAction("Create");
        }

        public ActionResult DetailsContribution(int? id)
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

        public ActionResult Comments(int? id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var comments = db.Comments.Where(x => x.consID == id).ToArray();
            return Json(comments, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> Comment(Comment data)
        {
            db.Comments.Add(data);
            db.SaveChanges();
            var options = new PusherOptions();
            options.Cluster = "ap1";
            var pusher = new Pusher("1185884", "9711cf863b669984e1f2", "73a4067f2b75a0bfe4eb", options);
            ITriggerResult result = await pusher.TriggerAsync("asp_channel", "asp_event", data);
            return Content("ok");
        }

        public ActionResult ClosureDate()
        {
            
           Closure_Day closure = db.Closure_Days.Find(db.Closure_Days.Max(c => c.csdID));
            return Json(closure, JsonRequestBehavior.AllowGet);
        }

        // GET: Student/Details/5
        //public ActionResult A()
        //{
        //    var userId = User.Identity.GetUserId();
        //    if (userId == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AspNetUser user = db.AspNetUsers.Find(userId);
        //    var std = user.User_Admin_Detail.FirstOrDefault();
        //    if (std == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(std);
        //}
    }
}
