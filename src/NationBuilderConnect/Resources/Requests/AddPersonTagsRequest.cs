using System.Collections.Generic;
using Newtonsoft.Json;

namespace NationBuilderConnect.Resources.Requests
{
    public class AddPersonTagsRequest
    {
        public AddPersonTagsRequest(List<string> tags)
        {
            Tags = new Taggings(tags);
        }

        [JsonProperty("tagging")]
        public Taggings Tags { get; private set; }

        public class Taggings
        {
            public Taggings(List<string> values)
            {
                Values = values;
            }

            [JsonProperty("tag")]
            public List<string> Values { get; private set; } 
        }
    }
}