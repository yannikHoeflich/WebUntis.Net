using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Untis.Net.UntisHttp.Responses;
internal class ErrorResponse : Response {
    [JsonPropertyName("error")]
    public Dictionary<string, object> Error { get; set; }
}
