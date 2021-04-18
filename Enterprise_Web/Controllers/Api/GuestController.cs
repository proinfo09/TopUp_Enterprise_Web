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
    public class GuestController : ApiController
    {
        private WebEnterpriseEntities _db;
        public GuestController()
        {
            _db = new WebEnterpriseEntities();
        }
        //GET /api/Guest
        public IEnumerable<GuestDto> GetGuest()
        {
            return _db.User_Guest_Detail.ToList().Select(Mapper.Map<User_Guest_Detail, GuestDto>);
        }

        //GET /api/Guest/1
        public GuestDto GetGuest(int id)
        {
            var guest = _db.User_Guest_Detail.SingleOrDefault(c => c.gstID == id);

            if (guest == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<User_Guest_Detail, GuestDto>(guest);
        }

        //POST /api/Guest
        [HttpPost]
        public GuestDto CreateGuest(GuestDto guestDto)
        {
            if (ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var guest = Mapper.Map<GuestDto, User_Guest_Detail>(guestDto);
            _db.User_Guest_Detail.Add(guest);
            _db.SaveChanges();

            guestDto.gstID = guest.gstID;

            return guestDto;
        }

        //PUT /api/Guest/1
        [HttpPut]
        public void UpdateGuest(int id, GuestDto guestDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var guestInDb = _db.User_Guest_Detail.SingleOrDefault(c => c.gstID == id);

            if (guestInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(guestDto, guestInDb);

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
