using System;
using JsonDiffPatchDotNet;
using Newtonsoft.Json.Linq;

namespace dgc_lib_dotnet.Models.Tests
{
    public static class JsonComparisonHelper
    {
        public static bool DeepCompareJson(string jsonReference, string jsonCompare)
        {
            if (string.IsNullOrEmpty(jsonReference))
            {
                throw new ArgumentNullException(nameof(jsonReference));
            }

            if (string.IsNullOrEmpty(jsonCompare))
            {
                throw new ArgumentNullException(nameof(jsonCompare));
            }

            return JToken.DeepEquals(JToken.Parse(jsonReference), JToken.Parse(jsonCompare));
        }

        public static JToken ShowDiff(string jsonReference, string jsonCompare)
        {
            if (string.IsNullOrEmpty(jsonReference))
            {
                throw new ArgumentNullException(nameof(jsonReference));
            }

            if (string.IsNullOrEmpty(jsonCompare))
            {
                throw new ArgumentNullException(nameof(jsonCompare));
            }

            var jdp = new JsonDiffPatch(new Options()
            {
                ArrayDiff = ArrayDiffMode.Efficient,
                DiffBehaviors = DiffBehavior.None,
                TextDiff = TextDiffMode.Efficient
            });

            return jdp.Diff(JToken.Parse(jsonReference), JToken.Parse(jsonCompare));
        }
    }
}
