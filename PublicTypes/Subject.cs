
using Newtonsoft.Json;

namespace WebUntis.Net {
    public class Subject {
        [JsonProperty( "id" )]
        public ulong Id { get; set; }

        [JsonProperty( "name" )]
        public string Name { get; set; }

        [JsonProperty( "longname" )]
        public string Longname { get; set; }

        [JsonProperty( "foreColor" )]
        public string ForeColor { get; set; }

        [JsonProperty( "backColor" )]
        public string BackColor { get; set; }
    }


}
