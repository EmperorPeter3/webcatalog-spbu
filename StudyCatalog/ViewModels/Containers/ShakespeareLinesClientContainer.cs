using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyCatalog.ViewModels
{
    public class ShakespeareLinesClientContainer
    {
       public IList<ShakespeareLineClientModel>  data { get; set; }
       public IList<ShakespeareLineClientAttribute> attritutes { get; set; }
    

    }
}
