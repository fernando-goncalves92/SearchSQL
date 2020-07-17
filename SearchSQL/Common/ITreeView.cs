using System.Windows.Forms;

namespace SearchSQL
{
    public interface ITreeView : ISaveFile
    {
        int BuildNodes();
        int FindContentAndObjects(string word);
        ImageList LoadImageList();
        int GetImageIndex(DatabaseObject obj);
    }
}
