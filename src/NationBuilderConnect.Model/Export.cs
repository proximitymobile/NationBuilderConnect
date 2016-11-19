using Newtonsoft.Json;

namespace NationBuilderConnect.Model
{
    /// <summary>
    ///     A custom list export
    /// </summary>
    public class Export : ReadOnlyDataTransferObject
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
        ///     The export context
        /// </summary>
        [JsonProperty("context")]
        public string Context { get; private set; }

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
            return ExportStatus.Unknown;
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
        }
    }
}