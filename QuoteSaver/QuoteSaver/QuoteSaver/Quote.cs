using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteSaver
{
    public class Quote
    {
        [JsonProperty(PropertyName = "ID")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "quote")]
        public string quote { get; set; }

        [JsonProperty(PropertyName = "author")]
        public string author { get; set; }
    }
}
