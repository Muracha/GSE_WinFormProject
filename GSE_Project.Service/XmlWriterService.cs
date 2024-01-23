using GSE_Project.Facade;
using GSE_Project.FormModels;
using GSE_Project.Repository;

namespace GSE_Project.Service
{
    public sealed class XmlWriterService : IXmlWriterService
    {
        private readonly IXmlWriterRepository _xmlWriterRepository;

        public XmlWriterService()
        {
            _xmlWriterRepository = new XmlWriterRepository(Path.GetPathRoot(Environment.SystemDirectory));
        }

        public string ReturnPath() => _xmlWriterRepository.ReturnPath();

        public void Clear() => _xmlWriterRepository.Clear();

        public void AddIdentification(DateTime day, int messageVersion, string senderIdentification, string subjectParty) => _xmlWriterRepository.AddIdentification(day, messageVersion, senderIdentification, subjectParty);

        public void AddTradeRelation(NewCompany company) => _xmlWriterRepository.AddTradeRelation(company);

        public void WriteInXml() => _xmlWriterRepository.WriteInXml();

        public void WriteTemplate(List<NewCompany> companies) => _xmlWriterRepository.WriteTemplate(companies);

        public List<NewCompany> LoadTemplate() => _xmlWriterRepository.LoadTemplate();
    }
}