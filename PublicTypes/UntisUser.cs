using Newtonsoft.Json;

namespace WebUntis.Net {
    public class UntisUser {
        [JsonProperty( "id" )]
        public int Id { get; set; }

        [JsonProperty( "type" )]
        public int Type { get; set; }
    }
}
