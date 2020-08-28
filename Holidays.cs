using System;
using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace WebUntis.Net {
    public class Holidays {
        [JsonProperty( "active" )]
        public int Id { get; set; }

        [JsonProperty( "name" )]
        public string Name { get; set; }

        [JsonProperty( "longName" )]
        public string LongName { get; set; }

        [JsonProperty( "startDate" )]
        public int StartDateUntisFormat { get; set; }

        [JsonProperty( "endDate" )]
        public int EndDateUntisFormat { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [OnSerialized]
        internal void Convert( StreamingContext context ) {
            StartDate = WebUntisClient.ConvertUntisToDate( StartDateUntisFormat );
            EndDate = WebUntisClient.ConvertUntisToDate( EndDateUntisFormat );
        }

        public void Convert( ) {
            StartDate = WebUntisClient.ConvertUntisToDate( StartDateUntisFormat );
            EndDate = WebUntisClient.ConvertUntisToDate( EndDateUntisFormat );
        }
    }
}
