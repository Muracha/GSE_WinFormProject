namespace GSE_Project.Models
{
    public sealed class Identification
    {
        public DateTime Day { get; set; }
        public string MessageIdentification { get; set; }
        public int MessageVersion { get; set; }
        public string MessageType { get; private set; } = "A01";
        public string ProcessType { get; private set; } = "A01";
        public string ScheduleClassificationType { get; private set; } = "A01";
        public string SenderIdentification { get; set; }
        public string SenderIdentification_Scheme { get; private set; } = "A01";
        public string SenderRole { get; set; } = "A01";
        public string ReceiverIdentification { get; private set; } = "10X1001C--00007L";
        public string ReceiverIdentification_Scheme { get; private set; } = "A01";
        public string ReceiverRole { get; private set; } = "A04";
        public string MessageDateTime { get; private set; } = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
        public string ScheduleTimeInterval { get; set; }
        public string Domain { get; private set; } = "10Y1001A1001B012";
        public string Domain_Scheme { get; private set; } = "A01";
        public string SubjectParty { get; set; }
        public string SubjectParty_Scheme { get; private set; } = "A01";
        public string SubjectRole { get; private set; } = "A01";
        public string MatchingPeriod { get; set; }
    }
}