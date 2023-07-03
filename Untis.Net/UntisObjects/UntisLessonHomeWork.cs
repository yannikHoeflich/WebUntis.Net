using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

using System;

namespace Untis.Net.UntisObjects;
internal class UntisLessonHomeWork {
    [JsonPropertyName("id")]
    public ulong Id { get; set; }

    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    [JsonPropertyName("lessonType")]
    public string? LessonType { get; set; }

    public UntisSubject? ParseToSubject(IEnumerable<UntisSubject> subjects) {
        foreach (UntisSubject s in subjects) {
            if (s.Name == Subject?.Split('(').Last().Split(')').First()) {
                return s;
            }
        }

        return null;
    }
}
