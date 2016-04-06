using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyCatalog.DataModel.ElasticSearchModels
{
    public class ElasticDataResponse<T> where T : class
    {
        public ElasticDataResponse() { }
        public ElasticDataResponse(IList<T> data, IList<TermAggregationContainer> termAggs)
        {
            Data = data;
            TermAggs = termAggs;
        }
        public IList<T> Data { get; set; }
        public IList<TermAggregationContainer> TermAggs { get; set; }
    }
}