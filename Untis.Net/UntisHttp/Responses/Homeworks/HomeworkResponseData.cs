using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using System;
using Untis.Net.UntisObjects;

namespace Untis.Net.UntisHttp.Responses.Homeworks;
internal class HomeworkResponseData {
    [JsonPropertyName("records")]
    public HomeworkResponseRecord[]? Records { get; set; }

    [JsonPropertyName("homeworks")]
    public UntisHomeWorkIntern[]? Homeworks { get; set; }

    [JsonPropertyName("teachers")]
    public HomeworkResponseTeacher[]? Teachers { get; set; }

    [JsonPropertyName("lessons")]
    public UntisLessonHomeWork[]? Lessons { get; set; }
}
