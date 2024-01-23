using GSE_Project.Facade;
using GSE_Project.Service;

namespace GSE_Project
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            //Application.Run(new GSE_MenuV2());
            IXmlWriterService xmlWriterService = new XmlWriterService();
            Application.Run(new GSE_Main(xmlWriterService));
        }
    }
}