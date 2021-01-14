using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TorreBackend.API.Models
{
    public class HomeSummaryModel
    {
        public List<AggregatorSummaryModel> Jobs { get; set; }
        public List<AggregatorSummaryModel> Users{ get; set; }
    }
}
