using System;
using System.Runtime.Serialization;

namespace WebUntis.Net.Exceptions {
    [Serializable]
    internal class AnonymousLoginException : Exception {
        public AnonymousLoginException( ) {
        }

        public AnonymousLoginException( string message ) : base( message ) {
        }

        public AnonymousLoginException( string message , Exception innerException ) : base( message , innerException ) {
        }

        protected AnonymousLoginException( SerializationInfo info , StreamingContext context ) : base( info , context ) {
        }
    }
}
