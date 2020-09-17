namespace System.Text.Json.Serialization
{
    public class DateConverter : DateTimeFormatConverter
    {
        public DateConverter()
            : base("yyyy-MM-dd")
        { }
    }
}
