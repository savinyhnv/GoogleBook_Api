using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Creatio.Api.Contracts
{
    public class GetBookRequest
    {
        [JsonProperty("searchKeyword")]
        public string SearchKeyword { get; set; }
    }
}
