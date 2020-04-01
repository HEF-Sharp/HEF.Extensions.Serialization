using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HEF.Extensions.SystemTextJson
{
    public class DateTimeFormatConverter : JsonConverter<DateTime>
    {
        public DateTimeFormatConverter(string formatStr)
        {
            if (string.IsNullOrWhiteSpace(formatStr))
                throw new ArgumentNullException(nameof(formatStr));

            Format = formatStr;
        }

        protected string Format { get; }

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetDateTime();
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(Format));
        }
    }
}
