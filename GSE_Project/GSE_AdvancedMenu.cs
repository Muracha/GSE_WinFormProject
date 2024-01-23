using GSE_Project.FormModels;

namespace GSE_Project
{
    public partial class GSE_AdvancedMenu : Form
    {
        public NewCompany Company { get; set; }
        private ToolTip tT { get; set; }

        public GSE_AdvancedMenu(NewCompany company)
        {
            tT = new ToolTip();
            tT.ToolTipIcon = ToolTipIcon.Info;
            tT.IsBalloon = true;
            Company = company;
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            nametxtbox.Text = Company.Name;
            buisnessTypetxtbox.Text = Company.BuisnessType;
            inAreatxtbox.Text = Company.InArea;
            outAreatxtbox.Text = Company.OutArea;
            inPartySchemetxtbox.Text = Company.InPartyScheme;
            outPartySchemetxtbox.Text = Company.OutPartyScheme;
            capacityContractTypetxtbox.Text = Company.CapacityContractType;
            capacityAgreementIdentificationtxtbox.Text = Company.CapacityAgreementIdentification;
        }

        private void Save()
        {
            Company.BuisnessType = buisnessTypetxtbox.Text;
            Company.InArea = inAreatxtbox.Text;
            Company.OutArea = outAreatxtbox.Text;
            Company.InPartyScheme = inPartySchemetxtbox.Text;
            Company.OutPartyScheme = outPartySchemetxtbox.Text;
            Company.CapacityContractType = capacityContractTypetxtbox.Text;
            Company.CapacityAgreementIdentification = capacityAgreementIdentificationtxtbox.Text;
            GSE_TradePos.DataChanged = true;
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            Save();
            DialogResult = DialogResult.OK;
        }

        private void buisnessTypetxtbox_TextChanged(object sender, EventArgs e)
        {
            (sender as TextBox).Text = (sender as TextBox).Text.Trim().Replace(" ", "");
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            tT.SetToolTip(pictureBox1, "იმპორტიორი ქვეყნის კოდი,\nსატესტო კოდი - NGE\nსხვა შემთხვევაში - A01.");
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            tT.SetToolTip(pictureBox2, "ექსპორტიორი ქვეყნის კოდი,\nსატესტო კოდი - NGE\nსხვა შემთხვევაში - A01.");
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            tT.SetToolTip(pictureBox3, "მიმღები BG კოდის ტიპი.");
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            tT.SetToolTip(pictureBox4, "გამცემი BG კოდის ტიპი.");
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            tT.SetToolTip(pictureBox5, "ტრანსსასაზღვრო გამტარუნარიანობის კოდის ტიპი\nA01 - დღიური,\nA02 - კვირის,\nA03 - თვის,\nA04 - წლის.");
        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            tT.SetToolTip(pictureBox7, "ტრანსსასაზღვრო გამტარუნარიანობის (PTR) კოდი.");
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            tT.SetToolTip(pictureBox6, "ვაჭრობის ტიპი\nA02 - ქვეყნის შიდა ვაჭრობა,\nA03 - ვაჭრობა თურქეთთან,\nA06 - ვაჭრობა რუსეთთან, სომხეთთან ან აზერბაიჯანთან.");
        }
    }
}
