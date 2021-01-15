using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TorreBackend.API.Models
{
    public class SearchOpportunityResultModel
    {

        public string Id { get; set; }
        public string Objective { get; set; }
        public string Type { get; set; }
        public List<OrganizationModel> Organizations { get; set; }
        public List<string> Locations { get; set; }
        public bool Remote { get; set; }
        public string Status { get; set; }
        public CompensationModel Compensation { get; set; }
        public List<SkillModel> Skills { get; set; }

    }
}
