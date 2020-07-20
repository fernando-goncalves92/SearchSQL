using System;

namespace SearchSQL
{
    public abstract class DatabaseObject
    {
        public DatabaseObject(string name, string content, DateTime createDate, DateTime modifyDate)
        {
            Name = name;
            Content = content;
            CreateDate = createDate;
            ModifyDate = modifyDate;
        }

        public string Name { get; private set; }
        public string Content { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime ModifyDate { get; private set; }
    }
}
