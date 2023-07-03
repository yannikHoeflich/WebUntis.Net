using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using System;

namespace Untis.Net.UntisObjects;
public class UntisRoom {
    [JsonPropertyName("id")]
    public ulong Id { get; set; }

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

    [JsonPropertyName("building")]
    public string? Building { get; set; }
}
