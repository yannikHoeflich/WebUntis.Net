using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using System;
using Untis.Net.UntisObjects.Converter;

namespace Untis.Net.UntisObjects;
internal class UntisHomeWorkIntern {

    [JsonPropertyName("id")]
    public ulong Id { get; set; }

    [JsonPropertyName("lessonId")]
    public ulong LessonId { get; set; }

    [JsonPropertyName("date"), JsonConverter(typeof(UntisDateConverter))]
    public DateOnly Date { get; set; }

    [JsonPropertyName("dueDate"), JsonConverter(typeof(UntisDateConverter))]
    public DateOnly DueDate { get; set; }

    [JsonPropertyName("text")]
    public string? Text { get; set; }

    [JsonPropertyName("remark")]
    public string? Remark { get; set; }

    [JsonPropertyName("completed")]
    public bool Completed { get; set; }

    [JsonPropertyName("attachments")]
    public string[]? Attachments { get; set; }

    [JsonPropertyName("subject")]
    public UntisLessonHomeWork? Subject { get; set; }

    public UntisHomeWork? JoinLessonHomework(UntisLessonHomeWork[] lessonhomeworks, UntisSubject[] subjects) => new() {
        Id = Id,
        Date = Date,
        DueDate = DueDate,
        Text = Text,
        Remark = Remark,
        Attachments = Attachments,
        Completed = Completed,
        Subject = lessonhomeworks.First(x => x.Id == LessonId).ParseToSubject(subjects)
    };
}
