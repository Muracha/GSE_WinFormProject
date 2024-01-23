using GSE_Project.FormModels;
using System.Data;

namespace GSE_Project
{
    public partial class GSE_TradePos : Form
    {
        private Guid contextMenuClickedValueId;
        private List<TextBox> _posTextBoxList;
        public static bool DataChanged;

        private ToolTip tT { get; set; }
        public List<NewCompany> CompanyList { get; private set; }

        public GSE_TradePos(List<NewCompany> companyList, bool march, bool october)
        {
            tT = new ToolTip();
            tT.ToolTipIcon = ToolTipIcon.Info;
            tT.IsBalloon = true;
            InitializeComponent();
            LoadInfo(companyList, march, october);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if (dataGridView1.Columns[e.ColumnIndex].Name == "checkedCheckBox" && dataGridView1.CurrentCell is DataGridViewCheckBoxCell)
                //{
                //    var id = (Guid)dataGridView1.Rows[e.RowIndex].Cells["idColumn"].Value;

                //    if ((bool)(dataGridView1.CurrentCell as DataGridViewCheckBoxCell).Value == true)
                //    {
                //        foreach (var item in CompanyList)
                //        {
                //            if (item.ID == id)
                //            {
                //                item.IsChecked = true;
                //                break;
                //            }
                //        }
                //    }
                //    else
                //    {
                //        foreach (var item in CompanyList)
                //        {
                //            if (item.ID == id)
                //            {
                //                item.IsChecked = false;
                //                break;
                //            }
                //        }
                //    }

                //    RefreshGrid(CompanyList);
                //}
            }
            catch (Exception)
            {

            }
        }

        private void finishbtn_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((sender as TextBox).Text.Contains('.') && e.KeyChar == '.')
            {
                e.Handled = true;
            }

            if ((sender as TextBox).Text.Contains('.') && (sender as TextBox).Text.Length - (sender as TextBox).Text.IndexOf('.') - 1 >= 3 && e.KeyChar != '\b')
            {
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
            {
                var clipboardText = Clipboard.GetText().Split();
                if (clipboardText.Length == 0 || CheckIfStringArrayContainsLetter(clipboardText))
                {
                    MessageBox.Show("Clipboard contains letters.");
                    return;
                }

                var selectedTextBoxName = (sender as TextBox).Name;
                bool continiuePasting = false;
                var index = 0;
                foreach (var item in _posTextBoxList)
                {
                    if (item.Name == selectedTextBoxName)
                    {
                        continiuePasting = true;
                    }

                    if (continiuePasting == true)
                    {
                        for (int i = index; i < clipboardText.Length; i++)
                        {
                            if (index == 0)
                            {
                                continue;
                            }

                            if (clipboardText[i] == null || clipboardText[i] == "")
                            {
                                index++;
                                continue;
                            }

                            item.Text = clipboardText[i];

                            break;
                        }
                        index++;
                    }
                    if (index > clipboardText.Length)
                    {
                        break;
                    }
                }
                //foreach (var text in clipboardText)
                //{
                //    if (text != string.Empty || text != "")
                //    {
                //        foreach (var item in _posTextBoxList)
                //        {
                //            if (item.Name == selectedTextBoxName)
                //            {
                //                continiuePasting = true;
                //            }
                //        }
                //    }
                //}

                //var indexs = Convert.ToInt32(selectedTextBoxName[selectedTextBoxName.Length - 1].ToString());
                //selectedTextBoxName = selectedTextBoxName.Remove(selectedTextBoxName.Length - 1);
                //foreach (var text in clipboardText)
                //{
                //    if (text != string.Empty || text != "")
                //    {
                //        foreach (var control in base.Controls)
                //        {
                //            if (control is TextBox)
                //            {
                //                if ((control as TextBox).AccessibleDescription == selectedTextBoxName + index)
                //                {
                //                    (control as TextBox).Text = text;
                //                    index++;
                //                    break;
                //                }
                //            }
                //        }
                //    }
                //}

                //(sender as TextBox).Text = string.Empty;
            }
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text.Contains(","))
            {
                (sender as TextBox).Text = (sender as TextBox).Text.Replace(",", ".");
            }

            if ((sender as TextBox).Text.Contains("."))
            {
                if ((sender as TextBox).Text.Length - (sender as TextBox).Text.IndexOf('.') - 1 > 3)
                {
                    (sender as TextBox).Text = (sender as TextBox).Text.Replace((sender as TextBox).Text.Substring((sender as TextBox).Text.IndexOf('.') + 4), "");
                }
            }

            if ((sender as TextBox).Text.Any(char.IsLetter))
            {
                (sender as TextBox).Text = string.Empty;
            }

            if ((sender as TextBox).Text.Any(char.IsDigit))
            {
                (sender as TextBox).Text = (sender as TextBox).Text.Trim().Replace(" ", "");
            }
        }

        private void savebtn_Click(object sender, EventArgs e) => Save();

        private void clearBtn_Click(object sender, EventArgs e) => Clear();

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "nameClm")
                {
                    var id = (Guid)dataGridView1.Rows[e.RowIndex].Cells["idColumn"].Value;
                    LoadCompany(id);
                }
            }
            catch (Exception)
            {

            }
        }

        private void LoadInfo(List<NewCompany> companies, bool march, bool october)
        {
            CompanyList = companies;
            RefreshGrid(CompanyList);

            CheckMarch(march);
            CheckOctober(october);

            _posTextBoxList = LoadPosTextBoxList();
        }

        private void CheckMarch(bool march)
        {
            if (march == true)
            {
                pos24lbl.Visible = false;
                pos24txtbox.Visible = false;
            }
        }

        private void CheckOctober(bool october)
        {
            if (october == true)
            {
                pos25lbl.Visible = true;
                pos25txtbox.Visible = true;
            }
        }

        private void Save()
        {
            if (inPartytxtBox.Text == string.Empty || outPartytxtBox.Text == string.Empty)
            {
                return;
            }

            var company = new NewCompany();
            company.ID = Guid.NewGuid();
            company.InParty = inPartytxtBox.Text;
            company.OutParty = outPartytxtBox.Text;
            
            foreach (var item in _posTextBoxList)
            {
                if (item.Visible == false)
                {
                    continue;
                }

                company.Pos.Add(item.Text);
            }

            CheckDuplicate(CompanyList, company);
            CompanyList.Add(company);
            RefreshGrid(CompanyList);
            DataChanged = true;
        }

        private void Delete(Guid id)
        {
            var _company = CompanyList.Where(x => x.ID == id).FirstOrDefault();
            CompanyList.Remove(_company);

            RefreshGrid(CompanyList);
        }

        private void RefreshGrid(List<NewCompany> companies)
        {
            var sortedList = companies.OrderBy(x => x.InParty).ToList();
            sortedList = Something(sortedList);
            var source = new BindingSource();
            source.DataSource = sortedList;
            dataGridView1.DataSource = source;
        }

        private void LoadCompany(Guid id)
        {
            Clear();
            var company = CompanyList.Where(x => x.ID == id).FirstOrDefault();
            inPartytxtBox.Text = company.InParty;
            outPartytxtBox.Text = company.OutParty;

            foreach (var item in company.Pos)
            {
                foreach (var textBox in _posTextBoxList)
                {
                    if (textBox.Text == null || textBox.Text == string.Empty)
                    {
                        textBox.Text = item;
                        break;
                    }
                }
            }
        }

        private List<TextBox> LoadPosTextBoxList()
        {
            List<TextBox> list = new List<TextBox>();

            list.Add(pos1txtbox);
            list.Add(pos2txtbox);
            list.Add(pos3txtbox);
            list.Add(pos4txtbox);
            list.Add(pos5txtbox);
            list.Add(pos6txtbox);
            list.Add(pos7txtbox);
            list.Add(pos8txtbox);
            list.Add(pos9txtbox);
            list.Add(pos10txtbox);
            list.Add(pos11txtbox);
            list.Add(pos12txtbox);
            list.Add(pos13txtbox);
            list.Add(pos14txtbox);
            list.Add(pos15txtbox);
            list.Add(pos16txtbox);
            list.Add(pos17txtbox);
            list.Add(pos18txtbox);
            list.Add(pos19txtbox);
            list.Add(pos20txtbox);
            list.Add(pos21txtbox);
            list.Add(pos22txtbox);
            list.Add(pos23txtbox);
            list.Add(pos24txtbox);
            list.Add(pos25txtbox);

            return list;
        }

        private void Clear()
        {
            foreach (var item in _posTextBoxList)
            {
                if (item.Text == null || item.Text == "")
                {
                    continue;
                }

                item.Text = null;
            }
        }

        private bool CheckIfStringArrayContainsLetter(string[] strings)
        {
            foreach (var item in strings)
            {
                if (item.Any(char.IsLetter))
                {
                    return true;
                }
            }

            return false;
        }

        private void CheckDuplicate(List<NewCompany> newCompanies, NewCompany company)
        {
            foreach (var item in newCompanies)
            {
                if (item.Name == company.Name)
                {
                    company.BuisnessType = item.BuisnessType;
                    company.InArea = item.InArea;
                    company.OutArea = item.OutArea;
                    company.InPartyScheme = item.InPartyScheme;
                    company.OutPartyScheme = item.OutPartyScheme;
                    company.CapacityContractType = item.CapacityContractType;
                    company.CapacityAgreementIdentification = item.CapacityAgreementIdentification;
                    newCompanies.Remove(item);
                    break;
                }
            }
        }

        private List<NewCompany> Something(List<NewCompany> companies)
        {
            var companyList = new List<NewCompany>();
            foreach (var item in companies)
            {
                if (item.IsChecked)
                {
                    companyList.Add(item);
                }
            }

            foreach (var item in companies)
            {
                if (!item.IsChecked)
                {
                    companyList.Add(item);
                }
            }

            return companyList;
        }

        private void inPartytxtBox_TextChanged(object sender, EventArgs e)
        {
            (sender as TextBox).Text = (sender as TextBox).Text.Trim().Replace(" ", "");
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            //if (e.Button == System.Windows.Forms.MouseButtons.Right)
            //{
            //    contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            //}
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0)
                {
                    contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
                    contextMenuClickedValueId = (Guid)dataGridView1.Rows[currentMouseOverRow].Cells["idColumn"].Value;
                }
            }
        }

        private void advancedSettings_Click(object sender, EventArgs e)
        {
            if (contextMenuClickedValueId == Guid.Empty) { return; }
            
            var _company = CompanyList.Where(x => x.ID == contextMenuClickedValueId).FirstOrDefault();
            using (var form = new GSE_AdvancedMenu(_company))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK) 
                {
                    CompanyList.RemoveAll(x => x.ID == form.Company.ID);
                    CompanyList.Add(form.Company);

                    RefreshGrid(CompanyList);
                }
            }
        }

        private void remove_Click(object sender, EventArgs e)
        {
            if (contextMenuClickedValueId == Guid.Empty) { return; }

            Delete(contextMenuClickedValueId);
        }

        private void searchtxtbox_TextChanged(object sender, EventArgs e)
        {
            var filteredDataCompany = CompanyList.Where(x => x.Name.ToLower().Contains(searchtxtbox.Text.ToLower())).ToList();
            RefreshGrid(filteredDataCompany);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            RefreshGrid(CompanyList);
        }

        private void GSE_TradePos_Load(object sender, EventArgs e)
        {

        }

        private void inPartylbl_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            tT.SetToolTip(pictureBox2, "მყიდველი.");
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            tT.SetToolTip(pictureBox3, "გამყიდველი.");
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            tT.SetToolTip(pictureBox4, "პოზიციები(მგვტ/სთ).");
        }
    }
}
