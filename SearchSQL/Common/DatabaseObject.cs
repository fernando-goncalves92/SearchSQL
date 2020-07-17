using System.Windows.Forms;

namespace SearchSQL
{
    public class DatabaseObject
    {
        public DatabaseObject(string name, string content, DatabaseObjectType type)
        {
            Name = name;
            Content = content;
            Type = type;
        }

        public string Name { get; private set; }
        public string Content { get; private set; }
        public DatabaseObjectType Type { get; private set; }
    }
}
