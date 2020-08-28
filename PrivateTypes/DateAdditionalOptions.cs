using System;

namespace WebUntis.Net {
    class DateAdditionalOptions {
        public DateAdditionalOptions( DateTime startDate , DateTime endDate ) {
            StartDate = WebUntisClient.ConvertDateToUntis( startDate ).ToString( );
            EndDate = WebUntisClient.ConvertDateToUntis( endDate ).ToString( );
        }

        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
