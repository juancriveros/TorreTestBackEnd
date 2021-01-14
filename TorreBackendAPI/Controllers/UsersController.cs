using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorreBackend.API.Models;
using TorreBackend.Business;
using TorreBackend.Entities;
using TorreBackendAPI;

namespace TorreBackend.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersBusiness usersBusiness;
        private readonly IMapper mapper;

        public UsersController(UsersBusiness usersBusiness, IMapper mapper)
        {
            this.usersBusiness = usersBusiness;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("Summary")]
        public async Task<ActionResult<IEnumerable<AggregatorSummaryModel>>> Get()
        {
            var topSkills = await usersBusiness.GetTopThreeUsersSkills();

            var topSkillsModel = mapper.Map<List<AggregatorSummaryModel>>(topSkills);

            return topSkillsModel;
        }

    }
}
