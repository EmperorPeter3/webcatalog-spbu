
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyCatalog.DataModel.ElasticSearchModels
{
    public class TermAggregationContainer
    {

        public TermAggregationContainer(string name, IDictionary<string, long?> valueList)
        {
            Name = name;
            Value = valueList;
        }
        public string Name { get; set; }

        public IDictionary<string, long?> Value { get; set; }
    }
}