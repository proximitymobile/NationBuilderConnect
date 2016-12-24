using Newtonsoft.Json;

namespace NationBuilderConnect.Model
{
    /// <summary>
    ///     A custom list export
    /// </summary>
    public class Export : JsonReadOnlyDto
    {
        /// <summary>
        ///     The export ID
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; private set; }

        /// <summary>
        ///     The type of export
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; private set; }

        /// <summary>
        ///     The export context as a string. Use the Context property to get the context as an enum
        /// </summary>
        [JsonProperty("context")]
        public string ContextName { get; private set; }

        /// <summary>
        ///     The status object returned from the server
        /// </summary>
        [JsonProperty("status")]
        public StatusDto StatusObject { get; private set; }

        /// <summary>
        ///     The status as represented by an <see cref="ExportStatus" /> enum
        /// </summary>
        public ExportStatus Status => GetStatus();

        /// <summary>
        ///     The context as represented by an <see cref="ExportContext" /> enum
        /// </summary>
        public ExportContext Context => GetContext();

        /// <summary>
        ///     The URL at which the export can be downloaded
        /// </summary>
        [JsonProperty("download_url")]
        public string DownloadUrl { get; private set; }

        private ExportStatus GetStatus()
        {
            if (StatusObject == null) return ExportStatus.Unknown;
            var nameUpper = StatusObject.Name.ToUpperInvariant();
            if (string.Equals("COMPLETED", nameUpper)) return ExportStatus.Completed;
            if (string.Equals("QUEUED", nameUpper)) return ExportStatus.Queued;
            if (string.Equals("WORKING", nameUpper)) return ExportStatus.Working;
            return ExportStatus.Unknown;
        }

        private ExportContext GetContext()
        {
            if (string.IsNullOrWhiteSpace(ContextName)) return ExportContext.Unknown;
            var nameUpper = ContextName.ToUpperInvariant();
            if (string.Equals("HOUSEHOLDS", nameUpper)) return ExportContext.Households;
            if (string.Equals("PEOPLE", nameUpper)) return ExportContext.People;
            return ExportContext.Unknown;
        }

        /// <summary>
        ///     The status object returned from the server
        /// </summary>
        public class StatusDto
        {
            /// <summary>
            ///     The status name
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; private set; }

            /// <summary>
            ///     The number of records that have been processed
            /// </summary>
            [JsonProperty("processed")]
            public int NumberRecordsProcessed { get; private set; }

            /// <summary>
            ///     The total number of records that need to be processed
            /// </summary>
            [JsonProperty("total")]
            public int NumberRecordsTotal { get; private set; }
        }
    }
}