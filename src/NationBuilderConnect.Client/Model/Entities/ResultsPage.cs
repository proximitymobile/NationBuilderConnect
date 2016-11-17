using System.Collections.Generic;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Entities
{
    public class ResultsPage<TEntity>
    {
        [JsonProperty("results")]
        public List<TEntity> Results { get; private set; }

        [JsonProperty("prev")]
        public string PreviousPageUrl { get; private set; }

        [JsonProperty("next")]
        public string NextPageUrl { get; private set; }

        [JsonIgnore]
        public int PageNumber { get; private set; }

        [JsonIgnore]
        public int RecordNumberStart { get; private set; }

        [JsonIgnore]
        public int RecordNumberEnd { get; private set; }

        public void SetInformationKnownByClient(int pageNumber, int recordNumberStart, int recordNumberEnd)
        {
            PageNumber = pageNumber;
            RecordNumberStart = recordNumberStart;
            RecordNumberEnd = recordNumberEnd;
        }

        public PagingTokens GetPreviousPagingValues()
        {
            return PagingTokens.CreateFromUrl(PreviousPageUrl);
        }

        public PagingTokens GetNextPagingValues()
        {
            return PagingTokens.CreateFromUrl(NextPageUrl);
        }
    }
}