using Enterprise_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Enterprise_Web.Controllers.Api
{
    public class AdminController : ApiController
    {
        private WebEnterpriseEntities _db;
        public AdminController()
        {
            _db = new WebEnterpriseEntities();
        }
        //GET /api/Admin
        public IEnumerable<User_Admin_Detail> GetAdmin()
        {
            return _db.User_Admin_Detail.ToList();
        }

        //GET /api/Admin/1
        public User_Admin_Detail GetAdmin(int id)
        {
            var admin = _db.User_Admin_Detail.SingleOrDefault(c => c.admID == id);

            if (admin == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return admin;
        }

        //POST /api/Admin
        [HttpPost]
        public User_Admin_Detail CreateAdmin(User_Admin_Detail admin)
        {
            if (ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _db.User_Admin_Detail.Add(admin);
            _db.SaveChanges();

            return admin;
        }

        //PUT /api/Admin/1
        [HttpPut]
        public void UpdateAdmin(int id, User_Admin_Detail admin)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var adminInDb = _db.User_Admin_Detail.SingleOrDefault(c => c.admID == id);

            if (adminInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            adminInDb.admin_fullname = adminInDb.admin_fullname;
            adminInDb.admin_mail = adminInDb.admin_mail;
            adminInDb.admin_gender = adminInDb.admin_gender;
            adminInDb.admin_phone = adminInDb.admin_phone;
            adminInDb.admID = adminInDb.admID;
            adminInDb.admin_doB = adminInDb.admin_doB;
            adminInDb.userId = adminInDb.userId;

            _db.SaveChanges();
        }

        //Delete /api/Admin/1
        [HttpDelete]
        public void DeleteAdmin(int id)
        {
            var adminInDb = _db.User_Admin_Detail.SingleOrDefault(c => c.admID == id);

            if (adminInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _db.User_Admin_Detail.Remove(adminInDb);
            _db.SaveChanges();
        }
    }
}
