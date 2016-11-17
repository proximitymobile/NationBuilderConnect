using System;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Services.Parameters
{
    public class CreateExportParameters
    {
        public CreateExportParameters(ExportContext context)
        {
            Context = GetContextString(context);
        }

        public CreateExportParameters(string context)
        {
            Context = context;
        }

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