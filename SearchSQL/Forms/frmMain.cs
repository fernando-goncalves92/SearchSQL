using System;
using System.Drawing;
using System.Windows.Forms;

namespace SearchSQL
{
    public partial class frmMain : Form
    {
        private const string PLACE_HOLDER_MESSAGE = "Type the content or object you're looking for...";

        private IBuilder _builder;

        private ContextMenuStrip _contextMenuTabControl;
        private ContextMenuStrip _contextMenuTreeView;

        public frmMain()
        {
            InitializeComponent();

            Config.Load();

            SetComboBoxConfigDataSource();

            CreateToolStripButtonsEvent();

            BuilTabControlContextMenu();

            BuildTreeViewContextMenu();

            BuildScreen(Config.DefaultConfig);
        }

        private void BuildScreen(ConfigItem activeConfig)
        {
            switch (activeConfig.Dbms)
            {
                case Dbms.SQLServer:
                    {
                        _builder = new SqlBuilder(treeViewObjects, activeConfig);

                        break;
                    }
            }

            if (_builder != null)
            {
                SetObjectDetailsInvisible();

                SetImageListTabControl();

                BuildTreeView();
            }
            else            
                MessageBox.Show("This DBMS type was not implemented yet!\n\nPlease, insert a valid DBMS type and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CreateToolStripButtonsEvent()
        {
            comboBoxConfig.SelectedIndexChanged += comboBoxConfig_SelectedIndexChanged;
            btnMakeDefaultConfig.Click += btnMakeDefaultConfig_Click;
        }

        private void SetComboBoxConfigDataSource()
        {
            comboBoxConfig.ComboBox.DataSource = Config.Items;
            comboBoxConfig.ComboBox.SelectedItem = Config.DefaultConfig;
        }

        private void BuildTreeView()
        {
            SetNumberOfFoundObjects(_builder.BuildTreeViewNodes());
        }

        private void SetNumberOfFoundObjects(int numberOfObjects)
        {
            lblFooterTotal.Text = $"Found objects: { numberOfObjects }";
        }

        private void SetImageListTabControl()
        {
            tabControlContent.ImageList = _builder.LoadImageList();
        }

        private void SetObjectDetails(DatabaseObject obj)
        {
            lblObjectCreateDate.Visible = false;
            lblObjectModifyDate.Visible = false;
            separatorFooter1.Visible = false;
            
            if (obj.CreateDate != null)
            {
                lblObjectCreateDate.Text = $"Create Date: { obj.CreateDate.ToString("yyyy-MM-dd HH:mm:ss") }";
                lblObjectCreateDate.Visible = true;
                separatorFooter1.Visible = true;
                pictureBoxObjectDetails.Visible = true;
            }

            if (obj.ModifyDate != null)
            {
                lblObjectModifyDate.Text = $"Modify Date: { obj.ModifyDate.ToString("yyyy-MM-dd HH:mm:ss") }";
                lblObjectModifyDate.Visible = true;
                separatorFooter1.Visible = true;
                pictureBoxObjectDetails.Visible = true;
            }
        }

        private void SetObjectDetailsInvisible()
        {
            lblObjectCreateDate.Visible = false;
            lblObjectModifyDate.Visible = false;
            separatorFooter1.Visible = false;
            pictureBoxObjectDetails.Visible = false;
        }

        private void BuilTabControlContextMenu()
        {
            _contextMenuTabControl = new ContextMenuStrip();

            var save = new ToolStripMenuItem();
            save.Text = "Save";
            save.ShowShortcutKeys = true;
            save.ShortcutKeys = Keys.Control | Keys.S;
            save.Click += Save;
            save.Image = Properties.Resources.save;

            var saveAllDocuments = new ToolStripMenuItem();
            saveAllDocuments.Text = "Save All Documents";
            saveAllDocuments.ShowShortcutKeys = true;
            saveAllDocuments.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            saveAllDocuments.Click += SaveAllDocuments;
            saveAllDocuments.Image = Properties.Resources.saveAll;

            var close = new ToolStripMenuItem();
            close.Text = "Close";
            close.ShowShortcutKeys = true;
            close.ShortcutKeys = Keys.Control | Keys.F4;
            close.Click += Close;

            var closeAllDocuments = new ToolStripMenuItem();
            closeAllDocuments.Text = "Close All Documents";
            closeAllDocuments.ShowShortcutKeys = true;
            closeAllDocuments.ShortcutKeys = Keys.Control | Keys.Shift | Keys.F4;
            closeAllDocuments.Click += CloseAllDocuments;

            var closeAllButThis = new ToolStripMenuItem();
            closeAllButThis.Text = "Close All But This";
            closeAllButThis.Click += CloseAllButThis;

            _contextMenuTabControl.Items.Add(save);
            _contextMenuTabControl.Items.Add(saveAllDocuments);
            _contextMenuTabControl.Items.Add(close);
            _contextMenuTabControl.Items.Add(closeAllDocuments);
            _contextMenuTabControl.Items.Add(closeAllButThis);
        }

        private void BuildTreeViewContextMenu()
        {
            _contextMenuTreeView = new ContextMenuStrip();

            var save = new ToolStripMenuItem();
            save.Text = "Save";            
            save.Click += Save;
            save.Image = Properties.Resources.save;

            var viewDocument = new ToolStripMenuItem();
            viewDocument.Text = "View Document";
            viewDocument.Click += ViewDocument;            
            viewDocument.Image = Properties.Resources.viewDocument;

            _contextMenuTreeView.Items.Add(save);
            _contextMenuTreeView.Items.Add(viewDocument);            
        }

        private void ViewDocument(object sender, EventArgs e)
        {
            var databaseObject = treeViewObjects.SelectedNode.Tag as DatabaseObject;

            if (databaseObject != null)            
                AddTabPage(databaseObject);
        }

        private void Save(object sender, EventArgs e)
        {
            _builder.SaveFile(tabControlContent.SelectedTab.Text, (tabControlContent.SelectedTab.Tag as DatabaseObject)?.Content);
        }

        private void SaveAllDocuments(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save all documents?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)            
                foreach (TabPage tab in tabControlContent.TabPages)                
                    _builder.SaveFile(tab.Text, (tab.Tag as DatabaseObject)?.Content);
        }

        private void Close(object sender, EventArgs e)
        {
            tabControlContent.TabPages.RemoveByKey(tabControlContent.SelectedTab.Name);
        }

        private void CloseAllDocuments(object sender, EventArgs e)
        {
            foreach (TabPage tab in tabControlContent.TabPages)
                tabControlContent.TabPages.RemoveByKey(tab.Name);
        }

        private void CloseAllButThis(object sender, EventArgs e)
        {
            foreach (TabPage tab in tabControlContent.TabPages)
                if (tab.Name != tabControlContent.SelectedTab.Name)
                    tabControlContent.TabPages.RemoveByKey(tab.Name);
        }

        private void AddTabPage(DatabaseObject databaseObject)
        {
            if (tabControlContent.TabPages.ContainsKey($"tabPage{ databaseObject.Name }"))            
                tabControlContent.SelectedTab = tabControlContent.TabPages[$"tabPage{ databaseObject.Name }"];            
            else
            {
                var tabPage = _builder.AddTabPage(databaseObject);

                tabControlContent.TabPages.Add(tabPage);
                tabControlContent.SelectedTab = tabControlContent.TabPages[tabPage.Name];

                if (tabControlContent.TabPages.Count == 1)
                    SetObjectDetails(databaseObject);
            }
        }

        private void txtContentOrObjectToFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            const int ENTER = 13;

            if (e.KeyChar == ENTER)
            {
                if (string.IsNullOrEmpty(txtContentOrObjectToFind.Text))
                    SetNumberOfFoundObjects(_builder.BuildTreeViewNodes());
                else
                    SetNumberOfFoundObjects(_builder.FindContentAndObjects(txtContentOrObjectToFind.Text));
            }
        }

        /// <summary>
        /// Got focus in search field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtContentFind_Enter(object sender, EventArgs e)
        {
            if (txtContentOrObjectToFind.Text == PLACE_HOLDER_MESSAGE)
            {
                txtContentOrObjectToFind.Clear();
                txtContentOrObjectToFind.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
                txtContentOrObjectToFind.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Lost focus in search field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtContentFind_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtContentOrObjectToFind.Text))
            {
                txtContentOrObjectToFind.Text = PLACE_HOLDER_MESSAGE;
                txtContentOrObjectToFind.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
                txtContentOrObjectToFind.ForeColor = Color.Gray;
            }
        }

        /// <summary>
        /// Double click on treeview node
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewOfObjects_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var databaseObject = e.Node.Tag as DatabaseObject;

            if (databaseObject != null)            
                AddTabPage(databaseObject);
        }

        /// <summary>
        /// Selected tabPage changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControlContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tabControl = sender as TabControl;

            if (tabControl.SelectedIndex > -1)
            {
                var databaseObj = tabControl.TabPages[tabControl.SelectedIndex].Tag as DatabaseObject;

                if (databaseObj != null)
                    SetObjectDetails(databaseObj);
            }
        }
        
        /// <summary>
        /// Mouse click on tabControlContent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControlContent_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                for (var count = 0; count < tabControlContent.TabCount; count++)
                {
                    var tab = tabControlContent.GetTabRect(count);

                    if (tab.Contains(e.Location))
                        tabControlContent.SelectedIndex = count;
                }

                _contextMenuTabControl.Show(this, Cursor.Position);
            }
        }

        /// <summary>
        /// Mouse click on treeview nodes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewObjects_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeViewObjects.SelectedNode = e.Node;

                if (e.Node.Parent != null)
                    _contextMenuTreeView.Show(this, Cursor.Position);
            }
        }

        /// <summary>
        /// Change default config clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMakeDefaultConfig_Click(object sender, EventArgs e)
        {
            Config.MakeDefaultConfiguration(comboBoxConfig.SelectedItem as ConfigItem);
        }

        /// <summary>
        /// Active configuration changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildScreen(comboBoxConfig.SelectedItem as ConfigItem);
        }
    }
}
