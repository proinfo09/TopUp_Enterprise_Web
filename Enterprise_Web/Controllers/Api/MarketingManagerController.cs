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
    public class MarketingManagerController : ApiController
    {
        private WebEnterpriseEntities _db;
        public MarketingManagerController()
        {
            _db = new WebEnterpriseEntities();
        }
        //GET /api/MarketingManager
        public IEnumerable<MmDto> GetMarketms()
        {
            return _db.User_Marketing_Manager_Detail.ToList().Select(Mapper.Map<User_Marketing_Manager_Detail, MmDto>);
        }

        //GET /api/MarketingManager/1
        public MmDto GetMarketm(int id)
        {
            var marketm = _db.User_Marketing_Manager_Detail.SingleOrDefault(c => c.mkmID == id);

            if (marketm == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<User_Marketing_Manager_Detail, MmDto>(marketm);
        }
            

            //POST /api/MarketingManager
            [HttpPost]
        public MmDto CreateMarketm(MmDto marketmDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var marketm = Mapper.Map<MmDto, User_Marketing_Manager_Detail>(marketmDto);
            _db.User_Marketing_Manager_Detail.Add(marketm);
            _db.SaveChanges();

            marketmDto.mkmID = marketm.mkmID;

            return marketmDto;
        }

        //PUT /api/MarketingManager/1
        [HttpPut]
        public void UpdateMarketm(int id, MmDto marketmDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var marketmInDb = _db.User_Marketing_Manager_Detail.SingleOrDefault(c => c.mkmID == id);

            if (marketmInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(marketmDto, marketmInDb);

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
