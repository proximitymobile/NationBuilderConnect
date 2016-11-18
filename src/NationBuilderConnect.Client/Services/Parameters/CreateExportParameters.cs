using System;
using NationBuilderConnect.Model;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Services.Parameters
{
    /// <summary>
    ///     The values used to create an export
    /// </summary>
    public class CreateExportParameters
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CreateExportParameters" /> class
        /// </summary>
        /// <param name="context">The context for the export</param>
        public CreateExportParameters(ExportContext context)
        {
            Context = GetContextString(context);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CreateExportParameters" /> class
        /// </summary>
        /// <param name="context">The context for the export (as a string)</param>
        public CreateExportParameters(string context)
        {
            Context = context;
        }

        /// <summary>
        ///     The context for the export
        /// </summary>
        [JsonProperty("context")]
        public string Context { get; private set; }

        private static string GetContextString(ExportContext context)
        {
            if (context == ExportContext.People) return "people";
            if (context == ExportContext.Households) return "households";
            throw new InvalidOperationException("Unknown export context type: " + context);
        }
    }
}