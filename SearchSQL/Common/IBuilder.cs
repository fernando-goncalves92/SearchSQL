using System.Windows.Forms;

namespace SearchSQL
{
    public interface IBuilder : ISaveFile
    {
        int BuildTreeViewNodes();
        int FindContentAndObjects(string word);
        ImageList LoadImageList();
        TabPage AddTabPage(DatabaseObject obj);
    }
}
