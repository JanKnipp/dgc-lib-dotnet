using System.Collections.Generic;
using System.IO;
using dgc_lib_dotnet.Model;
using Newtonsoft.Json;

namespace dgc_lib_dotnet.Models
{
    static class ValueSetDataReader
    {
        public static ValueSet GetValueSet(string filename)
        {
            var jsonReadFromFile = File.ReadAllText(filename);

            return JsonConvert.DeserializeObject<ValueSet>(jsonReadFromFile);
        }

        public static IEnumerable<ValueSet> GetValueSets()
        {
            var valueSets = new List<ValueSet>();
            var fileNames = new List<string>()
            {
                @".\Ressources\valuesets\disease-agent-targeted.json",
                @".\Ressources\valuesets\test-manf.json",
                @".\Ressources\valuesets\test-result.json",
                @".\Ressources\valuesets\vaccine-mah-manf.json",
                @".\Ressources\valuesets\vaccine-medicinal-product.json",
                @".\Ressources\valuesets\vaccine-prophylaxis.json"
            };

            foreach(var fileName in fileNames)
            {
                valueSets.Add(GetValueSet(fileName));
            }

            return valueSets;
        }
    }
}