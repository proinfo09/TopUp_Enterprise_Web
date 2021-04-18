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
    public class MarketingCordinatorController : ApiController
    {
        private WebEnterpriseEntities _db;
        public MarketingCordinatorController()
        {
            _db = new WebEnterpriseEntities();
        }
        //GET /api/maketingcordinator
        public IEnumerable<McDto> GetMarketingCs()
        {
            return _db.User_Marketing_Coordinator_Detail.ToList().Select(Mapper.Map<User_Marketing_Coordinator_Detail, McDto>);
        }

        //GET /api/maketingcordinator/1
        public McDto GetMarketingC(int id)
        {
            var marketc = _db.User_Marketing_Coordinator_Detail.SingleOrDefault(c => c.mkcID == id);

            if (marketc == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<User_Marketing_Coordinator_Detail, McDto>(marketc);
        }

        //POST /api/maketingcordinator
        [HttpPost]
        public McDto CreateMarketingC(McDto marketcDto)
        {
            if (ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var marketc = Mapper.Map<McDto, User_Marketing_Coordinator_Detail>(marketcDto);
            _db.User_Marketing_Coordinator_Detail.Add(marketc);
            _db.SaveChanges();

            marketcDto.mkcID = marketc.mkcID;

            return marketcDto;
        }

        //PUT /api/maketingcordinator/1
        [HttpPut]
        public void UpdateMarketingC(int id, McDto marketcDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var marketcInDb = _db.User_Marketing_Coordinator_Detail.SingleOrDefault(c => c.mkcID == id);

            if (marketcInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(marketcDto, marketcInDb);

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
