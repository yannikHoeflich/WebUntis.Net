using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using System;
using Untis.Net.Results;

namespace Untis.Net.UntisObjects.Converter;
public class UntisTimeConverter : JsonConverter<TimeOnly> {
    public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        if(!reader.TryGetInt32(out var time)) {
            string? str = reader.GetString();
            if(str is null || !int.TryParse(str, out time)) {
                throw new JsonException("Expected was a number");
            }
        }

        return ParseInt(time).GetValueOrThrow();
    }

    public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options) {
        int number = ToInt(value).GetValueOrThrow();
        writer.WriteNumberValue(number);
    }

    public Result<TimeOnly> ParseInt(int rawValue) {
        if(rawValue > 2359) {
            return Result.Error("The time value was to large. It can not be bigger then 2359");
        }

        if(rawValue < 0) {
            return Result.Error("The time value was to small. It can not be smaller then 0");
        }

        int min = rawValue % 100;
        int hour = rawValue / 100;

        if(min >= 60) {
            return Result.Error($"The minutes need to be between 0 and 59. It was {min}");
        }

        try {
            var time = new TimeOnly(hour, min);
            return Result.Ok(time);
        } catch (Exception ex) {
            return Result.Error(ex);
        }
    }

    public Result<int> ToInt(TimeOnly value) {
        int number = (value.Hour * 100) + value.Minute;
        return Result.Ok(number);
    }
}
