using System.Text.Json.Serialization;

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

        public static JsonSerializerOptions SerializeCamelCase(this JsonSerializerOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            options.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;

            return options;
        }

        public static JsonSerializerOptions DeserializeCaseInsensitive(this JsonSerializerOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            options.PropertyNameCaseInsensitive = true;

            return options;
        }

        public static JsonSerializerOptions IgnoreNullValues(this JsonSerializerOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            options.IgnoreNullValues = true;

            return options;
        }

        public static JsonSerializerOptions ConvertEnumToString(this JsonSerializerOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            options.Converters.Add(new JsonStringEnumConverter());

            return options;
        }
    }
}
