using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorreBackend.API.Models;
using TorreBackend.Business;

namespace TorreBackend.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly OpportunityBusiness opportunityBusiness;
        private readonly UsersBusiness usersBusiness;
        private readonly IMapper mapper;

        public HomeController(OpportunityBusiness opportunityBusiness, UsersBusiness usersBusiness, IMapper mapper)
        {
            this.opportunityBusiness = opportunityBusiness;
            this.usersBusiness = usersBusiness;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("Summary")]
        public async Task<ActionResult<HomeSummaryModel>> Get()
        {
            var topOpportunities = await opportunityBusiness.GetTopThreeJobs();
            var topUsersSkills = await usersBusiness.GetTopThreeUsersSkills();

            var topOpportunitiesModel = mapper.Map<List<AggregatorSummaryModel>>(topOpportunities);
            var topUsersSkillssModel = mapper.Map<List<AggregatorSummaryModel>>(topUsersSkills);

            HomeSummaryModel result = new HomeSummaryModel()
            {
                Jobs = topOpportunitiesModel,
                Users = topUsersSkillssModel
            };

            return result;
        }

    }
}
