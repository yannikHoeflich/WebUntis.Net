using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using System;

namespace Untis.Net.UntisObjects;
public class UntisHomeWork {
    public ulong Id { get; set; }
    public string? Text { get; set; }
    public string? Remark { get; set; }
    public bool Completed { get; set; }
    public string[]? Attachments { get; set; }
    public UntisSubject? Subject { get; set; }
    public DateOnly Date { get; set; }
    public DateOnly DueDate { get; set; }
}
