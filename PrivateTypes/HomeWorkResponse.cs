using System.Collections.Generic;

using Newtonsoft.Json;

namespace WebUntis.Net {
    class HomeWorkResponse {
        [JsonProperty( "data" )]
        public DataHomeWorkResponse Data { get; set; }
    }

    internal class RecordHomeWorkResponse {
        [JsonProperty( "homeworkId" )]
        public int HomeworkId { get; set; }

        [JsonProperty( "teacherId" )]
        public int TeacherId { get; set; }

        [JsonProperty( "elementIds" )]
        public List<int> ElementIds { get; set; }
    }

    internal class TeacherHomeWorkResponse {
        [JsonProperty( "id" )]
        public int Id { get; set; }

        [JsonProperty( "name" )]
        public string Name { get; set; }
    }

    internal class DataHomeWorkResponse {
        [JsonProperty( "records" )]
        public List<RecordHomeWorkResponse> Records { get; set; }

        [JsonProperty( "homeworks" )]
        public List<HomeWork> Homeworks { get; set; }

        [JsonProperty( "teachers" )]
        public List<TeacherHomeWorkResponse> Teachers { get; set; }

        [JsonProperty( "lessons" )]
        public List<LessonHomeWork> Lessons { get; set; }
    }


}
