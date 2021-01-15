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
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("?size=");
            stringBuilder.Append(size.ToString());
            stringBuilder.Append("&aggregate=");
            stringBuilder.Append(aggregator.ToString().ToLower());
            stringBuilder.Append("&offset=");
            stringBuilder.Append(offset.ToString());
            var requestUrl = _apiClient.CreateRequestUri(stringBuilder.ToString());
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
