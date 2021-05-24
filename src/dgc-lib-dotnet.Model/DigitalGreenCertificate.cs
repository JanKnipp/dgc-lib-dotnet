using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using dgc_lib_dotnet.Model.Attributes;
using dgc_lib_dotnet.Model.JsonConverter;
using Newtonsoft.Json;

namespace dgc_lib_dotnet.Model
{
    /// <summary>
    /// EU Digital Green Certificate
    /// </summary>
    public class DigitalGreenCertificate
    {
        /// <summary>
        /// Version of the schema, according to Semantic versioning (ISO, https://semver.org/ version 2.0.0 or newer)
        /// </summary>
        [JsonProperty("ver", Required = Required.Always)]
        [Required]
        [RegularExpression(@"^\d+.\d+.\d+$")]
        public Version SchemaVersion { get; set; }

        /// <summary>
        /// Surname(s), given name(s) - in that order
        /// </summary>
        [JsonProperty("nam", Required = Required.Always)]
        [Required]
        public PersonName PersonName { get; set; }

        /// <summary>
        /// Date of Birth of the person addressed in the DGC. ISO 8601 date format restricted to range 1900-2099
        /// Complete date, without time, following the ISO 8601.
        /// </summary>
        [JsonProperty("dob", Required = Required.Always)]
        [AgeRange]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        [Required]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Vaccination Group
        /// </summary>
        [JsonProperty("v", Required = Required.DisallowNull)]
        [CollectionCount(1, int.MaxValue)]
        public IEnumerable<VaccinationEntry> VaccinationGroup { get; set; }

        /// <summary>
        /// Test Group
        /// </summary>
        [JsonProperty("t", Required = Required.DisallowNull)]
        [CollectionCount(1, int.MaxValue)]
        public IEnumerable<TestEntry> TestGroup { get; set; }

        /// <summary>
        /// Recovery Group
        /// </summary>
        [JsonProperty("r", Required = Required.DisallowNull)]
        [CollectionCount(1, int.MaxValue)]
        public IEnumerable<RecoveryEntry> RecoveryGroup { get; set; }
    }
}