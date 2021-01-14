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
        [Route("GetSummary")]
        public async Task<ActionResult<IEnumerable<AggregatorSummaryModel>>> Get()
        {
            var topOpportunities = await opportunityBusiness.GetTopThreeJobs();

            var topOpportunitiesModel = mapper.Map<List<AggregatorSummaryModel>>(topOpportunities);

            return topOpportunitiesModel;
        }

    }
}
