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
    public class ContributionsController : ApiController
    {
        private WebEnterpriseEntities _db;
        public ContributionsController()
        {
            _db = new WebEnterpriseEntities();
        }
        //GET /api/Contribution
        public IEnumerable<ContributionDto> GetContributions()
        {
            return _db.Contributions.ToList().Select(Mapper.Map<Contribution, ContributionDto>);
        }

        //GET /api/contributions/1
        public ContributionDto GetContribution(int id)
        {
            var contribution = _db.Contributions.SingleOrDefault(c => c.consID == id);

            if (contribution == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map < Contribution, ContributionDto > (contribution);
        }

        //POST /api/contribution
        [HttpPost]
        public ContributionDto CreateContribution(ContributionDto contributionDto)
        {
            if (ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var contribution = Mapper.Map<ContributionDto, Contribution>(contributionDto);
            _db.Contributions.Add(contribution);
            _db.SaveChanges();

            contributionDto.consID = contribution.consID;

            return contributionDto;
        }

        //PUT /api/contribution/1
        [HttpPut]
        public void UpdateContribution(int id, ContributionDto contributionDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var contributionInDb = _db.Contributions.SingleOrDefault(c => c.consID == id);

            if (contributionInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(contributionDto, contributionInDb); 
   
            _db.SaveChanges();
        }

        //Delete /api/contribution/1
        [HttpDelete]
        public void DeleteContribution (int id)
        {
            var contributionInDb = _db.Contributions.SingleOrDefault(c => c.consID == id);

            if (contributionInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _db.Contributions.Remove(contributionInDb);
            _db.SaveChanges();
        }
    }
}
