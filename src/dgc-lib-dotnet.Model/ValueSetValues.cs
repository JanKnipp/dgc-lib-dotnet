using Newtonsoft.Json;

namespace dgc_lib_dotnet.Model
{
    public partial class ValueSetValues
    {
        [JsonProperty("display")]
        public string Display { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("system")]
        public string System { get; set; }

        public override string ToString()
        {
            return this.Display;
        }
    }
}