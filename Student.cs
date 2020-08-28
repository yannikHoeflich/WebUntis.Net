
using Newtonsoft.Json;

namespace WebUntis.Net {
    public class Student {
        [JsonProperty( "id" )]
        public int Id { get; set; }

        [JsonProperty( "key" )]
        public int Key { get; set; }

        [JsonProperty( "name" )]
        public string Name { get; set; }

        [JsonProperty( "foreName" )]
        public string Longname { get; set; }

        [JsonProperty( "longName" )]
        public string LongName { get; set; }

        [JsonProperty( "gender" )]
        public string Gender { get; set; }
    }
}
