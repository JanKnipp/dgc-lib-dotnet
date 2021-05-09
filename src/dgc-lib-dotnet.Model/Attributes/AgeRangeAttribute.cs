using System;
using System.ComponentModel.DataAnnotations;

namespace dgc_lib_dotnet.Model.Attributes
{
    public class AgeRangeAttribute : RangeAttribute
    {
        public AgeRangeAttribute()
            : base(typeof(DateTime), DateTime.Today.AddYears(-120).ToShortDateString(), DateTime.Today.ToShortDateString()) { }
    }
}