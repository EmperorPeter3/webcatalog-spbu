using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudyCatalog.Repository;
using StudyCatalog.DataModel.ElasticSearchModels;
using StudyCatalog.DataModel.ElasticSearchModels.ClientRequests;

namespace StudyCatalog.API
{
    [RoutePrefix("api/RPUDs")]
    public class RPUDController : ApiController
    {
        [Route("Filter")]
        [HttpGet]

        public ElasticDataResponse<RpudRecord> Filter([FromUri]string[] nameInEng, [FromUri] long[] number, [FromUri] string[] requirements, 
            [FromUri] string[] assessment, [FromUri] string[] resources)
        {
            var rpudRequestParameters = new RPUDRequestParameters()
            {
                NameInEng = nameInEng,
                Number = number,
                Requirements = requirements,
                Assessment = assessment,
                Resources = resources
            };


            var repository = Factory.GetElasticSearchRepository();
            return repository.Filter(rpudRequestParameters);

        }

        [Route("GetRPUDMock")]
        [HttpGet]
        public ElasticDataResponse<RpudRecord> GetMocks()
        {
            var repository = Factory.GetElasticSearchRepository();
            return repository.GetRpudMock();
        }

        [Route("Search")]
        [HttpGet]
        public ElasticDataResponse<RpudRecord> KeywordSearch([FromUri]string[] keywords)
        {
            if (keywords.IsNullOrEmpty())
                throw new ArgumentNullException("Null arguments in KeywoardSearch");
            var repository = Factory.GetElasticSearchRepository();

            return repository.KeywordSearch(keywords);
        }
    }
}
