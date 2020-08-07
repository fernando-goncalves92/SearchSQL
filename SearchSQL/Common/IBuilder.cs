using System.Collections.Generic;
using System.Windows.Forms;

namespace SearchSQL
{
    public interface IBuilder
    {
        int BuildTreeViewNodes(IEnumerable<DatabaseObject> objects = null);
        int FindContentAndObjects(string word);
        ImageList LoadImageList();
        TabPage AddTabPage(DatabaseObject obj);
        void SaveFile(string suggestedFileName, string fileContent);
        string GetConnectionStringFormat();
        void TestConnectionString(string connectionString);        
    }
}
