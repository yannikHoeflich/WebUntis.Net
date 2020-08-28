using System;

using Newtonsoft.Json;

namespace WebUntis.Net {
    public class HomeWork {
        [JsonProperty( "id" )]
        public int Id { get; set; }

        [JsonProperty( "lessonId" )]
        public int LessonId { get; set; }

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


        public DateTime Date { get; private set; }
        public DateTime DueDate { get; private set; }

        public void Parse( ) {
            Date = WebUntisClient.ConvertUntisToDate( DateUntis );
            DueDate = WebUntisClient.ConvertUntisToDate( DueDateUntis );
        }
    }
}
