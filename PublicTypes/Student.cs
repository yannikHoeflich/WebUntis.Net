
using Newtonsoft.Json;

namespace WebUntis.Net {
    public class Student {
        [JsonProperty( "id" )]
        public ulong Id { get; set; }

        [JsonProperty( "key" )]
        public ulong Key { get; set; }

        [JsonProperty( "name" )]
        public string Name { get; set; }

        [JsonProperty( "foreName" )]
        public string ForeName { get; set; }

        [JsonProperty( "longName" )]
        public string LongName { get; set; }

        [JsonProperty( "gender" )]
        public string Gender { get; set; }
    }
}
