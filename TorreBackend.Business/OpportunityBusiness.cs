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
        public int _offset;

        public OpportunityBusiness(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<AgregatorValue>> GetTopThreeJobs()
        {

            OpportunitySearch resultQuery = await GetOpportunities(0, true, 0);

            List<AgregatorValue> topSkillsOpportunity = resultQuery.Aggregators.Skill.Take(3).ToList();

            return topSkillsOpportunity;

        }

        public async Task<List<OpportunityResult>> SearchOpportunities(int pageNumber, int size, int offset, string name,
            bool? placeBased, string? status, string? type, string? currency, string? periodicity, double? amount, string? skill)
        {
            if (!string.IsNullOrEmpty(name) || placeBased.HasValue || !string.IsNullOrEmpty(status) || !string.IsNullOrEmpty(currency) 
                || !string.IsNullOrEmpty(periodicity) || amount.HasValue || !string.IsNullOrEmpty(skill))
            {
                return await SearchWithFilters(pageNumber, size, name, offset, placeBased, status, type, currency, periodicity, amount, skill);
                
            }
            else
            {
                OpportunitySearch resultQuery = await GetOpportunities(size, false, size * (pageNumber - 1));

                return resultQuery.Results;
            }

        }


        private async Task<List<OpportunityResult>> SearchWithFilters(int pageNumber, int size, string name, int offset,
           bool? placeBased, string? status, string? type, string? currency, string? periodicity, double? amount, string? skill)
        {
            List<OpportunityResult> result = new List<OpportunityResult>();
            
            if (offset > 0)
                _offset = offset;
            else
                _offset = 1;

            while(result.Count < size)
            {
                OpportunitySearch resultQuery = await GetOpportunities(size, false, size * (_offset - 1));

                foreach (OpportunityResult item in resultQuery.Results)
                {

                    bool matchFound = false;
                
                    if (!string.IsNullOrEmpty(name))
                    {
                        matchFound = CheckFilter(matchFound, item.Objective.ToLower().Contains(name.ToLower()));
                        if (!matchFound)
                            continue;
                    }
                    if (placeBased.HasValue)
                    {
                        matchFound = CheckFilter(matchFound, item.Remote == placeBased);
                        if (!matchFound)
                            continue;
                    }
                    if (!string.IsNullOrEmpty(status))
                    {
                        matchFound = CheckFilter(matchFound, item.Status == status);
                        if (!matchFound)
                            continue;
                    }
                    if (!string.IsNullOrEmpty(type))
                    {
                        matchFound = CheckFilter(matchFound, item.Type == type);
                        if (!matchFound)
                            continue;
                    }
                    if (!string.IsNullOrEmpty(currency))
                    {
                        if (item.Compensation != null && item.Compensation.Data != null)
                        {
                            matchFound = CheckFilter(matchFound, item.Compensation.Data.Currency == currency);
                            if (!matchFound)
                                continue;
                        }
                        else
                            continue;
                    }
                    if (!string.IsNullOrEmpty(periodicity))
                    {
                        if (item.Compensation != null && item.Compensation.Data != null)
                        {
                            matchFound = CheckFilter(matchFound, item.Compensation.Data.Periodicity == periodicity);
                            if (!matchFound)
                                continue;
                        }
                        else
                            continue;
                    }
                    if (amount.HasValue)
                    {
                        if (item.Compensation != null && item.Compensation.Data != null)
                        {
                            matchFound = CheckFilter(matchFound, (item.Compensation.Data.MinAmount <= amount && item.Compensation.Data.MinAmount >= amount));
                            if (!matchFound)
                                continue;
                        }
                        else
                            continue;
                    }
                    if (!string.IsNullOrEmpty(skill))
                    {
                        matchFound = CheckFilter(matchFound, item.Skills.Select( x => x.Name.ToLower() == skill.ToLower()).Count() > 0);
                        if (!matchFound)
                            continue;
                    }

                    if (matchFound)
                    {
                        result.Add(item);
                    }

                    
                }

                _offset++;

            }

            return result;

        }

        private bool CheckFilter(bool matchFound, bool isMatch)
        {
            if (matchFound)
            {
                if (!isMatch)
                    return false;
                else
                    return true;
            }
            else
            {
                if (isMatch)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        private async Task<OpportunitySearch> GetOpportunities(int size, bool aggregator, int offset)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("?size=");
            stringBuilder.Append(size.ToString());
            stringBuilder.Append("&aggregate=");
            stringBuilder.Append(aggregator.ToString().ToLower());
            stringBuilder.Append("&offset=");
            stringBuilder.Append(offset.ToString());
            var requestUrl = _apiClient.CreateRequestUri(stringBuilder.ToString());
            OpportunitySearch result = new OpportunitySearch();
            result = await _apiClient.PostAsync<OpportunitySearch>(requestUrl, result);
            return result;
        }



    }
}
