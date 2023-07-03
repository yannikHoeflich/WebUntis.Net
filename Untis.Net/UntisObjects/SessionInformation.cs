using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using System;

namespace Untis.Net.UntisObjects;
internal class SessionInformation {
    [JsonPropertyName("sessionId")]
    public string? SessionId { get; set; }

    [JsonPropertyName("personType")]
    public int PersonType { get; set; }

    [JsonPropertyName("personId")]
    public ulong PersonId { get; set; }

    [JsonPropertyName("klasseId")]
    public ulong ClassId { get; set; }
}
