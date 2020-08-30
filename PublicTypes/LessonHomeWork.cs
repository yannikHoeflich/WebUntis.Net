using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

namespace WebUntis.Net {
    public class LessonHomeWork {
        [JsonProperty( "id" )]
        public int Id { get; set; }

        [JsonProperty( "subject" )]
        public string Subject { get; set; }

        [JsonProperty( "lessonType" )]
        public string LessonType { get; set; }

        public Subject ParseToSubject( IEnumerable<Subject> subjects ) {
            foreach( Subject s in subjects ) {
                if( s.Name == Subject.Split( '(' ).Last( ).Split( ')' ).First( ) )
                    return s;
            }
            return null;
        }

        public bool TryParseToSubject( IEnumerable<Subject> subjects , out Subject subject ) {
            subject = null;
            foreach( Subject s in subjects ) {
                if( s.Name == Subject.Split( '(' ).Last( ).Split( ')' ).First( ) ) {
                    subject = s;
                    return true;
                }
            }
            return false;
        }
    }


}
