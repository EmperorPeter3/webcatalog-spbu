using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyCatalog.Repository.Interfaces;
using StudyCatalog.DataModel.ElasticSearchModels;
using StudyCatalog.DataModel.ElasticSearchModels.ClientRequests;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Nest;

namespace StudyCatalog.Repository
{
    internal class ElasticSearchContract : IRepository
    {
       


        private static string connectionString = "http://localhost:9200/rpuds/rpud";

       
        private ConnectionSettings connectionSettings;

        public ElasticSearchContract()
        {          
            connectionSettings = new ConnectionSettings(new Uri(connectionString));             
        }

        #region RPUDs
        public ElasticDataResponse<RpudRecord> GetRpudRecordsWithAllAttributes()
        {
            var client = new ElasticClient(connectionSettings);

            
            var request = new SearchRequest()
            {
                Aggregations = GetRPUDAggregates()
            };

            var searchResponse = client.Search<RpudRecord>(request);

            var aggs = GetTermAggregationFromSearchResult<RpudRecord>(searchResponse);
            return new ElasticDataResponse<RpudRecord>(searchResponse.Documents.ToList(), aggs);
        }

        public ElasticDataResponse<RpudRecord> Filter(RPUDRequestParameters parameters)
        {
            var client = new ElasticClient(connectionSettings);
            QueryContainer query = parameters.IsEmpty ? null :  GenerateQueryForFacetedSearch(parameters);

            var request = new SearchRequest()
            {
                Query = query,
                Aggregations = GetRPUDAggregates()
            };

            var searchResponse = client.Search<RpudRecord>(request);
            var aggs = GetTermAggregationFromSearchResult<RpudRecord>(searchResponse);
            return new ElasticDataResponse<RpudRecord>(searchResponse.Documents.ToList(), aggs);
        }
       
        public ElasticDataResponse<RpudRecord> KeywordSearch(string[] keywords)
        {
            var client = new ElasticClient(connectionSettings);
            QueryContainer query = keywords.IsNullOrEmpty() ? null : GenerateQueryForKeywordSearch(keywords);

            var request = new SearchRequest()
            {
                Query = query,
                Aggregations = GetRPUDAggregates()
            };

            var searchResponse = client.Search<RpudRecord>(request);
            var aggs = GetTermAggregationFromSearchResult<RpudRecord>(searchResponse);

            return new ElasticDataResponse<RpudRecord>(searchResponse.Documents.ToList(), aggs);
        }

        public ElasticDataResponse<RpudRecord> GetRpudMock()
        {
            var resultList = new List<RpudRecord>()
           {
               new RpudRecord()
               {
                   NameInEng = "Biology",
                   Assessment = "exam",
                   Requirements = "assistant",
                   Number = 111111,
                   Resourses = "specialtechnicalequipment"
               },
               new RpudRecord
               {
                   NameInEng = "Math",
                   Assessment = "exam",
                   Requirements = "professor",
                   Resourses = "mel",
                   Number = 222222

               }
           };

            var aggs = new List<TermAggregationContainer>() {
                new TermAggregationContainer("NameInEng", new Dictionary<string,long?>() {
                    {"Biology", 1 },
                    {"Math", 1 }
                }),
                new TermAggregationContainer("Assessment", new Dictionary<string, long?>() {
                    {"exam" , 2}
                }),
                new TermAggregationContainer("Requirements" , new Dictionary<string, long?>() {
                    {"assistant", 1 },
                    {"professor", 1 }
                }),
                new TermAggregationContainer("Number", new Dictionary<string, long?>()
                {
                    {"111111", 1 },
                    {"222222", 2 }
                })
            };

            return new ElasticDataResponse<RpudRecord>(resultList, aggs);
        }
        #endregion



        #region Helpers

        private QueryContainer GenerateQueryForFacetedSearch(RPUDRequestParameters parameters)
        {
           
            List<QueryContainer> list = new List<Nest.QueryContainer>();
            if (parameters.NameInEng != null)
            {
                var container = new QueryContainer();
                foreach (var item in parameters.NameInEng)
                {
                    container |= new MatchQuery() { Field = "nameInEng", Query = item };
                   
                }
                list.Add(container);
            }

            if (parameters.Number != null)
            {
                var container = new QueryContainer();
                foreach (var item in parameters.Number)
                {
                    container |= new MatchQuery() { Field = "number", Query = item.ToString() };
                }
                list.Add(container);
            }
            if (parameters.Requirements != null)
            {
                var container = new QueryContainer();
                foreach (var item in parameters.Requirements)
                {
                    container |= new MatchQuery() { Field = "requirements", Query = item };
                }
                list.Add(container);
            }
            if (parameters.Assessment != null)
            {
                var container = new QueryContainer();
                foreach (var item in parameters.Assessment)
                {
                    container |= new MatchQuery() { Field = "assessment", Query = item };
                }
                list.Add(container);
            }

            var queryContainer = new QueryContainer();
            foreach (var query in list)
                queryContainer &= query;

            return queryContainer;
        }

        private QueryContainer GenerateQueryForKeywordSearch(string[] keywords)
        {
            var queryContainer = new QueryContainer();

            queryContainer = new MatchQuery() { Field = "_all", Query = String.Join(" ", keywords)};

            return queryContainer;
        }

        private IList<TermAggregationContainer> GetTermAggregationFromSearchResult<T>(ISearchResponse<T> searchResult)
            where T : class
        {

            var result = new List<TermAggregationContainer>();

            foreach (KeyValuePair<string, IAggregate> pair in searchResult.Aggregations)
            {
                var dict = new Dictionary<string, long?>();

                foreach (var bucket in searchResult.Aggs.Terms(pair.Key).Buckets)
                    dict.Add(bucket.Key, bucket.DocCount);

                result.Add(new TermAggregationContainer(pair.Key, dict));

            }

            return result;

        }

        private Dictionary<string, IAggregationContainer> GetRPUDAggregates()
        {
            return  new Dictionary<string, IAggregationContainer>()
            {
                {"NameInEng", new AggregationContainer()
                            {
                                Terms = new TermsAggregation("NameInEng")
                                {
                                    Field = "nameInEng",
                                    Size = 2000
                                }
                            }
                },
                {"Requirements", new AggregationContainer()
                            {
                                Terms = new TermsAggregation("Requirements")
                                {
                                    Field = "requirements",
                                    Size = 2000
                                }
                            }
                },
                {"Assessment", new AggregationContainer()
                                {
                                    Terms = new TermsAggregation("Assessment")
                                    {
                                        Field = "assessment",
                                        Size = 2000
                                    }
                                }
                }
            };
        }
        #endregion
    }
}