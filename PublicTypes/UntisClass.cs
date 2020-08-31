
using Newtonsoft.Json;

namespace WebUntis.Net {
    public class UntisClass {
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

        [JsonProperty( "teacher1" )]
        public ulong Teacher1 { get; set; }

        [JsonProperty( "teacher2" )]
        public ulong Teacher2 { get; set; }

        [JsonProperty( "teacher3" )]
        public ulong Teacher3 { get; set; }
    }


}
