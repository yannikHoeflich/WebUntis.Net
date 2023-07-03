using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Untis.Net.UntisHttp.Responses.Homeworks;
internal class HomeworkResponseRecord {
    [JsonPropertyName("homeworkId")]
    public ulong HomeworkId { get; set; }

    [JsonPropertyName("teacherId")]
    public ulong TeacherId { get; set; }

    [JsonPropertyName("elementIds")]
    public ulong[] ElementIds { get; set; }
}
