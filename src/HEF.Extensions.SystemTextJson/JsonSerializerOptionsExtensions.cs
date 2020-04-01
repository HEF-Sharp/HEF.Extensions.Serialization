using HEF.Extensions.SystemTextJson;

namespace System.Text.Json
{
    public static class JsonSerializerOptionsExtensions
    {
        public static JsonSerializerOptions AddDateTimeFormating(this JsonSerializerOptions options, string formatStr)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            options.Converters.Add(new DateTimeFormatConverter(formatStr));

            return options;
        }
    }
}
