using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using System;

namespace Untis.Net.UntisObjects;
public class UntisClass {
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("longname")]
    public string? Longname { get; set; }

    [JsonPropertyName("active")]
    public bool Active { get; set; }

    [JsonPropertyName("foreColor")]
    public string? ForeColor { get; set; }

    [JsonPropertyName("backColor")]
    public string? BackColor { get; set; }

    [JsonPropertyName("did")]
    public int Did { get; set; }

    [JsonPropertyName("teacher1")]
    public long Teacher1 { get; set; }

    [JsonPropertyName("teacher2")]
    public long Teacher2 { get; set; }

    [JsonPropertyName("teacher3")]
    public long Teacher3 { get; set; }
}
