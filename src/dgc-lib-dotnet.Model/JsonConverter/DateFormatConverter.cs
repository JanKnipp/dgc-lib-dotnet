using Newtonsoft.Json.Converters;

namespace dgc_lib_dotnet.Model.JsonConverter
{
    public class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter(string format)
        {
            DateTimeFormat = format;
        }
    }
}