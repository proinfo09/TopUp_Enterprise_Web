using Enterprise_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Enterprise_Web.Controllers.Api
{
    public class MarketingManagerController : ApiController
    {
        private WebEnterpriseEntities _db;
        public MarketingManagerController()
        {
            _db = new WebEnterpriseEntities();
        }
        //GET /api/MarketingManager
        public IEnumerable<User_Marketing_Manager_Detail> GetMarketm()
        {
            return _db.User_Marketing_Manager_Detail.ToList();
        }

        //GET /api/MarketingManager/1
        public User_Marketing_Manager_Detail GetMarketm(int id)
        {
            var marketm = _db.User_Marketing_Manager_Detail.SingleOrDefault(c => c.mkmID == id);

            if (marketm == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return marketm;
        }
            

            //POST /api/MarketingManager
            [HttpPost]
        public User_Marketing_Manager_Detail CreateMarketm(User_Marketing_Manager_Detail marketm)
        {
            if (ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _db.User_Marketing_Manager_Detail.Add(marketm);
            _db.SaveChanges();

            return marketm;
        }

        //PUT /api/MarketingManager/1
        [HttpPut]
        public void UpdateMarketm(int id, User_Marketing_Manager_Detail marketm)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var marketmInDb = _db.User_Marketing_Manager_Detail.SingleOrDefault(c => c.mkmID == id);

            if (marketmInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

                marketmInDb.mkm_fullname = marketmInDb.mkm_fullname;
                marketmInDb.mkm_mail = marketmInDb.mkm_mail;
                marketmInDb.mkm_gender = marketmInDb.mkm_gender;
                marketmInDb.mkm_phone = marketmInDb.mkm_phone;
                marketmInDb.mkmID = marketmInDb.mkmID;
                marketmInDb.mkm_doB = marketmInDb.mkm_doB;
                marketmInDb.userId = marketmInDb.userId;

            _db.SaveChanges();
        }

        //Delete /api/MarketingManager/1
        [HttpDelete]
        public void DeleteMarketm(int id)
        {
            var marketmInDb = _db.User_Marketing_Manager_Detail.SingleOrDefault(c => c.mkmID == id);

            if (marketmInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _db.User_Marketing_Manager_Detail.Remove(marketmInDb);
            _db.SaveChanges();
        }
    }
}
