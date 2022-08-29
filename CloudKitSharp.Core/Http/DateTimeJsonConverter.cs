﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CloudKitSharp.Core.Http
{
    public class DateTimeJsonConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.GetString() == null)
            {
                return default;
            }
            return DateTime.ParseExact(
                reader.GetString()!,
                "yyyy-MM-dd'T'HH:mm:ssZ",
                CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            var dto = new DateTimeOffset(value);
            writer.WriteNumberValue(dto.ToUnixTimeMilliseconds());
        }
    }
}
