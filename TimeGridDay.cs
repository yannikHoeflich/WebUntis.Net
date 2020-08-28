using System.Collections.Generic;

using Newtonsoft.Json;

namespace WebUntis.Net {
    public class TimeGridDay {
        [JsonProperty( "day" )]
        public int Day { get; set; }

        [JsonProperty( "timeUnits" )]
        public List<TimeGridDayUnit> TimeUnits { get; set; }

        public TimeGridDayUnit this[int i] {
            get { return TimeUnits[i]; }
        }
    }
}
