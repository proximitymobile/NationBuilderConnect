using System.Collections.Generic;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model
{
    /// <summary>
    ///     A page of results
    /// </summary>
    /// <typeparam name="TEntity">The entity type</typeparam>
    public class ResultsPage<TEntity>
    {
        /// <summary>
        ///     The collection of results
        /// </summary>
        [JsonProperty("results")]
        public List<TEntity> Results { get; private set; }

        /// <summary>
        ///     The URL for the previous page of results
        /// </summary>
        [JsonProperty("prev")]
        public string PreviousPageUrl { get; private set; }

        /// <summary>
        ///     The URL for the next page of results
        /// </summary>
        [JsonProperty("next")]
        public string NextPageUrl { get; private set; }

        /// <summary>
        ///     The number of this page of results (1 indexed)
        /// </summary>
        [JsonIgnore]
        public int PageNumber { get; private set; }

        /// <summary>
        ///     The record number that this page starts on (1 indexed)
        /// </summary>
        [JsonIgnore]
        public int RecordNumberStart { get; private set; }

        /// <summary>
        ///     The record number that this page ends on (1 indexed)
        /// </summary>
        [JsonIgnore]
        public int RecordNumberEnd { get; private set; }

        /// <summary>
        ///     Sets the info that the client knows but the server doesn't send
        /// </summary>
        /// <param name="pageNumber">The number of this page of results (1 indexed)</param>
        /// <param name="recordNumberStart">The record number that this page ends on (1 indexed)</param>
        /// <param name="recordNumberEnd">The record number that this page ends on (1 indexed)</param>
        public void SetInformationKnownByClient(int pageNumber, int recordNumberStart, int recordNumberEnd)
        {
            PageNumber = pageNumber;
            RecordNumberStart = recordNumberStart;
            RecordNumberEnd = recordNumberEnd;
        }

        /// <summary>
        ///     Gets the paging tokens for the previous page
        /// </summary>
        /// <returns>The previous page tokens</returns>
        public PagingTokens GetPreviousPagingTokens()
        {
            return PagingTokens.CreateFromUrl(PreviousPageUrl);
        }

        /// <summary>
        ///     Gets the paging tokens for the next page
        /// </summary>
        /// <returns>The next page tokens</returns>
        public PagingTokens GetNextPagingTokens()
        {
            return PagingTokens.CreateFromUrl(NextPageUrl);
        }
    }
}