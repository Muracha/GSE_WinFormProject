using GSE_Project.Facade;
using GSE_Project.FormModels;
using GSE_Project.Models;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Serialization;
// dasamatebelia buisnesstype/gasasworebeli 
[assembly: InternalsVisibleTo("GSE_Project.Service")]
namespace GSE_Project.Repository
{
    internal sealed class XmlWriterRepository : IXmlWriterRepository
    {
        private readonly Identification _identification;
        private readonly SendersTimeIdentification _senderTime;
        private readonly List<TradeRelation> _tradeRelations;
        private readonly string _path;
        private string _dir;

        public XmlWriterRepository(string path)
        {
            _path = path;
            _identification = new();
            _senderTime = new();
            _tradeRelations = new();
        }

        public string ReturnPath() => _dir;

        public void Clear() => _tradeRelations.Clear();

        public void AddIdentification(DateTime day, int messageVersion, string senderIdentification, string subjectParty)
        {
            _identification.Day = day;
            _identification.MessageIdentification = $"{_identification.Day.ToString("yyyy''MM''dd")}-{_identification.MessageVersion}";
            _identification.MessageVersion = messageVersion;
            _identification.SenderIdentification = senderIdentification;
            _senderTime.SendersTimeSeriesVersion = _identification.MessageVersion;

            if (_identification.Day.Month >= 3 && _identification.Day.Month <= 10)
            {
                if (_identification.Day.Month == 3)
                {
                    if (_identification.Day.Day == GSE_Project.Static.CheckLastSundayOfMonth.CheckLastSunday(_identification.Day))
                    {
                        _identification.ScheduleTimeInterval = $"{_identification.Day.AddDays(-1).ToString("yyyy'-'MM'-'dd'T'")}23:00Z/{_identification.Day.ToString("yyyy'-'MM'-'dd'T'")}22:00Z";
                    }
                    else if (_identification.Day.Day > GSE_Project.Static.CheckLastSundayOfMonth.CheckLastSunday(_identification.Day))
                    {
                        _identification.ScheduleTimeInterval = $"{_identification.Day.AddDays(-1).ToString("yyyy'-'MM'-'dd'T'")}22:00Z/{_identification.Day.ToString("yyyy'-'MM'-'dd'T'")}22:00Z";
                    }
                    else if (true)
                    {
                        _identification.ScheduleTimeInterval = $"{_identification.Day.AddDays(-1).ToString("yyyy'-'MM'-'dd'T'")}23:00Z/{_identification.Day.ToString("yyyy'-'MM'-'dd'T'")}23:00Z";
                    }
                }
                else if (_identification.Day.Month == 10)
                {
                    if (_identification.Day.Day == GSE_Project.Static.CheckLastSundayOfMonth.CheckLastSunday(_identification.Day))
                    {
                        _identification.ScheduleTimeInterval = $"{_identification.Day.AddDays(-1).ToString("yyyy'-'MM'-'dd'T'")}22:00Z/{_identification.Day.ToString("yyyy'-'MM'-'dd'T'")}23:00Z";
                    }
                    else if (_identification.Day.Day < GSE_Project.Static.CheckLastSundayOfMonth.CheckLastSunday(_identification.Day))
                    {
                        _identification.ScheduleTimeInterval = $"{_identification.Day.AddDays(-1).ToString("yyyy'-'MM'-'dd'T'")}22:00Z/{_identification.Day.ToString("yyyy'-'MM'-'dd'T'")}22:00Z";
                    }
                    else if (true)
                    {
                        _identification.ScheduleTimeInterval = $"{_identification.Day.AddDays(-1).ToString("yyyy'-'MM'-'dd'T'")}23:00Z/{_identification.Day.ToString("yyyy'-'MM'-'dd'T'")}23:00Z";
                    }
                }
                else if (true)
                {
                    _identification.ScheduleTimeInterval = $"{_identification.Day.AddDays(-1).ToString("yyyy'-'MM'-'dd'T'")}22:00Z/{_identification.Day.ToString("yyyy'-'MM'-'dd'T'")}22:00Z";
                }
            }
            else
            {
                _identification.ScheduleTimeInterval = $"{_identification.Day.AddDays(-1).ToString("yyyy'-'MM'-'dd'T'")}23:00Z/{_identification.Day.ToString("yyyy'-'MM'-'dd'T'")}23:00Z";
            }

            _identification.SubjectParty = subjectParty;
        }

        public void AddTradeRelation(NewCompany company)
        {
            var tradeRelation = new TradeRelation();

            tradeRelation.InParty = company.InParty;
            tradeRelation.InParty_Scheme = company.InPartyScheme;
            tradeRelation.OutParty = company.OutParty;
            tradeRelation.OutParty_Scheme = company.OutPartyScheme;
            tradeRelation.PosList = company.Pos;
            tradeRelation.InArea = company.InArea;
            tradeRelation.OutArea = company.OutArea;
            tradeRelation.CapacityContractType = company.CapacityContractType;
            tradeRelation.CapacityAgreementIdentification = company.CapacityAgreementIdentification;
            tradeRelation.BusinessType = company.BuisnessType;
            tradeRelation.TimeInterval = _identification.ScheduleTimeInterval;

            _tradeRelations.Add(tradeRelation);
        }

        public void WriteInXml()
        {
            _dir = $"{_path}Temp\\{_identification.Day.ToString("yyyy'-'MM'-'dd")}";

            if (!Directory.Exists(_dir))
            {
                Directory.CreateDirectory(_dir);
            }

            var settings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "    "
            };

            using (var writer = XmlWriter.Create($"{_dir}\\TPS-{_identification.Day.ToString("yyyy''MM''dd")}-{_identification.SubjectParty}-{_identification.MessageVersion}.xml", settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("ScheduleMessage");
                writer.WriteAttributeString("DtdVersion", "3");
                writer.WriteAttributeString("DtdRelease", "3");
                writer.WriteStartElement($"{nameof(_identification.MessageIdentification)}");
                writer.WriteAttributeString("v", $"{_identification.MessageIdentification}");
                writer.WriteEndElement();
                writer.WriteStartElement($"{nameof(_identification.MessageVersion)}");
                writer.WriteAttributeString("v", $"{_identification.MessageVersion}");
                writer.WriteEndElement();
                writer.WriteStartElement($"{nameof(_identification.MessageType)}");
                writer.WriteAttributeString("v", $"{_identification.MessageType}");
                writer.WriteEndElement();
                writer.WriteStartElement($"{nameof(_identification.ProcessType)}");
                writer.WriteAttributeString("v", $"{_identification.ProcessType}");
                writer.WriteEndElement();
                writer.WriteStartElement($"{nameof(_identification.ScheduleClassificationType)}");
                writer.WriteAttributeString("v", $"{_identification.ScheduleClassificationType}");
                writer.WriteEndElement();
                writer.WriteStartElement($"{nameof(_identification.SenderIdentification)}");
                writer.WriteAttributeString("v", $"{_identification.SenderIdentification}");
                writer.WriteAttributeString("codingScheme", $"{_identification.SenderIdentification_Scheme}");
                writer.WriteEndElement();
                writer.WriteStartElement($"{nameof(_identification.SenderRole)}");
                writer.WriteAttributeString("v", $"{_identification.SenderRole}");
                writer.WriteEndElement();
                writer.WriteStartElement($"{nameof(_identification.ReceiverIdentification)}");
                writer.WriteAttributeString("v", $"{_identification.ReceiverIdentification}");
                writer.WriteAttributeString("codingScheme", $"{_identification.ReceiverIdentification_Scheme}");
                writer.WriteEndElement();
                writer.WriteStartElement($"{nameof(_identification.ReceiverRole)}");
                writer.WriteAttributeString("v", $"{_identification.ReceiverRole}");
                writer.WriteEndElement();
                writer.WriteStartElement($"{nameof(_identification.MessageDateTime)}");
                writer.WriteAttributeString("v", $"{_identification.MessageDateTime}" + "Z");
                writer.WriteEndElement();
                writer.WriteStartElement($"{nameof(_identification.ScheduleTimeInterval)}");
                writer.WriteAttributeString("v", _identification.ScheduleTimeInterval);
                writer.WriteEndElement();
                writer.WriteStartElement($"{nameof(_identification.Domain)}");
                writer.WriteAttributeString("v", $"{_identification.Domain}");
                writer.WriteAttributeString("codingScheme", $"{_identification.Domain_Scheme}");
                writer.WriteEndElement();
                writer.WriteStartElement($"{nameof(_identification.SubjectParty)}");
                writer.WriteAttributeString("v", $"{_identification.SubjectParty}");
                writer.WriteAttributeString("codingScheme", $"{_identification.SubjectParty_Scheme}");
                writer.WriteEndElement();
                writer.WriteStartElement($"{nameof(_identification.SubjectRole)}");
                writer.WriteAttributeString("v", $"{_identification.SubjectRole}");
                writer.WriteEndElement();

                var index = 1;
                foreach (var trade in _tradeRelations)
                {
                    writer.WriteStartElement("ScheduleTimeSeries");
                    writer.WriteStartElement($"{nameof(_senderTime.SendersTimeSeriesIdentification)}");
                    writer.WriteAttributeString("v", $"{_senderTime.SendersTimeSeriesIdentification}" + index);
                    writer.WriteEndElement();
                    writer.WriteStartElement($"{nameof(_senderTime.SendersTimeSeriesVersion)}");
                    writer.WriteAttributeString("v", $"{_senderTime.SendersTimeSeriesVersion}");
                    writer.WriteEndElement();
                    writer.WriteStartElement($"{nameof(trade.BusinessType)}");
                    writer.WriteAttributeString("v", $"{trade.BusinessType}");
                    writer.WriteEndElement();
                    writer.WriteStartElement($"{nameof(_senderTime.Product)}");
                    writer.WriteAttributeString("v", $"{_senderTime.Product}");
                    writer.WriteEndElement();
                    writer.WriteStartElement($"{nameof(_senderTime.ObjectAggregation)}");
                    writer.WriteAttributeString("v", $"{_senderTime.ObjectAggregation}");
                    writer.WriteEndElement();

                    writer.WriteStartElement($"{nameof(trade.InArea)}");
                    writer.WriteAttributeString("v", $"{trade.InArea}");
                    writer.WriteAttributeString("codingScheme", $"{trade.InArea_Scheme}");
                    writer.WriteEndElement();
                    writer.WriteStartElement($"{nameof(trade.OutArea)}");
                    writer.WriteAttributeString("v", $"{trade.OutArea}");
                    writer.WriteAttributeString("codingScheme", $"{trade.OutArea_Scheme}");
                    writer.WriteEndElement();
                    writer.WriteStartElement($"{nameof(trade.InParty)}");
                    writer.WriteAttributeString("v", $"{trade.InParty}");
                    writer.WriteAttributeString("codingScheme", $"{trade.InParty_Scheme}");
                    writer.WriteEndElement();
                    writer.WriteStartElement($"{nameof(trade.OutParty)}");
                    writer.WriteAttributeString("v", $"{trade.OutParty}");
                    writer.WriteAttributeString("codingScheme", $"{trade.OutParty_Scheme}");
                    writer.WriteEndElement();

                    if (trade.CapacityContractType != null && trade.CapacityContractType != "" && trade.CapacityContractType != string.Empty)
                    {
                        writer.WriteStartElement($"{nameof(trade.CapacityContractType)}");
                        writer.WriteAttributeString("v", $"{trade.CapacityContractType}");
                        writer.WriteEndElement();
                    }
                    if (trade.CapacityAgreementIdentification != null && trade.CapacityAgreementIdentification != "" && trade.CapacityAgreementIdentification != string.Empty)
                    {
                        writer.WriteStartElement($"{nameof(trade.CapacityAgreementIdentification)}");
                        writer.WriteAttributeString("v", $"{trade.CapacityAgreementIdentification}");
                        writer.WriteEndElement();
                    }

                    writer.WriteStartElement($"{nameof(trade.MeasurementUnit)}");
                    writer.WriteAttributeString("v", $"{trade.MeasurementUnit}");
                    writer.WriteEndElement();

                    writer.WriteStartElement("Period");
                    writer.WriteStartElement($"{nameof(trade.TimeInterval)}");
                    writer.WriteAttributeString("v", $"{trade.TimeInterval}");
                    writer.WriteEndElement();
                    writer.WriteStartElement($"{nameof(trade.Resolution)}");
                    writer.WriteAttributeString("v", $"{trade.Resolution}");
                    writer.WriteEndElement();

                    if (_identification.Day.Month == 3)
                    {
                        if (_identification.Day.Day == GSE_Project.Static.CheckLastSundayOfMonth.CheckLastSunday(_identification.Day))
                        {
                            if (trade.PosList.Count() == 25)
                            {
                                var last1 = trade.PosList.LastOrDefault();
                                trade.PosList.Remove(last1);
                                var last2 = trade.PosList.LastOrDefault();
                                trade.PosList.Remove(last2);
                            }
                            else if (trade.PosList.Count() == 24)
                            {
                                var last = trade.PosList.LastOrDefault();
                                trade.PosList.Remove(last);
                            }
                        }
                        else if (true)
                        {
                            if (trade.PosList.Count() == 23)
                            {
                                trade.PosList.Add(string.Empty);
                            }
                            if (trade.PosList.Count() == 25)
                            {
                                var last1 = trade.PosList.LastOrDefault();
                                trade.PosList.Remove(last1);
                                var last2 = trade.PosList.LastOrDefault();
                                trade.PosList.Remove(last2);
                            }
                        }
                    }
                    else if (_identification.Day.Month == 10)
                    {
                        if (_identification.Day.Day == GSE_Project.Static.CheckLastSundayOfMonth.CheckLastSunday(_identification.Day))
                        {
                            if (trade.PosList.Count() == 24)
                            {
                                trade.PosList.Add(string.Empty);
                            }
                            else if (trade.PosList.Count() == 23)
                            {
                                trade.PosList.Add(string.Empty);
                                trade.PosList.Add(string.Empty);
                            }
                        }
                        else if (true)
                        {
                            if (trade.PosList.Count() == 23)
                            {
                                trade.PosList.Add(string.Empty);
                            }
                            if (trade.PosList.Count() == 25)
                            {
                                var last1 = trade.PosList.LastOrDefault();
                                trade.PosList.Remove(last1);
                                var last2 = trade.PosList.LastOrDefault();
                                trade.PosList.Remove(last2);
                            }
                        }
                    }
                    else if (true)
                    {
                        if (trade.PosList.Count() == 23)
                        {
                            trade.PosList.Add(string.Empty);
                        }
                        if (trade.PosList.Count() == 25)
                        {
                            var last1 = trade.PosList.LastOrDefault();
                            trade.PosList.Remove(last1);
                            var last2 = trade.PosList.LastOrDefault();
                            trade.PosList.Remove(last2);
                        }
                    }

                    var positionIndex = 0;

                    foreach (var position in trade.PosList)
                    {
                        writer.WriteStartElement("Interval");
                        writer.WriteStartElement("Pos");
                        writer.WriteAttributeString("v", $"{positionIndex + 1}");
                        writer.WriteEndElement();
                        writer.WriteStartElement("Qty");

                        if (position == null || position == string.Empty || position == "")
                        {   
                            writer.WriteAttributeString("v", $"0.000");
                        }
                        else if (position.Contains('.') && position.Length - position.IndexOf('.') - 1 == 1)
                        {
                            writer.WriteAttributeString("v", $"{position}" + "00");
                        }
                        else if (position.Contains('.') && position.Length - position.IndexOf('.') - 1 == 2)
                        {
                            writer.WriteAttributeString("v", $"{position}" + "0");
                        }
                        else if (position.Contains('.') && position.Length - position.IndexOf('.') - 1 == 3)
                        {
                            writer.WriteAttributeString("v", $"{position}");
                        }
                        else if (true)
                        {
                            writer.WriteAttributeString("v", $"{position}" + ".000");
                        }

                        positionIndex++;

                        writer.WriteEndElement();
                        writer.WriteEndElement();
                    }

                    //for (int i = 0; i < trade.PosArray.Length; i++)
                    //{
                    //    writer.WriteStartElement("Interval");
                    //    writer.WriteStartElement("Pos");
                    //    writer.WriteAttributeString("v", $"{i + 1}");
                    //    writer.WriteEndElement();
                    //    writer.WriteStartElement("Qty");
                    //    if (trade.PosArray[i] == null || trade.PosArray[i] == string.Empty || trade.PosArray[i] == "")
                    //    {
                    //        writer.WriteAttributeString("v", $"0.000");
                    //    }
                    //    else if (trade.PosArray[i].Contains(',') && trade.PosArray[i].Length - trade.PosArray[i].IndexOf(',') - 1 == 1)
                    //    {
                    //        writer.WriteAttributeString("v", $"{trade.PosArray[i]}" + "00");
                    //    }
                    //    else if (trade.PosArray[i].Contains(',') && trade.PosArray[i].Length - trade.PosArray[i].IndexOf(',') - 1 == 2)
                    //    {
                    //        writer.WriteAttributeString("v", $"{trade.PosArray[i]}" + "0");
                    //    }
                    //    else if (trade.PosArray[i].Contains(',') && trade.PosArray[i].Length - trade.PosArray[i].IndexOf(',') - 1 == 3)
                    //    {
                    //        writer.WriteAttributeString("v", $"{trade.PosArray[i]}");
                    //    }
                    //    else if(true)
                    //    {
                    //        writer.WriteAttributeString("v", $"{trade.PosArray[i]}" + ".000");
                    //    }
                    //    writer.WriteEndElement();
                    //    writer.WriteEndElement();
                    //}
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    index++;
                }

                writer.WriteEndElement();
            }
        }

        public void WriteTemplate(List<NewCompany> companies)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<NewCompany>));

            using (FileStream stream = File.Create($"{_path}\\Temp\\Templates"))
            {
                serializer.Serialize(stream, companies);
            }
        }

        public List<NewCompany> LoadTemplate()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<NewCompany>));
            List<NewCompany> dezerializedList = new();
            try
            {
                using (FileStream stream = File.OpenRead($"{_path}\\Temp\\Templates"))
                {
                    dezerializedList = (List<NewCompany>)serializer.Deserialize(stream);
                }
            }
            catch (Exception)
            {
                return null;
            }

            return dezerializedList;
        }
    }
}