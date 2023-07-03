using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using System;

namespace Untis.Net.UntisHttp.Responses;
internal class SuccessResponse<T> : Response {
    [JsonPropertyName("result")]
    public T? Result { get; set; }
}
