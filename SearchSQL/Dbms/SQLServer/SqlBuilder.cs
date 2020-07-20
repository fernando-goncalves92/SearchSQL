using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Search;
using ICSharpCode.AvalonEdit.Highlighting;

namespace SearchSQL
{
    public class SqlBuilder : IBuilder
    {
        private const int FOLDER_ICON_INDICE = 0;
        private const int PROCEDURE_ICON_INDICE = 1;
        private const int SCALAR_FUNCTION_ICON_INDICE = 2;
        private const int TABLE_FUNCTION_ICON_INDICE = 3;
        private const int VIEW_ICON_INDICE = 4;
        private const int TRIGGER_ICON_INDICE = 5;

        private TreeView _treeView;
        private SqlDatabase _db;

        public SqlBuilder(TreeView treeview)
        {
            _db = new SqlDatabase();

            _treeView = treeview;

            LoadImageList();
        }

        private void TextEditor_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if ((Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) && Keyboard.IsKeyDown(Key.S))
            {
                var fileName = SaveFile(((sender as TextEditor).Tag as DatabaseObject).Name);

                if (!string.IsNullOrEmpty(fileName))
                {
                    var textEditor = sender as TextEditor;

                    textEditor.Save(fileName);
                }
            }
            else if ((Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) && Keyboard.IsKeyDown(Key.F4))
            {
                // Close current tab
            }
        }

        private int GetImageIndexByType(DatabaseObject obj)
        {
            switch ((obj as SqlDatabaseObject).Type)
            {
                case SqlDatabaseObjectType.Procedure:
                    return PROCEDURE_ICON_INDICE;
                case SqlDatabaseObjectType.ScalarFunction:
                    return SCALAR_FUNCTION_ICON_INDICE;
                case SqlDatabaseObjectType.TableFunction:
                    return TABLE_FUNCTION_ICON_INDICE;
                case SqlDatabaseObjectType.View:
                    return VIEW_ICON_INDICE;
                case SqlDatabaseObjectType.Trigger:
                    return TRIGGER_ICON_INDICE;
                default:
                    return -1;
            }
        }

        private TreeNode GetRootNodeByType(SqlDatabaseObjectType type)
        {
            foreach (TreeNode node in _treeView.Nodes)
                if ((SqlDatabaseObjectType)node.Tag == type)                
                    return node;

            return null;
        }

        private void ClearNodes()
        {
            _treeView.Nodes.Clear();
        }

        private void BuildTreeViewRootNodes()
        {
            var procedures = new TreeNode() { Text = "Procedures", ImageIndex = FOLDER_ICON_INDICE, Tag = SqlDatabaseObjectType.Procedure };
            var scalarFunctions = new TreeNode() { Text = "Scalar Functions", ImageIndex = FOLDER_ICON_INDICE, Tag = SqlDatabaseObjectType.ScalarFunction };
            var tableFunctions = new TreeNode() { Text = "Table Functions", ImageIndex = FOLDER_ICON_INDICE, Tag = SqlDatabaseObjectType.TableFunction };
            var triggers = new TreeNode() { Text = "Triggers", ImageIndex = FOLDER_ICON_INDICE, Tag = SqlDatabaseObjectType.Trigger };
            var views = new TreeNode() { Text = "Views", ImageIndex = FOLDER_ICON_INDICE, Tag = SqlDatabaseObjectType.View };

            _treeView.Nodes.Add(procedures);
            _treeView.Nodes.Add(scalarFunctions);
            _treeView.Nodes.Add(tableFunctions);
            _treeView.Nodes.Add(triggers);
            _treeView.Nodes.Add(views);
        }

        private void BuildTreeViewNodes(IEnumerable<SqlDatabaseObject> objects)
        {
            try
            {
                _treeView.BeginUpdate();

                ClearNodes();

                BuildTreeViewRootNodes();

                foreach (var obj in objects)
                {
                    var rootNode = GetRootNodeByType(obj.Type);

                    if (rootNode != null)
                        rootNode.Nodes.Add(new TreeNode()
                        {
                            Text = obj.Name,
                            ImageIndex = GetImageIndexByType(obj),
                            SelectedImageIndex = GetImageIndexByType(obj),
                            Tag = obj                            
                        });
                }

                _treeView.EndUpdate();
            }
            catch (Exception error)
            {
                MessageBox.Show(
                    $"Error trying to filter nodes.\n\nError Message: { error.Message }\n\nStack Trace: { error.StackTrace }",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public int BuildTreeViewNodes()
        {
            int numberOfObjects = 0;

            try
            {
                _treeView.BeginUpdate();

                ClearNodes();

                BuildTreeViewRootNodes();

                var objects = _db.GetObjectsFromDb();

                numberOfObjects = objects.Count();

                foreach (var obj in objects)
                {
                    var rootNode = GetRootNodeByType(obj.Type);

                    if (rootNode != null)
                        rootNode.Nodes.Add(new TreeNode()
                        {
                            Text = obj.Name,
                            ImageIndex = GetImageIndexByType(obj),
                            SelectedImageIndex = GetImageIndexByType(obj),
                            Tag = obj
                        });
                }

                _treeView.EndUpdate();
            }
            catch (Exception error)
            {
                MessageBox.Show(
                    $"Error trying to build nodes.\n\nError Message: { error.Message }\n\nStack Trace: { error.StackTrace }",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return numberOfObjects;
        }  
        
        public int FindContentAndObjects(string word)
        {
            int numberOfObjects = 0;

            try
            {
                IEnumerable<SqlDatabaseObject> objects = _db.FindContentAndObjects(word);

                numberOfObjects = objects.Count();

                BuildTreeViewNodes(objects);
            }
            catch (Exception error)
            {
                MessageBox.Show(
                    $"Error trying to filter nodes.\n\nError Message: { error.Message }\n\nStack Trace: { error.StackTrace }",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return numberOfObjects;
        }

        public string SaveFile(string suggestedFileName)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.InitialDirectory = @"C:\";
                dialog.RestoreDirectory = true;
                dialog.Filter = "SQL file |*.sql";
                dialog.Title = "Save the object";
                dialog.FileName = suggestedFileName;
                dialog.ShowDialog();

                return dialog.FileName;
            }
        }

        public ImageList LoadImageList()
        {
            ImageList images = new ImageList();

            images.Images.Add(Image.FromFile(@"images\sql\folder.png"));
            images.Images.Add(Image.FromFile(@"images\sql\procedure.png"));
            images.Images.Add(Image.FromFile(@"images\sql\scalarFunction.png"));
            images.Images.Add(Image.FromFile(@"images\sql\tableFunction.png"));
            images.Images.Add(Image.FromFile(@"images\sql\view.png"));
            images.Images.Add(Image.FromFile(@"images\sql\trigger.png"));

            _treeView.ImageList = images;

            return images;
        }

        public TabPage AddTabPage(DatabaseObject obj)
        {
            var tabPageName = $"tabPage{ obj.Name }";

            var tabPage = new TabPage() { Name = tabPageName, Text = obj.Name, ImageIndex = GetImageIndexByType(obj), Tag = obj };

            var elementHost = new ElementHost() { Dock = DockStyle.Fill, TabIndex = 1 };

            var textEditor = new TextEditor()
            {
                ShowLineNumbers = true,
                SyntaxHighlighting = (IHighlightingDefinition)new HighlightingDefinitionTypeConverter().ConvertFrom("TSQL"),
                FontFamily = new System.Windows.Media.FontFamily("Consolas"),
                FontSize = 13.75f,
                IsReadOnly = true,
                Text = obj.Content,
                Tag = obj,
                Options = new TextEditorOptions() { HighlightCurrentLine = true }
            };

            textEditor.KeyDown += TextEditor_KeyDown;

            SearchPanel.Install(textEditor);

            elementHost.Child = textEditor;

            tabPage.Controls.Add(elementHost);

            return tabPage;
        }
    }
}
