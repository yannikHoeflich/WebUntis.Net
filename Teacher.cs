using Newtonsoft.Json;

namespace WebUntis.Net {
    public class Teacher {
        [JsonProperty( "id" )]
        public int Id { get; set; }

        [JsonProperty( "name" )]
        public string Name { get; set; }

        [JsonProperty( "foreName" )]
        public string Longname { get; set; }

        [JsonProperty( "longName" )]
        public string LongName { get; set; }

        [JsonProperty( "foreColor" )]
        public string ForeColor { get; set; }

        [JsonProperty( "backColor" )]
        public string BackColor { get; set; }
    }
}
