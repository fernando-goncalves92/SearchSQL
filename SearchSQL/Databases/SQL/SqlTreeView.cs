using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace SearchSQL
{
    public class SqlTreeView : ITreeView
    {
        private const int FOLDER_ICON = 0;
        private const int PROCEDURE_ICON = 1;
        private const int SCALAR_FUNCTION_ICON = 2;
        private const int TABLE_FUNCTION_ICON = 3;
        private const int VIEW_ICON = 4;
        private const int TRIGGER_ICON = 5;

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

        private int GetImageIndexByType(DatabaseObjectType type)
        {
            switch(type)
            {
                case DatabaseObjectType.Procedure: 
                    return PROCEDURE_ICON;
                case DatabaseObjectType.ScalarFunction: 
                    return SCALAR_FUNCTION_ICON;
                case DatabaseObjectType.TableFunction: 
                    return TABLE_FUNCTION_ICON;
                case DatabaseObjectType.View: 
                    return VIEW_ICON;
                case DatabaseObjectType.Trigger: 
                    return TRIGGER_ICON;
                default: 
                    return -1;
            }
        }

        private TreeNode GetRootNodeByType(DatabaseObjectType type)
        {
            foreach (TreeNode node in _treeView.Nodes)
                if ((DatabaseObjectType)node.Tag == type)                
                    return node;

            return null;
        }

        private void ClearNodes()
        {
            _treeView.Nodes.Clear();
        }

        private void BuildRootNodes()
        {
            var procedures = new TreeNode() { Text = "Procedures", ImageIndex = FOLDER_ICON, Tag = DatabaseObjectType.Procedure };
            var scalarFunctions = new TreeNode() { Text = "Scalar Functions", ImageIndex = FOLDER_ICON, Tag = DatabaseObjectType.ScalarFunction };
            var tableFunctions = new TreeNode() { Text = "Table Functions", ImageIndex = FOLDER_ICON, Tag = DatabaseObjectType.TableFunction };
            var triggers = new TreeNode() { Text = "Triggers", ImageIndex = FOLDER_ICON, Tag = DatabaseObjectType.Trigger };
            var views = new TreeNode() { Text = "Views", ImageIndex = FOLDER_ICON, Tag = DatabaseObjectType.View };

            _treeView.Nodes.Add(procedures);
            _treeView.Nodes.Add(scalarFunctions);
            _treeView.Nodes.Add(tableFunctions);
            _treeView.Nodes.Add(triggers);
            _treeView.Nodes.Add(views);
        }

        private void BuildNodes(IEnumerable<DatabaseObject> objects)
        {
            try
            {
                ClearNodes();

                BuildRootNodes();

                _treeView.BeginUpdate();

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
                ClearNodes();

                BuildRootNodes();

                _treeView.BeginUpdate();
                
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
                IEnumerable<DatabaseObject> objects = _db.FindContentAndObjects(word);

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
    }
}
