using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using dgc_lib_dotnet.Model.JsonConverter;
using Newtonsoft.Json;

namespace dgc_lib_dotnet.Model
{
    /// <summary>
    /// Test Entry
    /// </summary>
    public class TestEntry
    {
        /// <summary>
        /// disease or agent targeted
        /// </summary>
        [JsonProperty("tg", Required = Required.Always)]
        [Required]
        [JsonConverter(typeof(ValueSetConverter))]
        public KeyValuePair<string, ValueSetValues> TargetedDiseaseOrAgent { get; set; }


        /// <summary>
        /// Type of Test
        /// </summary>
        [JsonProperty("tt", Required = Required.Always)]
        [Required]
        public string TestType { get; set; }

        /// <summary>
        /// NAA Test Name
        /// </summary>
        [JsonProperty("nm")]
        public string TestName { get; set; }

        /// <summary>
        /// RAT Test name and manufacturer
        /// </summary>
        [JsonProperty("ma")]
        [JsonConverter(typeof(ValueSetConverter))]
        public KeyValuePair<string, ValueSetValues>? TestManufacturer { get; set; }

        /// <summary>
        /// Date/Time of Sample Collection
        /// </summary>
        [JsonProperty("sc", Required = Required.Always)]
        [Required]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd'T'HH:mm:sszzz")]
        public DateTimeOffset SampleCollectionDateTime { get; set; }

        /// <summary>
        /// Date/Time of Test Result
        /// </summary>
        [JsonProperty("dr")]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd'T'HH:mm:sszzz")]
        public DateTimeOffset TestResultDateTime { get; set; }

        /// <summary>
        /// Test Result
        /// </summary>
        [JsonProperty("tr", Required = Required.Always)]
        [Required]
        [JsonConverter(typeof(ValueSetConverter))]
        public KeyValuePair<string, ValueSetValues> TestResult { get; set; }

        /// <summary>
        /// Testing Centre
        /// </summary>
        [JsonProperty("tc", Required = Required.Always)]
        [Required]
        [StringLength(50)]
        public string TestingCentre { get; set; }

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
        /// Unique Certificate Identifier, UVCI
        /// </summary>
        [JsonProperty("ci", Required = Required.Always)]
        [Required]
        public string UniqueCertificateIdentifier { get; set; }
    }
}