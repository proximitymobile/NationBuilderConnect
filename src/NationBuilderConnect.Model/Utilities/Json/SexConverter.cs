using System;
using Newtonsoft.Json;

namespace NationBuilderConnect.Model.Utilities.Json
{
    internal class SexConverter : JsonConverter
    {
        public override bool CanWrite => true;
        public override bool CanRead => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var valueTyped = value as Sex?;

            if (valueTyped == null) return;

            string text = null;

            if (valueTyped == Sex.Female) text = "F";
            else if(valueTyped == Sex.Male) text = "M";
            else if(valueTyped == Sex.Other) text = "O";

            if(text == null) throw new InvalidOperationException("Unrecognized Sex: " + value);

            writer.WriteValue(text);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Sex);
        }
    }
}
