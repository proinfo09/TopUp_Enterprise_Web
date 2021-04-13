using Enterprise_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Enterprise_Web.Controllers.Api
{
    public class GuestController : ApiController
    {
        private WebEnterpriseEntities _db;
        public GuestController()
        {
            _db = new WebEnterpriseEntities();
        }
        //GET /api/Guest
        public IEnumerable<User_Guest_Detail> GetGuest()
        {
            return _db.User_Guest_Detail.ToList();
        }

        //GET /api/Guest/1
        public User_Guest_Detail GetGuest(int id)
        {
            var guest = _db.User_Guest_Detail.SingleOrDefault(c => c.gstID == id);

            if (guest == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return guest;
        }

        //POST /api/Guest
        [HttpPost]
        public User_Guest_Detail CreateGuest(User_Guest_Detail guest)
        {
            if (ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _db.User_Guest_Detail.Add(guest);
            _db.SaveChanges();

            return guest;
        }

        //PUT /api/Guest/1
        [HttpPut]
        public void UpdateGuest(int id, User_Guest_Detail guest)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var guestInDb = _db.User_Guest_Detail.SingleOrDefault(c => c.gstID == id);

            if (guestInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            guestInDb.gst_fullname = guest.gst_fullname;
            guestInDb.gst_mail = guest.gst_mail;
            guestInDb.gst_gender = guest.gst_gender;
            guestInDb.gst_phone = guest.gst_phone;
            guestInDb.gstID = guest.gstID;
            guestInDb.gst_doB = guest.gst_doB;
            guestInDb.userId = guest.userId;

            _db.SaveChanges();
        }

        //Delete /api/Guest/1
        [HttpDelete]
        public void DeleteGuest(int id)
        {
            var guestInDb = _db.User_Guest_Detail.SingleOrDefault(c => c.gstID == id);

            if (guestInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _db.User_Guest_Detail.Remove(guestInDb);
            _db.SaveChanges();
        }
    }
}
