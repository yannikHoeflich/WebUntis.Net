using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

using System;
using Untis.Net.UntisObjects.Converter;

namespace Untis.Net.UntisObjects;
public class UntisTimeTablePart {

    [JsonPropertyName("id")]
    public ulong Id { get; set; }

    [JsonPropertyName("date"), JsonConverter(typeof(UntisDateConverter))]
    public DateOnly Date { get; set; }

    [JsonPropertyName("kl")]
    public List<UntisClass>? Classes { get; set; }

    [JsonPropertyName("su")]
    public List<UntisSubject>? Subjects { get; set; }

    [JsonPropertyName("ro")]
    public List<UntisRoom>? Rooms { get; set; }

    [JsonPropertyName("lsnumber")]
    public int Lsnumber { get; set; }

    [JsonPropertyName("activityType")]
    public string? ActivityType { get; set; }

    [JsonPropertyName("startTime"), JsonConverter(typeof(UntisTimeConverter))]
    public TimeOnly StartTime { get; set; }

    [JsonPropertyName("endTime"), JsonConverter(typeof(UntisTimeConverter))]
    public TimeOnly EndTime { get; set; }
}