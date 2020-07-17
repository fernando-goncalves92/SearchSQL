namespace SearchSQL
{
    public class SqlDatabaseObject : DatabaseObject
    {
        public SqlDatabaseObject(string name, string content, SqlDatabaseObjectType type) : base (name, content)
        {
            Type = type;
        }
        
        public SqlDatabaseObjectType Type { get; private set; }
    }
}
