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
        public IEnumerable<Contribution> GetContributions()
        {
            return _db.Contributions.ToList();
        }

        //GET /api/contributions/1
        public Contribution GetContribution(int id)
        {
            var contribution = _db.Contributions.SingleOrDefault(c => c.consID == id);

            if (contribution == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return contribution;
        }

        //POST /api/contribution
        [HttpPost]
        public Contribution CreateContribution(Contribution conntribution)
        {
            if (ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _db.Contributions.Add(conntribution);
            _db.SaveChanges();

            return conntribution;
        }

        //PUT /api/contribution/1
        [HttpPut]
        public void UpdateContribution(int id, Contribution contribution)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var contributionInDb = _db.Contributions.SingleOrDefault(c => c.consID == id);

            if (contributionInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            contributionInDb.cons_Name = contribution.cons_Name;
            contributionInDb.cons_comment = contribution.cons_comment;
            contributionInDb.cons_status = contribution.cons_status;
            contributionInDb.cons_submit = contribution.cons_submit;
            contributionInDb.stdID = contribution.stdID;
            contributionInDb.fileID = contribution.fileID;

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
