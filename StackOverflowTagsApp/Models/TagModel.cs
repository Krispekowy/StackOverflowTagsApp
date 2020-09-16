using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace StackOverflowTagsApp.Models
{
    [DataContract]
    public class TagModel
    {
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        public decimal share { get; set; }
    }
}
