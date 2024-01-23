namespace GSE_Project.Models
{
    public sealed class SendersTimeIdentification
    {
        public string SendersTimeSeriesIdentification { get; set; } = "TS";
        public int SendersTimeSeriesVersion { get; set; }
        public long Product { get; private set; } = 8716867000016;
        public string ObjectAggregation { get; private set; } = "A03";
    }
}
