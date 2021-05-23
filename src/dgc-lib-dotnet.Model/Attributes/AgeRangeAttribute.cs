using System;
using System.ComponentModel.DataAnnotations;

namespace dgc_lib_dotnet.Model.Attributes
{
    public class AgeRangeAttribute : RangeAttribute
    {
        public AgeRangeAttribute()
            : base(typeof(DateTime), new DateTime(1900,1,1).ToShortDateString(), DateTime.Today.ToShortDateString()) { }
    }
}