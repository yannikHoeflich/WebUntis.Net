using System;
using System.Runtime.Serialization;

namespace WebUntis.Net.Exceptions {
    [Serializable]
    internal class DisconnectedException : Exception {
        public DisconnectedException( ) {
        }

        public DisconnectedException( string message ) : base( message ) {
        }

        public DisconnectedException( string message , Exception innerException ) : base( message , innerException ) {
        }

        protected DisconnectedException( SerializationInfo info , StreamingContext context ) : base( info , context ) {
        }
    }
}
