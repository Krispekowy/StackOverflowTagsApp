using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverflowTagsApp.Models
{
    public class TagsListModel
    {
        [JsonProperty("items")]
        public List<TagModel> tagsModel { get; set; }
    }
}
