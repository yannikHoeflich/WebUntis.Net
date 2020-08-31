using Newtonsoft.Json;

namespace WebUntis.Net {
    public class UntisUser {
        [JsonProperty( "id" )]
        public ulong Id { get; set; }

        [JsonProperty( "type" )]
        public int Type { get; set; }
    }
}
