using System;
using System.Collections;
using System.Collections.Generic;

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
}
