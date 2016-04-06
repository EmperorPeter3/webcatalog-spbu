
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyCatalog.DataModel.ElasticSearchModels;
using StudyCatalog.DataModel.ElasticSearchModels.ClientRequests;
namespace StudyCatalog.Repository.Interfaces
{
    public interface IRepository
    {

        ElasticDataResponse<RpudRecord> GetRpudRecordsWithAllAttributes();
         ElasticDataResponse<RpudRecord> GetRpudMock();

        ElasticDataResponse<RpudRecord> Filter(RPUDRequestParameters parameters);

        ElasticDataResponse<RpudRecord> KeywordSearch(string[] keywords = null);
    }
}