using System;

namespace SearchSQL
{
    public class SqlDatabaseObject : DatabaseObject
    {
        public SqlDatabaseObject(
            string name, 
            string content, 
            DateTime createDate, 
            DateTime modifyDate, 
            SqlDatabaseObjectType type, 
            string database) : base (name, content, createDate, modifyDate, type == SqlDatabaseObjectType.Table, database)
        {
            Type = type;
        }
        
        public SqlDatabaseObjectType Type { get; private set; }
    }
}
