using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyCatalog.ViewModels
{
    public class ShakespeareLineClientModel
    {

        public ShakespeareLineClientModel()
        {         
        }
        public string PlayName { get; set; }

        public int SpeechNumber { get; set; }

        public string LineNumber { get; set; }

        public string Speaker { get; set; }

        public string Type { get; set; }

        public string Text { get; set; }
    }
}
