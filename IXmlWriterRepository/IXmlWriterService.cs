using GSE_Project.FormModels;

namespace GSE_Project.Facade
{
    public interface IXmlWriterService
    {
        string ReturnPath();
        void Clear();
        void AddIdentification(DateTime day, int messageVersion, string senderIdentification, string subjectParty);
        void AddTradeRelation(NewCompany company);
        void WriteInXml();
        void WriteTemplate(List<NewCompany> companies);
        List<NewCompany> LoadTemplate();
    }
}