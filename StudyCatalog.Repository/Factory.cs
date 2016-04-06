using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyCatalog.Repository.Interfaces;

namespace StudyCatalog.Repository
{
    public static class Factory
    {
        public static IRepository GetElasticSearchRepository()
        {
            return new ElasticSearchContract();
        }
    }
}