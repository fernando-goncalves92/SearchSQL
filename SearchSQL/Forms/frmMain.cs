using System;
using System.Drawing;
using System.Windows.Forms;

namespace SearchSQL
{
    public partial class frmMain : Form
    {
        private const string PLACE_HOLDER_MESSAGE = "Type the content or object you're looking for...";

        private IBuilder _builder;

        public frmMain()
        {
            InitializeComponent();

            // temp
            _builder = new SqlBuilder(treeViewObjects);

            SetImageListTabControl();

            BuildTreeView();
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

        private void RemoveTabPage(string tabPageName)
        {
            tabControlContent.TabPages.RemoveByKey(tabPageName);
        }

        private void RemoveAllTabs()
        {
            foreach (TabPage tab in tabControlContent.TabPages)
                RemoveTabPage(tab.Name);
        }

        private void txtContentOrObjectToFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            const int ENTER = 13;

            if (e.KeyChar == ENTER)
                SetNumberOfFoundObjects(_builder.FindContentAndObjects(txtContentOrObjectToFind.Text));
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
            {
                var tabPage = _builder.AddTabPage(databaseObject);

                tabControlContent.TabPages.Add(tabPage);
                tabControlContent.SelectedTab = tabControlContent.TabPages[tabPage.Name];
            }
        }
    }
}
