using AutoMapper;
using Enterprise_Web.Dtos;
using Enterprise_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public IEnumerable<AdminDto> GetAdmin()
        {
            return _db.User_Admin_Detail.ToList().Select(Mapper.Map<User_Admin_Detail, AdminDto>);
        }

        //GET /api/Admin/1
        public AdminDto GetAdmin(int id)
        {
            var admin = _db.User_Admin_Detail.SingleOrDefault(c => c.admID == id);

            if (admin == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<User_Admin_Detail, AdminDto>(admin);
        }

        //POST /api/Admin
        [HttpPost]
        public AdminDto CreateAdmin(AdminDto adminDto)
        {
            if (ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var admin = Mapper.Map<AdminDto, User_Admin_Detail>(adminDto);
            _db.User_Admin_Detail.Add(admin);
            _db.SaveChanges();

            adminDto.admID = admin.admID;

            return adminDto;
        }

        //PUT /api/Admin/1
        [HttpPut]
        public void UpdateAdmin(int id, AdminDto adminDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var adminInDb = _db.User_Admin_Detail.SingleOrDefault(c => c.admID == id);

            if (adminInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(adminDto, adminInDb);

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
