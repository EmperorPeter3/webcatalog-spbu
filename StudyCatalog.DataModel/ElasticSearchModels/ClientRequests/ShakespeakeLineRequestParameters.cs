using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyCatalog.DataModel.ElasticSearchModels.ClientRequests
{
    public class ShakespeareLineRequestParameters
    {
        public string PlayName { get; set; }
        public string LineNumber { get; set; }
        public string Speaker { get; set; }
    }
}
