using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace StudyCatalog.DataModel.ElasticSearchModels.ClientRequests
{
    public class RPUDRequestParameters
    {
        [DisplayName("nameInEng")]
        public string[] NameInEng { get; set; }

        [DisplayName("number")]
        public long[] Number { get; set; }

        public string[] Requirements { get; set; }

        public string[] Assessment { get; set; }

        public string[] Resources { get; set; }

        public bool IsEmpty
        {
            get
            {
                return NameInEng.IsNullOrEmpty() && Resources.IsNullOrEmpty() && Assessment.IsNullOrEmpty() &&  Number.IsNullOrEmpty();
            }
        }

     
    }

    public static class ArrayHelper
    {
        public static bool IsNullOrEmpty(this Array array)
        {
            return (array == null || array.Length == 0);
        }
    }
}