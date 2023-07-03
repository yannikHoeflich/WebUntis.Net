using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using System;

namespace Untis.Net.UntisObjects;
public class UntisTeacher {
    [JsonPropertyName("id")]
    public ulong Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("foreName")]
    public string? Longname { get; set; }

    [JsonPropertyName("longName")]
    public string? LongName { get; set; }

    [JsonPropertyName("foreColor")]
    public string? ForeColor { get; set; }

    [JsonPropertyName("backColor")]
    public string? BackColor { get; set; }
}
