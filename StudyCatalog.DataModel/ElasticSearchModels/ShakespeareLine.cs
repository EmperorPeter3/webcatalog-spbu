
using Nest;

namespace StudyCatalog.DataModel.ElasticSearchModels
{
    [ElasticsearchType(Name = "line")]
    public class ShakespeareLine
    {
        public int _Id { get; set; }

        public int Line_Id { get; set; }
        public string play_name { get; set; }

        public int Speech_Number { get; set; }

        public string Line_Number { get; set; }

        public string speaker { get; set; }

        public string Text_Entry { get; set; }

        public string _Type { get; set; }
    }
}