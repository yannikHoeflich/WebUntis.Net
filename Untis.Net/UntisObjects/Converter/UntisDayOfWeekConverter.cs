using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using System;
using Untis.Net.Results;

namespace Untis.Net.UntisObjects.Converter;
public class UntisDayOfWeekConverter : JsonConverter<DayOfWeek>{

    public override DayOfWeek Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        if (!reader.TryGetInt32(out int day)) {
            string? str = reader.GetString();
            if (str is null || !int.TryParse(str, out day)) {
                throw new JsonException("Expected was a number");
            }
        }

        return ParseInt(day).GetValueOrThrow();
    }

    public override void Write(Utf8JsonWriter writer, DayOfWeek value, JsonSerializerOptions options) {
        int number = ToInt(value).GetValueOrThrow();

        writer.WriteNumberValue(number);
    }

    public Result<DayOfWeek> ParseInt(int rawValue) {
        if(rawValue < 0 || rawValue > 6) {
            return Result.Error(new ArgumentException($"The value must be between 0 and 6, it was {rawValue}"));
        }

        int number = mod(rawValue + 1, 7);
        var dayOfWeek = (DayOfWeek)number;

       return Result.Ok(dayOfWeek);
    }

    public Result<int> ToInt(DayOfWeek dayOfWeek) {
        if(!Enum.IsDefined(typeof(DayOfWeek), dayOfWeek)) {
            return Result.Error(new ArgumentException("The value is an invalid DayOfWeek"));
        }

        int rawValue = (int)dayOfWeek;
        int number = mod(rawValue - 1, 7);
        return Result.Ok(number);
    }

    private int mod(int x, int m) 
        => ((x % m) + m) % m;
}
