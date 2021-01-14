using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorreBackend.Entities;

namespace TorreBackend.Business
{
    public class UsersBusiness
    {
        private readonly ApiClient _apiClient;

        public UsersBusiness(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        private async Task<PersonSearch> GetUsers(int size, bool aggregator, int offset)
        {
            var requestUrl = _apiClient.CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "people/_search/"), "?aggregate=" + aggregator.ToString().ToLower() + "&offset=" + offset.ToString() + "&size=" + size.ToString());
            PersonSearch result = new PersonSearch();
            result = await _apiClient.PostAsync<PersonSearch>(requestUrl, result);
            return result;
        }

        public async Task<List<AgregatorValue>> GetTopThreeUsersSkills()
        {
            PersonSearch resultQuery = await GetUsers(0, true, 0);

            List<AgregatorValue> topSkillsUsers = resultQuery.Aggregators.Skill.Take(3).ToList();

            return topSkillsUsers;
        }

    }
}
