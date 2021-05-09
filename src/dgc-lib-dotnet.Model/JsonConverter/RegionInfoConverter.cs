using System;
using System.Globalization;
using Newtonsoft.Json;

namespace dgc_lib_dotnet.Model.JsonConverter
{
    public class RegionInfoConverter : JsonConverter<RegionInfo>
    {
        public override void WriteJson(JsonWriter writer, RegionInfo value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.TwoLetterISORegionName);
        }

        public override RegionInfo ReadJson(JsonReader reader, Type objectType, RegionInfo existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            var value = (string)reader.Value;

            return new RegionInfo(value);
        }
    }
}