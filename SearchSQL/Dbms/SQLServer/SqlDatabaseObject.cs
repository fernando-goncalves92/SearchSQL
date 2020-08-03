using System;

namespace SearchSQL
{
    public class SqlDatabaseObject : DatabaseObject
    {
        public SqlDatabaseObject(string name, string content, DateTime createDate, DateTime modifyDate, SqlDatabaseObjectType type) 
            : base (name, content, createDate, modifyDate, type == SqlDatabaseObjectType.Table)
        {
            Type = type;
        }
        
        public SqlDatabaseObjectType Type { get; private set; }
    }
}
