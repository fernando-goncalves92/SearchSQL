using System.Windows.Forms;

namespace SearchSQL
{
    public interface IBuilder
    {
        int BuildTreeViewNodes();
        int FindContentAndObjects(string word);
        ImageList LoadImageList();
        TabPage AddTabPage(DatabaseObject obj);
        void SaveFile(string suggestedFileName, string fileContent);
    }
}
