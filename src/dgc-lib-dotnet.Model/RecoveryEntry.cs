using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using dgc_lib_dotnet.Model.JsonConverter;
using Newtonsoft.Json;

namespace dgc_lib_dotnet.Model
{
    /// <summary>
    /// Recovery Entry
    /// </summary>
    public class RecoveryEntry
    {
        /// <summary>
        /// disease or agent targeted
        /// </summary>
        [JsonProperty("tg", Required = Required.Always)]
        [Required]
        [JsonConverter(typeof(ValueSetConverter))]
        public KeyValuePair<string, ValueSetValues> TargetedDiseaseOrAgent { get; set; }

        /// <summary>
        /// ISO 8601 Date of First Positive Test Result
        /// </summary>
        [JsonProperty("fr", Required = Required.Always)]
        [Required]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime FirstPositiveTestResult { get; set; }

        /// <summary>
        /// Country of Test
        /// </summary>
        [JsonProperty("co", Required = Required.Always)]
        [Required]
        [JsonConverter(typeof(RegionInfoConverter))]
        public RegionInfo TestCountry { get; set; }

        /// <summary>
        /// Certificate Issuer
        /// </summary>
        [JsonProperty("is", Required = Required.Always)]
        [Required]
        public string CertificateIssuer { get; set; }

        /// <summary>
        /// ISO 8601 Date: Certificate Valid From
        /// </summary>
        [JsonProperty("df", Required = Required.Always)]
        [Required]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime CertificateValidFrom { get; set; }

        /// <summary>
        /// Certificate Valid Until
        /// </summary>
        [JsonProperty("du", Required = Required.Always)]
        [Required]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime CertificateValidUntil { get; set; }

        /// <summary>
        /// Unique Certificate Identifier, UVCI
        /// </summary>
        [JsonProperty("ci", Required = Required.Always)]
        [Required]
        public string UniqueCertificateIdentifier { get; set; }
    }
}