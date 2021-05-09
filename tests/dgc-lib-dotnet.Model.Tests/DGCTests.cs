using System;
using System.IO;
using dgc_lib_dotnet.Models;
using dgc_lib_dotnet.Parser;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace dgc_lib_net.Tests
{
    public class DGCTests
    {
        [Theory]
        [InlineData(@".\Ressources\examples\test-rat.json")]
        [InlineData(@".\Ressources\examples\test-naa.json")]
        [InlineData(@".\Ressources\examples\vac.json")]
        [InlineData(@".\Ressources\examples\rec.json")]
        [InlineData(@".\Ressources\examples\contrived-translit.json")]

        public void Deserializing_and_serializing_should_not_change_json(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            var jsonReadFromFile = File.ReadAllText(filePath);

            var valueSets = ValueSetDataReader.GetValueSets();
            new DigitalGreenCertificateParser(valueSets);

            var jsonDeserialized = DigitalGreenCertificateParser.DeserializeJson(jsonReadFromFile);

            var jsonSerialized = DigitalGreenCertificateParser.SerializeJson(jsonDeserialized);

            var jsonComparision = DeepCompareJson(jsonReadFromFile, jsonSerialized);

            Assert.True(jsonComparision);
        }


        private bool DeepCompareJson(string jsonReference, string jsonCompare)
        {
            return JToken.DeepEquals(JToken.Parse(jsonReference), JToken.Parse(jsonCompare));
        }

        [Theory]
        [InlineData(@".\Ressources\test\invalid\empty.json")]
        [InlineData(@".\Ressources\test\invalid\invalid_dob.json")]
        [InlineData(@".\Ressources\test\invalid\invalid_vac.json")]
        [InlineData(@".\Ressources\test\invalid\missing_dob.json")]
        [InlineData(@".\Ressources\test\invalid\missing_fnt.json")]
        public void Should_Fail_due_to_invalid_or_missing_elements(string filePath)
        {
            Action deserialize = () =>
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    throw new ArgumentNullException(nameof(filePath));
                }

                var jsonReadFromFile = File.ReadAllText(filePath);

                DigitalGreenCertificateParser.DeserializeJson(jsonReadFromFile);
            };

            var exception = Record.Exception(deserialize);

            Assert.NotNull(exception);
            Assert.IsType<JsonSerializationException>(exception);
        }
    }
}
