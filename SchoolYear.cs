using System;

using Newtonsoft.Json;

namespace WebUntis.Net {
    public class SchoolYear {

        [JsonProperty( "id" )]
        public int Id { get; set; }

        [JsonProperty( "name" )]
        public string Name { get; set; }

        [JsonProperty( "startDate" )]
        public int StartDateUntis { get; set; }

        [JsonProperty( "endDate" )]
        public int EndDateUntis { get; set; }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public void Parse( ) {
            StartDate = WebUntisClient.ConvertUntisToDate( StartDateUntis );
            EndDate = WebUntisClient.ConvertUntisToDate( EndDateUntis );
        }
    }
}
