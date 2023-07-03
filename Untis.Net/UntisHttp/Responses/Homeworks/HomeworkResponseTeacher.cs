using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using System;

namespace Untis.Net.UntisHttp.Responses.Homeworks;
internal class HomeworkResponseTeacher {
    [JsonPropertyName("id")]
    public ulong Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
