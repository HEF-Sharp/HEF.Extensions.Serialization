namespace System.Text.Json.Serialization
{
    public class TimeSpanConverter : TimeSpanFormatConverter
    {
        public TimeSpanConverter()
            : base("c")
        { }
    }

    public class TimeSpanFormatConverter : JsonConverter<TimeSpan>
    {
        public TimeSpanFormatConverter(string formatStr)
        {
            if (string.IsNullOrWhiteSpace(formatStr))
                throw new ArgumentNullException(nameof(formatStr));

            Format = formatStr;
        }

        protected string Format { get; }

        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (!TimeSpan.TryParse(reader.GetString(), out TimeSpan value))
            {
                throw new FormatException("The JSON value is not in a supported TimeSpan format.");
            }

            return value;
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(Format));
        }
    }
}
