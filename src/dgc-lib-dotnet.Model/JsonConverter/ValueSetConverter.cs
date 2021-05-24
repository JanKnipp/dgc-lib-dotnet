using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace dgc_lib_dotnet.Model.JsonConverter
{
    public class ValueSetConverter:JsonConverter<KeyValuePair<string, ValueSetValues>>
    {
        public override void WriteJson(JsonWriter writer, KeyValuePair<string, ValueSetValues> value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.Key);
        }

        public override KeyValuePair<string, ValueSetValues> ReadJson(JsonReader reader, Type objectType, KeyValuePair<string, ValueSetValues> existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            var valueSets = ValueSetsLoaded.ValueSets;

            var value = (string)reader.Value;

            if (string.IsNullOrEmpty(value))
            {
                return new KeyValuePair<string, ValueSetValues>(string.Empty, null);
            }

            var relevantSet = valueSets.SingleOrDefault(c => c.ValueSetValues.ContainsKey(value));

            if (relevantSet != null)
            {
                return relevantSet.ValueSetValues.SingleOrDefault(d =>
                    string.Equals(d.Key, value, StringComparison.OrdinalIgnoreCase));
            }

            return new KeyValuePair<string, ValueSetValues>(value, new ValueSetValues());
        }
    }
}