using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace SearchSQL
{
    public class SqlTreeView : ITreeView
    {
        private const int FOLDER_ICON_INDICE = 0;
        private const int PROCEDURE_ICON_INDICE = 1;
        private const int SCALAR_FUNCTION_ICON_INDICE = 2;
        private const int TABLE_FUNCTION_ICON_INDICE = 3;
        private const int VIEW_ICON_INDICE = 4;
        private const int TRIGGER_ICON_INDICE = 5;

        private TreeView _treeView;
        private SqlDatabase _db;

        public SqlTreeView(TreeView treeview)
        {
            _db = new SqlDatabase();

            _treeView = treeview;

            LoadImagesTreeView();
        }

        private void LoadImagesTreeView()
        {
            ImageList images = new ImageList();

            images.Images.Add(Image.FromFile(@"images\sql\folder.png"));
            images.Images.Add(Image.FromFile(@"images\sql\procedure.png"));
            images.Images.Add(Image.FromFile(@"images\sql\scalarFunction.png"));
            images.Images.Add(Image.FromFile(@"images\sql\tableFunction.png"));
            images.Images.Add(Image.FromFile(@"images\sql\view.png"));
            images.Images.Add(Image.FromFile(@"images\sql\trigger.png"));

            _treeView.ImageList = images;
        }

        private int GetImageIndexByType(SqlDatabaseObjectType type)
        {
            switch(type)
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

        private void BuildRootNodes()
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

        private void BuildNodes(IEnumerable<SqlDatabaseObject> objects)
        {
            try
            {
                _treeView.BeginUpdate();

                ClearNodes();

                BuildRootNodes();

                foreach (var obj in objects)
                {
                    var rootNode = GetRootNodeByType(obj.Type);

                    if (rootNode != null)
                        rootNode.Nodes.Add(new TreeNode()
                        {
                            Text = obj.Name,
                            ImageIndex = GetImageIndexByType(obj.Type),
                            SelectedImageIndex = GetImageIndexByType(obj.Type),
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

        public int BuildNodes()
        {
            int numberOfObjects = 0;

            try
            {
                _treeView.BeginUpdate();

                ClearNodes();

                BuildRootNodes();

                var objects = _db.GetObjectsFromDb();

                numberOfObjects = objects.Count();

                foreach (var obj in objects)
                {
                    var rootNode = GetRootNodeByType(obj.Type);

                    if (rootNode != null)
                        rootNode.Nodes.Add(new TreeNode()
                        {
                            Text = obj.Name,
                            ImageIndex = GetImageIndexByType(obj.Type),
                            SelectedImageIndex = GetImageIndexByType(obj.Type),
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

                BuildNodes(objects);
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

        public void SaveFile()
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.InitialDirectory = @"C:\";
                dialog.RestoreDirectory = true;
                dialog.Filter = "SQL file |*.sql";
                dialog.Title = "Save the object";
                dialog.ShowDialog();

                if (!string.IsNullOrEmpty(dialog.FileName))
                {
                    using (FileStream fs = (FileStream)dialog.OpenFile())
                    {
                        fs.Close();
                    }
                }
            }
        }
    }
}
