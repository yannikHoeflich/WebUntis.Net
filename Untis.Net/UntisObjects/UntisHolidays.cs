using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using System;

namespace Untis.Net.UntisObjects;
public class UntisHolidays {
    [JsonPropertyName("active")]
    public ulong Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("longName")]
    public string? LongName { get; set; }

    [JsonPropertyName("startDate"), JsonConverter(typeof(UntisTimeConverter))]
    public DateOnly StartDate { get; set; }

    [JsonPropertyName("endDate"), JsonConverter(typeof(UntisTimeConverter))]
    public DateOnly EndDate { get; set; }
}
