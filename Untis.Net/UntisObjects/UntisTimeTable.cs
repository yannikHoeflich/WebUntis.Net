using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using Untis.Net.Results;

namespace Untis.Net.UntisObjects;
public class UntisTimeTable : IReadOnlyList<UntisTimeTableDay> {
    private readonly UntisTimeTableDay[] _days;

    public UntisTimeTableDay this[int index] => _days[index];

    public int Count => _days.Length;


    internal UntisTimeTable(UntisTimeTablePart[] parts) {
        Dictionary<DateOnly, List<UntisTimeTablePart>> days = new();
        foreach(UntisTimeTablePart part in parts) {
            if (!days.TryGetValue(part.Date, out List<UntisTimeTablePart>? day)) {
                day = new List<UntisTimeTablePart>();
                days.Add(part.Date, day);
            }

            day.Add(part);
        }

        _days = days.OrderBy(x => x.Key)
                    .Select(x => x.Value)
                    .Select(x => x.OrderBy(x => x.StartTime).ToArray())
                    .Select(x => new UntisTimeTableDay(x, x.First().Date))
                    .ToArray();
    }

    public Result<UntisTimeTableDay> GetDay(DateOnly date) {
        UntisTimeTableDay? value = _days.FirstOrDefault(x => x.Date == date);

        return value is null
            ? Result.Ok(value)
            : Result.Error("Could'n find Day in timetable");
    }

    public IEnumerator<UntisTimeTableDay> GetEnumerator() => (IEnumerator<UntisTimeTableDay>)_days.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _days.GetEnumerator();
}
