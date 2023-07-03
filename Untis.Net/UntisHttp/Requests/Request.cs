using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using System;

namespace Untis.Net.UntisHttp.Requests;
internal class Request
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("method")]
    public string? Method { get; set; }

    [JsonPropertyName("params")]
    public Dictionary<string, object> Parameter { get; set; } = new Dictionary<string, object>();

    [JsonPropertyName("jsonrpc")]
    public string? Jsonrpc { get; set; }

    public Request AddParameter(string key, object value)
    {
        Parameter[key] = value;
        return this;
    }

    public string ToJson() => JsonSerializer.Serialize(this);

}
