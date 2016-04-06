using Nest;

namespace StudyCatalog.DataModel.ElasticSearchModels
{
    [ElasticsearchType(Name = "line")]
    public class RpudRecord
    {
        public string NameInEng { get; set; }
        public long Number { get; set; }

        public string Requirements { get; set; }

        public string Assessment { get; set; }

        public string Resourses { get; set; }

        public string Description { get; set; }

    }
}
