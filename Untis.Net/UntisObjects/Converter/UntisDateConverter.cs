using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using System;
using Untis.Net.Results;

namespace Untis.Net.UntisObjects.Converter;
public class UntisDateConverter : JsonConverter<DateOnly> {
    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        if (!reader.TryGetInt32(out int date)) {
            string? str = reader.GetString();
            if (str is null || !int.TryParse(str, out date)) {
                throw new JsonException("Expected was a number");
            }
        }

        return ParseInt(date).GetValueOrThrow();
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options) {
        Result<int> result = ToInt(value);
        int intValue = result.GetValueOrThrow();
        writer.WriteNumberValue(intValue);
    }

    public Result<DateOnly> ParseInt(int number) {
        if(number < 1000_00_00) {
            return Result.Error("Value is to small to be a valid date (The smalles possible date is 01.01.1000)");
        }
        if(number > 9999_12_31) {
            return Result.Error("Value is to big to be a valid date (The biggest possible date is the 31.12.9999)");
        }

        int day = number % 100;
        int month = number / 100 % 100;
        int year = (number / 10_000);

        if(day > 31 || day == 0) {
            return Result.Error($"The day must be between 1 and 31, but it was {day}");
        }

        if (month > 12 || month == 0) {
            return Result.Error($"The month must be between 1 and 31, but it was {day}");
        }


        if(day > DateTime.DaysInMonth(year, month)) {
            return Result.Error($"The month ({month}) has not {day} days.");
        }

        try {
            var dateOnly = new DateOnly(year, month, day);

            return Result.Ok(dateOnly);
        } catch(Exception ex) {
            return Result.Error(ex);
        }
    }

    public Result<int> ToInt(DateOnly dateOnly) {
        int number = (dateOnly.Year * 10_000)
                    + (dateOnly.Month * 100)
                    + dateOnly.Day;

        return Result.Ok(number);
    }
}