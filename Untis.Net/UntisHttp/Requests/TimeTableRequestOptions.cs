using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using System;
using Untis.Net.UntisObjects;

namespace Untis.Net.UntisHttp.Requests;
internal class TimeTableRequestOptions {
    [JsonPropertyName("id")]
    public ulong Id { get; set; }

    [JsonPropertyName("element")]
    public UntisUser? User { get; set; }

    [JsonPropertyName("startDate")]
    public int UntisFormStartDate { get; set; }

    [JsonPropertyName("endDate")]
    public int UntisFormEndDate { get; set; }

    [JsonPropertyName("additionalOptions")]
    public object? AdditionalOptions { get; set; }

    [JsonPropertyName("showLsText")]
    public bool ShowLsText { get; set; }

    [JsonPropertyName("showStudentgroup")]
    public bool ShowStudentGroup { get; set; }

    [JsonPropertyName("showLsNumber")]
    public bool ShowLsNumber { get; set; }

    [JsonPropertyName("showSubstText")]
    public bool ShowSubstText { get; set; }

    [JsonPropertyName("showInfo")]
    public bool ShowInfo { get; set; }

    [JsonPropertyName("showBooking")]
    public bool ShowBooking { get; set; }

    [JsonPropertyName("klasseFields")]
    public string[]? ClassFields { get; set; }

    [JsonPropertyName("roomFields")]
    public string[]? RoomFields { get; set; }

    [JsonPropertyName("subjectFields")]
    public string[]? SubjectFields { get; set; }

    [JsonPropertyName("teacherFields")]
    public string[]? TeacherFields { get; set; }

    [JsonIgnore]
    public DateOnly StartDate { set => UntisFormStartDate = UntisTimeConverter.ConvertDateToUntis(value); }

    [JsonIgnore]
    public DateOnly EndDate { set => UntisFormEndDate = UntisTimeConverter.ConvertDateToUntis(value); }
}
