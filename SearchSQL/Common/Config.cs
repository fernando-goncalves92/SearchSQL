using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;

namespace SearchSQL
{
    public class Config
    {
        private static readonly string CONFIG_FILE = AppDomain.CurrentDomain.BaseDirectory + @"\Config.xml";

        public static List<ConfigItem> Items { get; private set; }
        public static ConfigItem DefaultConfig { get { return Items?.FirstOrDefault(i => i.DefaultConfig) ?? Items?.FirstOrDefault(); } }

        public static void Load()
        {   
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<ConfigItem>));

                using (StreamReader reader = new StreamReader(CONFIG_FILE))
                {
                    Items = (List<ConfigItem>)serializer.Deserialize(reader);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(
                    $"Error trying to load configuration file.\n\nError Message: { error.Message } \n\nStack Trace: { error.StackTrace }",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public static void Save()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<ConfigItem>));

                using (StreamWriter writer = new StreamWriter(CONFIG_FILE))
                {
                    serializer.Serialize(writer, Items);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(
                    $"Error trying to save configuration.\n\nError Message: { error.Message } \n\nStack Trace: { error.StackTrace }",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public static void MakeDefaultConfiguration(ConfigItem config)
        {
            Items.ForEach(i => i.DefaultConfig = i == config ? true : false);

            Save();

            MessageBox.Show("The default configuration has been successfully changed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    public class ConfigItem
    {
        public string Alias { get; set; }
        public string StringConnection { get; set; }
        public bool DefaultConfig { get; set; }        
        public Dbms Dbms { get; set; }

        public override string ToString()
        {
            return Alias;
        }
    }
}
