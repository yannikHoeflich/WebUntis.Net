using Newtonsoft.Json;

namespace WebUntis.Net {

    class SessionInformationTemporary {
        [JsonProperty( "jsonrpc" )]
        public string jsonrpc { get; set; }

        [JsonProperty( "id" )]
        public string id { get; set; }

        [JsonProperty( "result" )]
        public SessionInformation result { get; set; }
    }

    public class SessionInformation {
        [JsonProperty( "sessionId" )]
        public string SessionId { get; set; }

        [JsonProperty( "personType" )]
        public int PersonType { get; set; }

        [JsonProperty( "personId" )]
        public int PersonId { get; set; }

        [JsonProperty( "klasseId" )]
        public int KlasseId { get; set; }
    }

}
