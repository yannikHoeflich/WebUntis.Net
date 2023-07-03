using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Untis.Net.UntisObjects;
public class UntisTimeGrid {
    public UntisTimegridDay[]? Days { get; internal init; }

    public UntisTimegridDay? this[DayOfWeek day] => Days?.FirstOrDefault(x => x.Day == day);
}
