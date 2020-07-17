using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Search;
using ICSharpCode.AvalonEdit.Highlighting;

namespace SearchSQL
{
    public partial class frmMain : Form
    {
        private const string PLACE_HOLDER_MESSAGE = "Type the content or object you're looking for...";

        private ITreeView _treeView;

        public frmMain()
        {
            InitializeComponent();

            // temp
            _treeView = new SqlTreeView(treeViewObjects);

            SetImageListTabControl();

            BuildTreeView();
        }

        private void BuildTreeView()
        {
            SetNumberOfFoundObjects(_treeView.BuildNodes());
        }

        private void SetNumberOfFoundObjects(int numberOfObjects)
        {
            lblFooterTotal.Text = $"Found objects: { numberOfObjects }";
        }

        private void AddTabPage(DatabaseObject obj)
        {
            var tabPageName = $"tabPage{ obj.Name }";

            if (tabControlContent.TabPages.ContainsKey(tabPageName))
            {
                tabControlContent.SelectedTab = tabControlContent.TabPages[tabPageName];

                return;
            }

            var tabPage = new TabPage() { Name = tabPageName, Text = obj.Name, ImageIndex = _treeView.GetImageIndex(obj) };

            var elementHost = new ElementHost() { Dock = DockStyle.Fill, TabIndex = 1 };

            var textEditor = new TextEditor() 
            { 
                ShowLineNumbers = true, 
                SyntaxHighlighting = (IHighlightingDefinition)new HighlightingDefinitionTypeConverter().ConvertFrom("TSQL"),
                FontFamily = new System.Windows.Media.FontFamily("Consolas"),
                FontSize = 13.75f,
                IsReadOnly = true,
                Text = obj.Content
            };

            textEditor.KeyDown += TextEditor_KeyDown;

            SearchPanel.Install(textEditor);

            elementHost.Child = textEditor;

            tabPage.Controls.Add(elementHost);

            tabControlContent.TabPages.Add(tabPage);
            tabControlContent.SelectedTab = tabControlContent.TabPages[tabPageName];
        }

        private void TextEditor_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.S)
            {
                var fileName = _treeView.SaveFile();

                if (!string.IsNullOrEmpty(fileName))
                {
                    var textEditor = sender as TextEditor;

                    textEditor.Save(fileName);
                }
            }
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

        private void SetImageListTabControl()
        {
            tabControlContent.ImageList = _treeView.LoadImageList();
        }

        private void txtContentOrObjectToFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            const int ENTER = 13;

            if (e.KeyChar == ENTER)
                SetNumberOfFoundObjects(_treeView.FindContentAndObjects(txtContentOrObjectToFind.Text));
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
                AddTabPage(databaseObject);
        }
    }
}
