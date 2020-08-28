using System.Collections.Generic;

namespace WebUntis.Net {
    class RequestPostData {
        public string id { get; set; }
        public string method { get; set; }
        public Dictionary<string , object> @params { get; set; } = new Dictionary<string , object>( );
        public string jsonrpc { get; set; }
    }
}
