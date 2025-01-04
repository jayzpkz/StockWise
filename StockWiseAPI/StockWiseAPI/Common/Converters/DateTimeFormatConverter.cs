using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace StockWiseAPI.Common.Converters
{
    public class DateTimeFormatConverter : JsonConverter<DateTime>
    {
        private readonly string _format;

        public DateTimeFormatConverter(string format)
        {
            _format = format;
        }

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var dateStr = reader.GetString();
            return DateTime.ParseExact(dateStr, _format, null);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(_format));
        }
    }
}
