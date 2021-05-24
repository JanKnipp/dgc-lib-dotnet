using System;
using System.IO;
using dgc_lib_dotnet.Model;
using dgc_lib_dotnet.Models.Tests;
using Newtonsoft.Json;
using Xunit;

namespace dgc_lib_net.Tests
{
    public class ValueSetTests
    {
        [Theory]
        [InlineData(@".\Ressources\valuesets\disease-agent-targeted.json")]
        [InlineData(@".\Ressources\valuesets\test-manf.json")]
        [InlineData(@".\Ressources\valuesets\test-type.json")]
        [InlineData(@".\Ressources\valuesets\test-result.json")]
        [InlineData(@".\Ressources\valuesets\vaccine-mah-manf.json")]
        [InlineData(@".\Ressources\valuesets\vaccine-medicinal-product.json")]
        [InlineData(@".\Ressources\valuesets\vaccine-prophylaxis.json")]

        public void Deserialzing_and_serializing_should_not_change_json(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            var jsonReadFromFile = File.ReadAllText(filePath);

            var jsonDeserialized = JsonConvert.DeserializeObject<ValueSet>(jsonReadFromFile);

            var jsonSerialized = JsonConvert.SerializeObject(jsonDeserialized, Formatting.Indented,
                new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });

            var jsonComparision = JsonComparisonHelper.DeepCompareJson(jsonReadFromFile, jsonSerialized);

            Assert.True(jsonComparision);
        }
    }
}