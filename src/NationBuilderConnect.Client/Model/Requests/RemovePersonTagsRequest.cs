using System.Collections.Generic;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Requests
{
    /// <summary>
    ///     Request sent to the API to remove one or more tags from a person
    /// </summary>
    public class RemovePersonTagsRequest
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RemovePersonTagsRequest" /> class
        /// </summary>
        /// <param name="tags">The tags to remove</param>
        public RemovePersonTagsRequest(List<string> tags)
        {
            Tags = new Taggings(tags);
        }

        /// <summary>
        ///     The tags to remove
        /// </summary>
        [JsonProperty("tagging")]
        public Taggings Tags { get; private set; }

        /// <summary>
        ///     Container for the tags to remove
        /// </summary>
        public class Taggings
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="Taggings" /> class
            /// </summary>
            /// <param name="values">The tags to remove</param>
            public Taggings(List<string> values)
            {
                Values = values;
            }

            /// <summary>
            ///     The tags to remove
            /// </summary>
            [JsonProperty("tag")]
            public List<string> Values { get; private set; }
        }
    }
}