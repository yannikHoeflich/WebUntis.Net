using System;

using Newtonsoft.Json;

namespace WebUntis.Net {
    public class Holidays {
        [JsonProperty( "active" )]
        public ulong Id { get; set; }

        [JsonProperty( "name" )]
        public string Name { get; set; }

        [JsonProperty( "longName" )]
        public string LongName { get; set; }

        [JsonProperty( "startDate" )]
        public int StartDateUntis { get; set; }

        [JsonProperty( "endDate" )]
        public int EndDateUntis { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public void Convert( ) {
            StartDate = WebUntisClient.ConvertUntisToDate( StartDateUntis );
            EndDate = WebUntisClient.ConvertUntisToDate( EndDateUntis );
        }
    }
}
