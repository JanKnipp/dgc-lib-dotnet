using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace dgc_lib_dotnet.Model
{
    public class PersonName
    {
        /// <summary>
        /// The family or primary name(s) of the person addressed in the certificate.
        /// </summary>
        [JsonProperty("fn")]
        [StringLength(50)]
        [RegularExpression(@"^[^\p{C}]+$")]
        public string FamilyName { get; set; }

        /// <summary>
        /// The family name(s) of the person transliterated.
        /// </summary>
        [JsonProperty("fnt", Required = Required.Always)]
        [StringLength(50)]
        [RegularExpression("^[A-Z<]*$")]
        [Required]
        public string FamilyNameTransliterated { get; set; }

        /// <summary>
        /// The given name(s) of the person addressed in the certificate
        /// </summary>
        [JsonProperty("gn")]
        [StringLength(50)]
        [RegularExpression(@"^[^\p{C}]+$")]
        public string GivenName { get; set; }

        /// <summary>
        /// The given name(s) of the person transliterated
        /// </summary>
        [JsonProperty("gnt")]
        [StringLength(50)]
        [RegularExpression("^[A-Z<]*$")]
        public string GivenNameTransliterated { get; set; }
    }
}