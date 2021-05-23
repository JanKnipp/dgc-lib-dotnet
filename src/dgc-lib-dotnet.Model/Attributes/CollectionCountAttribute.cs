using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace dgc_lib_dotnet.Model.Attributes
{
    public class CollectionCountAttribute : ValidationAttribute
    {
        private readonly int _minCount;
        private readonly int _maxCount;

        public CollectionCountAttribute(int minCount, int maxCount)
        {
            _minCount = minCount;
            _maxCount = maxCount;
        }
        public override bool IsValid(object value)
        {
            if (value is ICollection collection)
            {
                return collection.Count >= _minCount && collection.Count <= _maxCount;
            }

            return true;
        }
    }
}
