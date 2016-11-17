using NationBuilderConnect.Client.Utilities.Json.Converters;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Values
{
    [JsonConverter(typeof (SexConverter))]
    public enum Sex
    {
        Female = 1,
        Male = 2,
        Other = 3
    }
}