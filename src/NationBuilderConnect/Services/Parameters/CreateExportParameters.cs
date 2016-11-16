using System;
using NationBuilderConnect.Resources.Values;
using Newtonsoft.Json;

namespace NationBuilderConnect.Services.Parameters
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