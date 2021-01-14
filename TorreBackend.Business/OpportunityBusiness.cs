using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorreBackend.Entities;

namespace TorreBackend.Business
{
    public class OpportunityBusiness
    {
        private readonly ApiClient _apiClient;

        public OpportunityBusiness(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        private async Task<OpportunitySearch> GetOpportunities(int size, bool aggregator, int offset)
        {
            var requestUrl = _apiClient.CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "opportunities/_search/"), "?size=" + size.ToString() + "&aggregate=" + aggregator.ToString().ToLower() + "&offset=" + offset.ToString());
            OpportunitySearch result = new OpportunitySearch();
            result = await _apiClient.PostAsync<OpportunitySearch>(requestUrl, result);
            return result;
        }

        public async Task<List<AgregatorValue>> GetTopThreeJobs()
        {

            OpportunitySearch resultQuery = await GetOpportunities(0, true, 0);

            List<AgregatorValue> topSkillsOpportunity = resultQuery.Aggregators.Skill.Take(3).ToList();

            return topSkillsOpportunity;

        }

    }
}
