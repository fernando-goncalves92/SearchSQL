namespace SearchSQL
{
    public abstract class DatabaseObject
    {
        public DatabaseObject(string name, string content)
        {
            Name = name;
            Content = content;
        }

        public string Name { get; private set; }
        public string Content { get; private set; }
    }
}
