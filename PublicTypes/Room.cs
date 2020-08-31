
using Newtonsoft.Json;

namespace WebUntis.Net {
    public class Room {
        [JsonProperty( "id" )]
        public ulong Id { get; set; }

        [JsonProperty( "name" )]
        public string Name { get; set; }

        [JsonProperty( "longname" )]
        public string Longname { get; set; }

        [JsonProperty( "active" )]
        public bool Active { get; set; }

        [JsonProperty( "foreColor" )]
        public string ForeColor { get; set; }

        [JsonProperty( "backColor" )]
        public string BackColor { get; set; }

        [JsonProperty( "did" )]
        public int Did { get; set; }

        [JsonProperty( "building" )]
        public string Building { get; set; }
    }


}
