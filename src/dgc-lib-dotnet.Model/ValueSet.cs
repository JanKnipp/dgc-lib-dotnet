using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using dgc_lib_dotnet.Model.JsonConverter;
using Newtonsoft.Json;

namespace dgc_lib_dotnet.Model
{
    /// <summary>
    /// EU Digital Green Certificate Value Set Data Types
    /// </summary>
    public class ValueSet
    {
        /// <summary>
        /// Value Set Identifier
        /// </summary>
        [JsonProperty("valueSetId", Required = Required.Always)]
        [Required]
        public string ValueSetId { get; set; }

        /// <summary>
        /// Value Set Version
        /// </summary>
        [JsonProperty("valueSetDate", Required = Required.Always)]
        [Required]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime ValueSetDate { get; set; }

        /// <summary>
        /// Allowed values in Value Set
        /// </summary>
        [JsonProperty("valueSetValues", Required = Required.Always)]
        [Required]
        public IDictionary<string, ValueSetValues> ValueSetValues { get; set; }
    }
}