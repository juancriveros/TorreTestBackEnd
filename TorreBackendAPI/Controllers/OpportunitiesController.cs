using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorreBackend.API.Models;
using TorreBackend.Business;
using TorreBackend.Entities;

namespace TorreBackend.API.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class OpportunitiesController : ControllerBase
    {
        private readonly OpportunityBusiness opportunityBusiness;
        private readonly IMapper mapper;

        public OpportunitiesController(OpportunityBusiness opportunityBusiness, IMapper mapper)
        {
            this.opportunityBusiness = opportunityBusiness;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("Summary")]
        public async Task<ActionResult<IEnumerable<AggregatorSummaryModel>>> Get()
        {
            var topOpportunities = await opportunityBusiness.GetTopThreeJobs();

            var topOpportunitiesModel = mapper.Map<List<AggregatorSummaryModel>>(topOpportunities);

            return topOpportunitiesModel;
        }

        [HttpGet]
        [Route("Search")]
        public async Task<ActionResult<IEnumerable<SearchOpportunityResultModel>>> Search(int pageNumber, int offset, int size = 15, string name = "", bool? placeBased = null, string status = "", string type = "", string currency = "", string periodicity = "", double? amount = null, string  skill = "")
        {

            var opportunities = await opportunityBusiness.SearchOpportunities(pageNumber, size, offset, name, placeBased, status, type, currency, periodicity, amount, skill);

            Response.Headers["X-Offset"] = opportunityBusiness._offset.ToString();

            var opportunitiesModel = mapper.Map<List<SearchOpportunityResultModel>>(opportunities);

            return opportunitiesModel;
        }

    }
}
