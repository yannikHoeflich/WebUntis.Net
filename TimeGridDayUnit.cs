
using System;

using Newtonsoft.Json;

namespace WebUntis.Net {
    public class TimeGridDayUnit {
        [JsonProperty( "name" )]
        public string Name { get; set; }

        [JsonProperty( "startTime" )]
        public int StartTimeUntis { get; set; }

        [JsonProperty( "endTime" )]
        public int EndTimeUntis { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public void Parse( ) {
            StartTime = WebUntisClient.ConvertUntisToTime( StartTimeUntis );
            EndTime = WebUntisClient.ConvertUntisToTime( EndTimeUntis );
        }
    }
}
