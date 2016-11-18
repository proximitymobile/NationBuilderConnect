using System.Collections.Generic;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Requests
{
    /// <summary>
    ///     Request sent to the API to add one or more tags to a person
    /// </summary>
    public class AddPersonTagsRequest
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AddPersonTagsRequest" /> class
        /// </summary>
        /// <param name="tags">The tags to add to the person</param>
        public AddPersonTagsRequest(List<string> tags)
        {
            Tags = new Taggings(tags);
        }

        /// <summary>
        ///     The tags to add to the person
        /// </summary>
        [JsonProperty("tagging")]
        public Taggings Tags { get; private set; }

        /// <summary>
        ///     A container for the tags to add to the person
        /// </summary>
        public class Taggings
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="Taggings" /> class
            /// </summary>
            /// <param name="values">The tags to add to the person</param>
            public Taggings(List<string> values)
            {
                Values = values;
            }

            /// <summary>
            ///     The tags to add to the person
            /// </summary>
            [JsonProperty("tag")]
            public List<string> Values { get; private set; }
        }
    }
}