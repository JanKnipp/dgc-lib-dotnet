using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using dgc_lib_dotnet.Model;
using dgc_lib_dotnet.Parser.Exceptions;
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

            DigitalGreenCertificate dgc;
            try
            {
                dgc = JsonConvert.DeserializeObject<DigitalGreenCertificate>(json);

                var ctc = new ValidationContext(dgc);

                Validator.ValidateObject(dgc, ctc, true);
            }
            catch (Exception e)
            {
                throw new DigitalGreenCertificateParserDeserializationException($"Error deserializing json to DigitalGreenCertificate: {e.Message}", e);
            }

            return dgc;
        }

        public static string SerializeJson(DigitalGreenCertificate digitalGreenCertificate)
        {
            if (digitalGreenCertificate == null)
            {
                throw new ArgumentNullException(nameof(digitalGreenCertificate));
            }

            string json;
            try
            {
                json = JsonConvert.SerializeObject(digitalGreenCertificate, Formatting.Indented,
                    new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            }
            catch (Exception e)
            {
                throw new DigitalGreenCertificateParserSerializationException($"Error serializing json to DigitalGreenCertificate: {e.Message}", e);
            }

            return json;
        }
    }
}