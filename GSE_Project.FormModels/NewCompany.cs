using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSE_Project.FormModels
{
    public sealed class NewCompany
    {
        public Guid ID { get; set; }
        public string Name
        {
            get { return $"{InParty} - {OutParty}"; }
        }
        public string InParty { get; set; }
        public string OutParty { get; set; }
        public List<string> Pos { get; set; } = new List<string>();
        public bool IsChecked { get; set; }
        public string? SenderIdentification { get; set; }
        public string? SubjectParty { get; set; }
        public string BuisnessType { get; set; } = "A02";
        public string InArea { get; set; } = "10Y1001A1001B012";
        public string OutArea { get; set; } = "10Y1001A1001B012";
        public string InPartyScheme { get; set; } = "A01";
        public string OutPartyScheme { get; set; } = "A01";
        public string CapacityContractType { get; set; } = "";
        public string CapacityAgreementIdentification { get; set; } = "";
    }
}
