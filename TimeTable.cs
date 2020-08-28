using System;
using System.Collections;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace WebUntis.Net {
    public class TimeTable : ICollection<TimeTablePart>, ICloneable {
        private protected List<TimeTablePart> Parts = new List<TimeTablePart>();

        public TimeTablePart this[int i] {
            get { return Parts[i]; }
        }
        public TimeTable( ) { }

        public TimeTable( List<TimeTablePart> parts ) {
            this.Parts = parts;
        }
        public int Count => Parts.Count;

        public bool IsReadOnly => false;

        public IEnumerator<TimeTablePart> GetEnumerator( ) => Parts.GetEnumerator( );
        IEnumerator IEnumerable.GetEnumerator( ) => Parts.GetEnumerator( );

        public object Clone( ) {
            TimeTable t = new TimeTable( );
            foreach( TimeTablePart part in Parts ) {
                t.Parts.Add( (TimeTablePart) part.Clone( ) );
            }
            return t;
        }

        public void Add( TimeTablePart item ) =>
            Parts.Add( item );

        public void Clear( ) =>
            Parts.Clear( );

        public bool Contains( TimeTablePart item ) =>
            Parts.Contains( item );

        public void CopyTo( TimeTablePart[] array , int arrayIndex ) =>
            Parts.CopyTo( array , arrayIndex );

        public bool Remove( TimeTablePart item ) =>
            Parts.Remove( item );
    }
    public class TimeTablePart : ICloneable {
        [JsonProperty( "id" )]
        public int Id { get; set; }

        [JsonProperty( "date" )]
        public int Date { get; set; }

        [JsonProperty( "startTime" )]
        public int StartTime { get; set; }

        [JsonProperty( "endTime" )]
        public int EndTime { get; set; }

        [JsonProperty( "kl" )]
        public List<UntisClass> Class { get; set; }

        [JsonProperty( "su" )]
        public List<Subject> Subject { get; set; }

        [JsonProperty( "ro" )]
        public List<Room> Room { get; set; }

        [JsonProperty( "lsnumber" )]
        public int Lsnumber { get; set; }

        [JsonProperty( "activityType" )]
        public string ActivityType { get; set; }

        public object Clone( ) {
            return this.MemberwiseClone( );
        }
    }
}
