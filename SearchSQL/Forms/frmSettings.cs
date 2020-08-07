using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace SearchSQL
{
    public partial class frmSettings : Form
    {
        private IBuilder _builder;

        public frmSettings()
        {
            InitializeComponent();
            
            LoadExistingDbmsInComboBox();
            
            LoadExistingSettingsInListView();
        }

        private void LoadExistingDbmsInComboBox()
        {
            comboBoxDbms.DataSource = Enum.GetValues(typeof(Dbms)).Cast<Dbms>().ToList();
            comboBoxDbms.SelectedIndex = -1;
        }

        private void LoadExistingSettingsInListView()
        {
            listViewSettings.Items.Clear();

            if (Setting.Settings?.Count > 0)
            {
                foreach (var setting in Setting.Settings)
                {   
                    var row = new ListViewItem(new string[] 
                    { 
                        setting.Alias, 
                        setting.StringConnection, 
                        setting.Dbms.ToString(),
                        setting.IsDefaultSetting.ToString()
                    });

                    row.Tag = setting;

                    listViewSettings.Items.Add(row);
                }
            }
        }

        private Setting GetSelectedSettingListView()
        {
            return listViewSettings.SelectedItems.Count > 0 ? listViewSettings.SelectedItems[0]?.Tag as Setting : null;
        }

        private void ClearFields()
        {
            txtAlias.Clear();
            txtConnectionString.Clear();
            comboBoxDbms.SelectedIndex = -1;
            checkBoxDefaultSetting.Checked = false;
        }

        private void LoadFields(Setting setting)
        {
            txtAlias.Text = setting.Alias;
            txtConnectionString.Text = setting.StringConnection;
            comboBoxDbms.SelectedItem = setting.Dbms;
            checkBoxDefaultSetting.Checked = setting.IsDefaultSetting;
        }

        private void btnAddSetting_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAlias.Text) || string.IsNullOrEmpty(txtConnectionString.Text) || comboBoxDbms.SelectedIndex == -1)            
                MessageBox.Show("You must to fill all fields before adding a new setting", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);            
            else
            {
                Enum.TryParse(typeof(Dbms), comboBoxDbms.SelectedItem.ToString(), out var dbmsAux);

                var setting = new Setting()
                {
                    Alias = txtAlias.Text,
                    StringConnection = txtConnectionString.Text,
                    Dbms = (Dbms)dbmsAux,
                    IsDefaultSetting = checkBoxDefaultSetting.Checked
                };

                if (Setting.Settings == null)
                    Setting.Settings = new List<Setting>();

                if (setting.IsDefaultSetting) 
                    Setting.Settings.ForEach(c => c.IsDefaultSetting = false);

                Setting.Settings.Add(setting);
                Setting.Save();

                ClearFields();                
                LoadExistingSettingsInListView();                
            }
        }

        private void btnUpdateSetting_Click(object sender, EventArgs e)
        {
            var setting = GetSelectedSettingListView();

            if (setting != null)
            {
                Enum.TryParse(typeof(Dbms), comboBoxDbms.SelectedItem.ToString(), out var dbmsAux);

                setting.Alias = txtAlias.Text;
                setting.StringConnection = txtConnectionString.Text;
                setting.IsDefaultSetting = checkBoxDefaultSetting.Checked;
                setting.Dbms = (Dbms)dbmsAux;

                Setting.Settings.ForEach(s => { if (s != setting && setting.IsDefaultSetting) s.IsDefaultSetting = false; }) ;
                Setting.Save();
                
                ClearFields();                
                LoadExistingSettingsInListView();
            }
        }

        private void btnDeleteSetting_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure you want to delete this setting?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var setting = GetSelectedSettingListView();

                if (setting != null)
                {
                    Setting.Settings.Remove(setting);
                    Setting.Save();

                    ClearFields();
                    LoadExistingSettingsInListView();
                }
            }
        }

        private void btnTesteConnectionString_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtConnectionString.Text))
                    MessageBox.Show("You must inform the connection string!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (comboBoxDbms.SelectedIndex == -1)
                    MessageBox.Show("You must select the Dbms!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    switch ((Dbms)comboBoxDbms.SelectedItem)
                    {
                        case Dbms.SQLServer: _builder = new SqlBuilder(null, Setting.DefaultSetting); break;
                    }

                    _builder.TestConnectionString(txtConnectionString.Text);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error trying to test the connection string!\n\nError message: { error.Message }", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStringConnectionFormat_Click(object sender, EventArgs e)
        {
            if (comboBoxDbms.SelectedIndex == -1)
                MessageBox.Show("You must select the Dbms!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {   
                switch ((Dbms)comboBoxDbms.SelectedItem)
                {
                    case Dbms.SQLServer: _builder = new SqlBuilder(null, Setting.DefaultSetting); break;
                }

                var stringConnectionFormat = _builder.GetConnectionStringFormat();

                if (MessageBox.Show(
                    $"That's the connection string format you need to build:\n\n{ stringConnectionFormat }\n\nPress 'OK' to copy to clipboard.",
                    "Information",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information) == DialogResult.OK)
                    Clipboard.SetText(stringConnectionFormat);
            }            
        }

        private void listViewSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            var setting = GetSelectedSettingListView();

            if (setting != null)
                LoadFields(setting);
        }
    }
}
