using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using System;

namespace Untis.Net.UntisObjects;
public class UntisStudent {
    [JsonPropertyName("id")]
    public ulong Id { get; set; }

    [JsonPropertyName("key")]
    public ulong Key { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("foreName")]
    public string? ForeName { get; set; }

    [JsonPropertyName("longName")]
    public string? LongName { get; set; }

    [JsonPropertyName("gender")]
    public string? Gender { get; set; }
}
