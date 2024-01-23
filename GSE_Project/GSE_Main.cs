using GSE_Project.Facade;
using GSE_Project.FormModels;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace GSE_Project
{
    public partial class GSE_Main : Form
    {
        private IXmlWriterService _writer;
        private List<NewCompany> _loadedCompanies;
        private List<NewCompany> _companies;
        private bool _formIsLoaded;

        private ToolTip tT { get; set; }

        public GSE_Main(IXmlWriterService writer)
        {
            tT = new ToolTip();
            tT.ToolTipIcon = ToolTipIcon.Info;
            tT.IsBalloon = true;
            
            InitializeComponent();
            InitializeMainInfo(writer);

        }

        private void finalizeButton_Click(object sender, EventArgs e)
        {
            InitializeCompanies(_companies);
        }

        private void buyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenTradePos(daydateTimePicker.Value);
        }

        private void messageVersiontxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void advancedMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //using (var form = new GSE_AdvancedMenu())
            //{
            //    var result = form.ShowDialog();

            //    if (result == DialogResult.OK) { }
            //}
        }
        
        private void OpenTradePos(DateTime dayTime)
        {
            if (dayTime.Month == 3)
            {
                if (GSE_Project.Static.CheckLastSundayOfMonth.CheckLastSunday(dayTime) == dayTime.Day)
                {
                    using (var form = new GSE_TradePos(_companies, true, false))
                    {
                        var result = form.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            _companies = form.CompanyList;
                        }
                    }
                }
                else
                {
                    using (var form = new GSE_TradePos(_companies, false, false))
                    {
                        var result = form.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            _companies = form.CompanyList;
                        }
                    }
                }
            }
            else if (dayTime.Month == 10)
            {
                if (GSE_Project.Static.CheckLastSundayOfMonth.CheckLastSunday(dayTime) == dayTime.Day)
                {
                    using (var form = new GSE_TradePos(_companies, false, true))
                    {
                        var result = form.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            _companies = form.CompanyList;
                        }
                    }
                }
                else
                {
                    using (var form = new GSE_TradePos(_companies, false, false))
                    {
                        var result = form.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            _companies = form.CompanyList;
                        }
                    }
                }
            }
            else if (true)
            {
                using (var form = new GSE_TradePos(_companies, false, false))
                {
                    var result = form.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        _companies = form.CompanyList;
                    }
                }
            }
        }
        
        private void LoadMainInfo()
        {
            foreach (var company in _companies)
            {
                senderIdentificationtxtBox.Text = company.SenderIdentification;
                subjectPartytxtBox.Text = company.SubjectParty;
                break;
            }
        }

        private void InitializeMainInfo(IXmlWriterService writer)
        {
            _writer = writer;
            _loadedCompanies = _writer.LoadTemplate();
            if (_loadedCompanies == null)
            {
                _companies = new();
            }
            else
            {
                _companies = _loadedCompanies;
                LoadMainInfo();
            }
        }


        private void InitializeCompanies(List<NewCompany> companies)
        {
            if (messageVersiontxtBox.Text == null || senderIdentificationtxtBox.Text == null || subjectPartytxtBox.Text == null ||
                messageVersiontxtBox.Text == "" || senderIdentificationtxtBox.Text == "" || subjectPartytxtBox.Text == null)
            {
                MessageBox.Show("Please put the information first");
                return;
            }

            if (companies.Count == 0)
            {
                MessageBox.Show("Nothing was done because there was no information about trade companies");
                return;
            }

            _writer.AddIdentification(daydateTimePicker.Value, Convert.ToInt32(messageVersiontxtBox.Text),
                                                               Convert.ToString(senderIdentificationtxtBox.Text),
                                                               Convert.ToString(subjectPartytxtBox.Text));
            

            foreach (var company in companies)
            {
                company.SenderIdentification = senderIdentificationtxtBox.Text;
                company.SubjectParty = subjectPartytxtBox.Text;

                if (company.IsChecked == false)
                {
                    continue;
                }

                _writer.AddTradeRelation(company);
            }
            try
            {
                _writer.WriteInXml();
                MessageBox.Show($"It was created succesfully at this location {_writer.ReturnPath()}");
                _writer.WriteTemplate(_companies);
                _writer.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong please try again.");
            }

            GSE_TradePos.DataChanged = false;
        }

        private void senderIdentificationtxtBox_TextChanged(object sender, EventArgs e)
        {
            (sender as TextBox).Text = (sender as TextBox).Text.Trim().Replace(" ", "");
        }

        private void tradeRelationsbtn_Click(object sender, EventArgs e)
        {
            OpenTradePos(daydateTimePicker.Value);
        }

        private void GSE_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GSE_TradePos.DataChanged == true)
            {
                var result = MessageBox.Show("Do you want to save changes?", "Save Changes", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    foreach (var item in _companies)
                    {
                        item.SenderIdentification = senderIdentificationtxtBox.Text;
                        item.SubjectParty = subjectPartytxtBox.Text;
                        break;
                    }
                    _writer.WriteTemplate(_companies);
                }
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void senderIdentificationtxtBox_TextChanged_1(object sender, EventArgs e)
        {
            if (_formIsLoaded)
            {
                GSE_TradePos.DataChanged = true;
            }
        }

        private void GSE_Main_Load(object sender, EventArgs e)
        {
            _formIsLoaded = true;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            tT.SetToolTip(pictureBox4, "Brp დაბალანსებაზე\nპასუხისმგენებილი პირი.");
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            tT.SetToolTip(pictureBox1, "Bg დაბალანსების ჯგუფი.");
        }
    }
}