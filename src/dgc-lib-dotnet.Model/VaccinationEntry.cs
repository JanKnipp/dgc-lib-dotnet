using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using dgc_lib_dotnet.Model.JsonConverter;
using Newtonsoft.Json;

namespace dgc_lib_dotnet.Model
{
    public class VaccinationEntry
    {
        /// <summary>
        /// disease or agent targeted
        /// </summary>
        [JsonProperty("tg", Required = Required.Always)]
        [Required]
        [JsonConverter(typeof(ValueSetConverter))]
        public KeyValuePair<string, ValueSetValues> TargetedDiseaseOrAgent { get; set; }

        /// <summary>
        /// vaccine or prophylaxis
        /// </summary>
        [JsonProperty("vp", Required = Required.Always)]
        [Required]
        [JsonConverter(typeof(ValueSetConverter))]
        public KeyValuePair<string, ValueSetValues> VaccineOrProphylaxis { get; set; }

        /// <summary>
        /// vaccine medicinal product
        /// </summary>
        [JsonProperty("mp", Required = Required.Always)]
        [Required]
        [JsonConverter(typeof(ValueSetConverter))]
        public KeyValuePair<string, ValueSetValues> VaccineOrMedicalProduct { get; set; }

        /// <summary>
        /// Marketing Authorization Holder - if no MAH present, then manufacturer
        /// </summary>
        [JsonProperty("ma", Required = Required.Always)]
        [Required]
        [JsonConverter(typeof(ValueSetConverter))]
        public KeyValuePair<string, ValueSetValues> MarketingAuthorizationHolder { get; set; }

        /// <summary>
        /// Dose Number
        /// </summary>
        [JsonProperty("dn", Required = Required.Always)]
        [Required]
        [Range(1,9)]
        public int DoseNumber { get; set; }

        /// <summary>
        /// Total Series of Doses
        /// </summary>
        [JsonProperty("sd", Required = Required.Always)]
        [Required]
        [Range(1,9)]
        public int DosesTotal { get; set; }

        /// <summary>
        /// Date of Vaccination
        /// </summary>
        [JsonProperty("dt", Required = Required.Always)]
        [Required]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime VaccinationDate { get; set; }

        /// <summary>
        /// Country of Vaccination
        /// </summary>
        [JsonProperty("co", Required = Required.Always)]
        [Required]
        [JsonConverter(typeof(RegionInfoConverter))]
        public RegionInfo VaccinationCountry { get; set; }

        /// <summary>
        /// Certificate Issuer
        /// </summary>
        [JsonProperty("is", Required = Required.Always)]
        [Required]
        public string CertificateIssuer { get; set; }

        /// <summary>
        /// Unique Certificate Identifier: UVCI
        /// </summary>
        [JsonProperty("ci", Required = Required.Always)]
        [Required]
        public string UniqueCertificateIdentifier { get; set; }
    }
}