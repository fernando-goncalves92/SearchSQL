using System.Collections.Generic;

namespace SearchSQL
{
    public static class Config
    {
        public static List<ConfigItem> Items { get; private set; } 

        public static void LoadParameters()
        {
            
        }
    }

    public class ConfigItem
    {
        public ConfigItem(string alias, string stringConnection, bool principalConnection)
        {
            Alias = alias;
            StringConnection = StringConnection;
            PrincipalConnection = principalConnection;
        }

        public string Alias { get; private set; }
        public string StringConnection { get; private set; }
        public bool PrincipalConnection { get; private set; }
    }
}
