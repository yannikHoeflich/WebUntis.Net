using System;

using Newtonsoft.Json;

namespace WebUntis.Net {
    public class HomeWork {
        [JsonProperty( "id" )]
        public ulong Id { get; set; }

        [JsonProperty( "lessonId" )]
        public ulong LessonId { get; set; }

        [JsonProperty( "date" )]
        public int DateUntis { get; set; }

        [JsonProperty( "dueDate" )]
        public int DueDateUntis { get; set; }

        [JsonProperty( "text" )]
        public string Text { get; set; }

        [JsonProperty( "remark" )]
        public string Remark { get; set; }

        [JsonProperty( "completed" )]
        public bool Completed { get; set; }

        [JsonProperty( "attachments" )]
        public string[] Attachments { get; set; }

        public LessonHomeWork Subject { get; set; }


        public DateTime Date { get; private set; }
        public DateTime DueDate { get; private set; }

        public void Convert( ) {
            Date = WebUntisClient.ConvertUntisToDate( DateUntis );
            DueDate = WebUntisClient.ConvertUntisToDate( DueDateUntis );
        }
    }
}
