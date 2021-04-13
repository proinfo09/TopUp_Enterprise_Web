using Enterprise_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Enterprise_Web.Controllers.Api
{
    public class MarketingCordinatorController : ApiController
    {
        private WebEnterpriseEntities _db;
        public MarketingCordinatorController()
        {
            _db = new WebEnterpriseEntities();
        }
        //GET /api/maketingcordinator
        public IEnumerable<User_Marketing_Coordinator_Detail> GetMarketingC()
        {
            return _db.User_Marketing_Coordinator_Detail.ToList();
        }

        //GET /api/maketingcordinator/1
        public User_Marketing_Coordinator_Detail GetMarketingC(int id)
        {
            var marketc = _db.User_Marketing_Coordinator_Detail.SingleOrDefault(c => c.mkcID == id);

            if (marketc == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return marketc;
        }

        //POST /api/maketingcordinator
        [HttpPost]
        public User_Marketing_Coordinator_Detail CreateMarketingC(User_Marketing_Coordinator_Detail marketc)
        {
            if (ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _db.User_Marketing_Coordinator_Detail.Add(marketc);
            _db.SaveChanges();

            return marketc;
        }

        //PUT /api/maketingcordinator/1
        [HttpPut]
        public void UpdateMarketingC(int id, User_Marketing_Coordinator_Detail marketc)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var marketcInDb = _db.User_Marketing_Coordinator_Detail.SingleOrDefault(c => c.mkcID == id);

            if (marketcInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            marketcInDb.mkc_fullname = marketcInDb.mkc_fullname;
            marketcInDb.mkc_mail = marketcInDb.mkc_mail;
            marketcInDb.mkc_gender = marketcInDb.mkc_gender;
            marketcInDb.mkc_phone = marketcInDb.mkc_phone;
            marketcInDb.mkcID = marketcInDb.mkcID;
            marketcInDb.mkc_doB = marketcInDb.mkc_doB;
            marketcInDb.userId = marketcInDb.userId;

            _db.SaveChanges();
        }

        //Delete /api/maketingcordinator/1
        [HttpDelete]
        public void DeleteMarketingC(int id)
        {
            var marketcInDb = _db.User_Marketing_Coordinator_Detail.SingleOrDefault(c => c.mkcID == id);

            if (marketcInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _db.User_Marketing_Coordinator_Detail.Remove(marketcInDb);
            _db.SaveChanges();
        }
    }
}
