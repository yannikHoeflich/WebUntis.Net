using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using System;

namespace Untis.Net.UntisObjects;
public class UntisTimegridSegment {
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("startTime"), JsonConverter(typeof(UntisTimeConverter))]
    public TimeOnly StartTime { get; set; }

    [JsonPropertyName("endTime"), JsonConverter(typeof(UntisTimeConverter))]
    public TimeOnly EndTime { get; set; }
}
