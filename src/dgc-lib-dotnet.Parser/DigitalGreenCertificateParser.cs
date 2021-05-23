using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using dgc_lib_dotnet.Model;
using Newtonsoft.Json;

namespace dgc_lib_dotnet.Parser
{
    public class DigitalGreenCertificateParser
    {
        public DigitalGreenCertificateParser(IEnumerable<ValueSet> valueSets)
        {
            ValueSetsLoaded.ValueSets = valueSets ?? throw new ArgumentNullException(nameof(valueSets));
        }

        public static DigitalGreenCertificate DeserializeJson(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                throw new ArgumentNullException(nameof(json));
            }

            var dgc = JsonConvert.DeserializeObject<DigitalGreenCertificate>(json);

            var ctc = new ValidationContext(dgc);

            Validator.ValidateObject(dgc, ctc, true);

            return dgc;
        }

        public static string SerializeJson(DigitalGreenCertificate digitalGreenCertificate)
        {
            if (digitalGreenCertificate == null)
            {
                throw new ArgumentNullException(nameof(digitalGreenCertificate));
            }

            return JsonConvert.SerializeObject(digitalGreenCertificate, Formatting.Indented,
                new JsonSerializerSettings() {NullValueHandling = NullValueHandling.Ignore});
        }
    }
}