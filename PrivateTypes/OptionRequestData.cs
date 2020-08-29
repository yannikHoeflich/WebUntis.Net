namespace WebUntis.Net {
    public class OptionRequestData {
        public long id { get; set; }
        public UntisUser element { get; set; }
        public int startDate { get; set; }
        public int endDate { get; set; }
        public object additionalOptions { get; set; }
        public bool showLsText { get; set; }
        public bool showStudentgroup { get; set; }
        public bool showLsNumber { get; set; }
        public bool showSubstText { get; set; }
        public bool showInfo { get; set; }
        public bool showBooking { get; set; }
        public string[] klasseFields { get; set; }
        public string[] roomFields { get; set; }
        public string[] subjectFields { get; set; }
        public string[] teacherFields { get; set; }
    }
}
