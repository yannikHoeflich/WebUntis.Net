using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Untis.Net.UntisObjects;
public class UntisTimeTableDay : IReadOnlyList<UntisTimeTablePart> {
    private readonly UntisTimeTablePart[] _parts;
    public DateOnly Date {get;}

    public UntisTimeTablePart this[int index] => _parts[index];

    public int Count => _parts.Length;


    internal UntisTimeTableDay(UntisTimeTablePart[] parts, DateOnly date) {
        _parts = parts;
        Date = date;
    }

    public IEnumerator<UntisTimeTablePart> GetEnumerator() => (IEnumerator<UntisTimeTablePart>)_parts.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _parts.GetEnumerator();
}
