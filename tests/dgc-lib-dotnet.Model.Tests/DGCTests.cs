using System;
using System.IO;
using dgc_lib_dotnet.Models;
using dgc_lib_dotnet.Models.Tests;
using dgc_lib_dotnet.Parser;
using dgc_lib_dotnet.Parser.Exceptions;
using Xunit;
using Xunit.Abstractions;

namespace dgc_lib_net.Tests
{
    public class DGCTests
    {
        private readonly ITestOutputHelper _output;

        public DGCTests(ITestOutputHelper output)
        {
            _output = output;
        }

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

            var jsonComparision = JsonComparisonHelper.DeepCompareJson(jsonReadFromFile, jsonSerialized);

            var jsonDifference = JsonComparisonHelper.ShowDiff(jsonReadFromFile, jsonSerialized);

            if (jsonDifference != null)
            {
                _output.WriteLine(jsonDifference.ToString());
            }

            Assert.True(jsonComparision);
            Assert.Null(jsonDifference);
        }

        [Theory]
        [InlineData(@".\Ressources\test\invalid\empty.json")]
        [InlineData(@".\Ressources\test\invalid\invalid_dob.json")]
        [InlineData(@".\Ressources\test\invalid\invalid_vac.json")]
        [InlineData(@".\Ressources\test\invalid\missing_dob.json")]
        [InlineData(@".\Ressources\test\invalid\missing_fnt.json")]
        public void Should_Fail_due_to_invalid_or_missing_elements(string filePath)
        {
            void Deserialize()
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    throw new ArgumentNullException(nameof(filePath));
                }

                var jsonReadFromFile = File.ReadAllText(filePath);

                var dgc = DigitalGreenCertificateParser.DeserializeJson(jsonReadFromFile);
            }

            var exception = Record.Exception((Action) Deserialize);

            if (exception != null)
            {
                _output.WriteLine(exception?.ToString());
            }

            Assert.NotNull(exception);
            Assert.True(exception is DigitalGreenCertificateParserDeserializationException);
        }
    }
}