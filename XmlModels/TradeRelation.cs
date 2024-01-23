namespace GSE_Project.Models
{
    public sealed class TradeRelation
    {
        public string InArea { get; set; } = "10Y1001A1001B012";
        public string InArea_Scheme { get; private set; } = "A01";
        public string OutArea { get; set; } = "10Y1001A1001B012";
        public string OutArea_Scheme { get; private set; } = "A01";
        public string InParty { get; set; }
        public string InParty_Scheme { get; set; } = "A01";
        public string OutParty { get; set; }
        public string OutParty_Scheme { get; set; } = "A01";
        public string CapacityContractType { get; set; } = string.Empty;
        public string CapacityAgreementIdentification { get; set; } = string.Empty;
        public string MeasurementUnit { get; private set; } = "MAW";
        public string TimeInterval { get; set; }
        public string Resolution { get; private set; } = "PT60M";
        public string BusinessType { get; set; }
        public string[] PosArray { get; set; }
        public List<string> PosList { get; set;}
    }
}
