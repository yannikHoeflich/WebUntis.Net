using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace WebUntis.Net {
    public class TimeTablePart : ICloneable {
        [JsonProperty( "id" )]
        public ulong Id { get; set; }

        [JsonProperty( "date" )]
        public int Date { get; set; }

        [JsonProperty( "startTime" )]
        public int StartTimeUntis { get; set; }

        [JsonProperty( "endTime" )]
        public int EndTimeUntis { get; set; }

        [JsonProperty( "kl" )]
        public List<UntisClass> Classes { get; set; }

        [JsonProperty( "su" )]
        public List<Subject> Subjects { get; set; }

        [JsonProperty( "ro" )]
        public List<Room> Rooms { get; set; }

        [JsonProperty( "lsnumber" )]
        public int Lsnumber { get; set; }

        [JsonProperty( "activityType" )]
        public string ActivityType { get; set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        public void Convert( ) {
            StartTime = WebUntisClient.ConvertUntisToTime( StartTimeUntis );
            EndTime = WebUntisClient.ConvertUntisToTime( EndTimeUntis );
        }

        public object Clone( ) {
            return this.MemberwiseClone( );
        }
    }
}
