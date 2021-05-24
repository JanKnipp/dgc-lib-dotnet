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
        /// Specification that it concerns the detection of SARS-CoV-2 infection.
        /// ICD-10, SNOMED CT
        /// </summary>
        [JsonProperty("tg", Required = Required.Always)]
        [Required]
        [JsonConverter(typeof(ValueSetConverter))]
        public KeyValuePair<string, ValueSetValues> TargetedDiseaseOrAgent { get; set; }

        /// <summary>
        /// Type of Test
        /// Description of the type of test that was conducted, e.g. NAATor rapid antigen test.
        /// LOINC, NPU
        /// </summary>
        [JsonProperty("tt", Required = Required.Always)]
        [Required]
        [JsonConverter(typeof(ValueSetConverter))]
        public KeyValuePair<string, ValueSetValues> TestType { get; set; }

        /// <summary>
        /// NAA Test Name
        /// Commercial or brand name of the test.
        /// </summary>
        [JsonProperty("nm")]
        public string TestName { get; set; }

        /// <summary>
        /// RAT Test name and manufacturer
        /// Legal manufacturer of the test.
        /// </summary>
        [JsonProperty("ma")]
        [JsonConverter(typeof(ValueSetConverter))]
        public KeyValuePair<string, ValueSetValues>? TestManufacturer { get; set; }

        /// <summary>
        /// Date/Time of Sample Collection
        /// Date and time when the sample was collected.
        /// Complete date, with time and time zone,  following ISO 8601
        /// </summary>
        [JsonProperty("sc", Required = Required.Always)]
        [Required]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd'T'HH:mm:sszzz")]
        public DateTimeOffset SampleCollectionDateTime { get; set; }

        /// <summary>
        /// Date/Time of Test Result
        /// Date and time when the test result was produced.
        /// Complete date, with time and time zone,  following ISO 8601
        /// </summary>
        [JsonProperty("dr")]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd'T'HH:mm:sszzz")]
        public DateTimeOffset? TestResultDateTime { get; set; }

        /// <summary>
        /// Test Result
        /// For example, negative, positive, inconclusive or void.
        /// </summary>
        [JsonProperty("tr", Required = Required.Always)]
        [Required]
        [JsonConverter(typeof(ValueSetConverter))]
        public KeyValuePair<string, ValueSetValues> TestResult { get; set; }

        /// <summary>
        /// Testing Centre
        /// Name/code of testing centre, facility or a health authority responsible for the testing event.
        /// </summary>
        [JsonProperty("tc", Required = Required.Always)]
        [Required]
        [StringLength(50)]
        public string TestingCentre { get; set; }

        /// <summary>
        /// Country of Test
        /// The country in which the individual was tested.
        /// ISO 3166 Country Codes
        /// </summary>
        [JsonProperty("co", Required = Required.Always)]
        [Required]
        [JsonConverter(typeof(RegionInfoConverter))]
        [RegularExpression("[A-Z]{1,10}")]
        public RegionInfo TestCountry { get; set; }

        /// <summary>
        /// Certificate Issuer
        /// Entity that issued the COVID-19 test result certificate (allowing to check the certificate).
        /// </summary>
        [JsonProperty("is", Required = Required.Always)]
        [Required]
        public string CertificateIssuer { get; set; }

        /// <summary>
        /// Unique Certificate Identifier, UVCI
        /// Reference of the COVID-19 test result certificate (unique identifier).
        /// </summary>
        [JsonProperty("ci", Required = Required.Always)]
        [Required]
        public string UniqueCertificateIdentifier { get; set; }
    }
}