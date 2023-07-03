using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using System;
using Untis.Net.UntisObjects.Converter;

namespace Untis.Net.UntisObjects;
public class UntisTimegridDay {
    [JsonPropertyName("day"), JsonConverter(typeof(UntisDayOfWeekConverter))]
    public DayOfWeek Day { get; set; }

    [JsonPropertyName("timeUnits")]
    public UntisTimegridSegment[]? Segments { get; set; }
}
