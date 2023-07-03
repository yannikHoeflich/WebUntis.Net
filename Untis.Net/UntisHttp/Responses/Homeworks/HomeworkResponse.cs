using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Untis.Net.UntisHttp.Responses.Homeworks;
internal class HomeworkResponse {
    [JsonPropertyName("data")]
    public HomeworkResponseData Data { get; set; }
}
