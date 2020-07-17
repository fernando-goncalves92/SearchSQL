using System;
using System.Drawing;
using System.Windows.Forms;

namespace SearchSQL
{
    public partial class frmMain : Form
    {
        private const string PLACE_HOLDER_MESSAGE = "Type the content or object you're looking for...";

        private ITreeView _treeView;

        public frmMain()
        {
            InitializeComponent();

            BuildTreeView();
        }

        private void BuildTreeView()
        {
            // temp
            if (_treeView == null)            
                _treeView = new SqlTreeView(treeViewOfObjects);

            SetNumberOfFoundObjects(_treeView.BuildNodes());
        }

        private void SetNumberOfFoundObjects(int numberOfObjects)
        {
            lblFooterTotal.Text = $"Found objects: { numberOfObjects }";
        }

        private void AddTabPage(string objectName, string content)
        {
            var tabPageName = $"tabPage{ objectName }";

            if (tabControlContent.TabPages.ContainsKey(tabPageName))
            {
                tabControlContent.SelectedTab = tabControlContent.TabPages[tabPageName];

                return;
            }

            var tabPage = new TabPage() { Name = tabPageName, Text = objectName };
            var textBox = new TextBox() { Dock = DockStyle.Fill, Multiline = true, Text = content };

            tabPage.Controls.Add(textBox);

            tabControlContent.TabPages.Add(tabPage);
            tabControlContent.SelectedTab = tabControlContent.TabPages[tabPageName];
        }

        private void RemoveTabPage(string tabPageName)
        {
            tabControlContent.TabPages.RemoveByKey(tabPageName);
        }

        private void RemoveAllTabs()
        {
            foreach (TabPage tab in tabControlContent.TabPages)
                RemoveTabPage(tab.Name);
        }

        private void SaveTabPage()
        {
            _treeView.SaveFile();
        }

        private void txtContentOrObjectToFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            const int ENTER = 13;

            if (e.KeyChar == ENTER)
                SetNumberOfFoundObjects(_treeView.FindContentAndObjects(txtContentOrObjectToFind.Text));
        }

        private void tabControlContent_KeyDown(object sender, KeyEventArgs e)
        {
            SaveTabPage();

            //if (e.Control && e.KeyCode == Keys.S)
            //{
            //    SaveTabPage();
            //}
        }

        private void txtContentFind_Enter(object sender, EventArgs e)
        {
            if (txtContentOrObjectToFind.Text == PLACE_HOLDER_MESSAGE)
            {
                txtContentOrObjectToFind.Clear();
                txtContentOrObjectToFind.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
                txtContentOrObjectToFind.ForeColor = Color.Black;
            }
        }

        private void txtContentFind_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtContentOrObjectToFind.Text))
            {
                txtContentOrObjectToFind.Text = PLACE_HOLDER_MESSAGE;
                txtContentOrObjectToFind.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
                txtContentOrObjectToFind.ForeColor = Color.Gray;
            }
        }

        private void treeViewOfObjects_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var databaseObject = e.Node.Tag as DatabaseObject;

            if (databaseObject != null)            
                AddTabPage(databaseObject.Name, databaseObject.Content);
        }

        private void tabPage1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }
    }
}
