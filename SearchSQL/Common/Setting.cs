using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace SearchSQL
{
    public partial class Setting
    {
        public string Alias { get; set; }
        public string StringConnection { get; set; }
        public bool IsDefaultSetting { get; set; }
        public Dbms Dbms { get; set; }

        public override string ToString()
        {
            return Alias;
        }
    }

    public partial class Setting
    {
        private static readonly string SETTING_FILE = AppDomain.CurrentDomain.BaseDirectory + @"\Settings.xml";
        public static List<Setting> Settings { get; set; }
        public static Setting DefaultSetting { get { return Settings?.FirstOrDefault(i => i.IsDefaultSetting) ?? Settings?.FirstOrDefault(); } }

        public static void Load()
        {   
            try
            {
                var serializer = new XmlSerializer(typeof(List<Setting>));

                using (StreamReader reader = new StreamReader(SETTING_FILE))
                {
                    Settings = (List<Setting>)serializer.Deserialize(reader);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(
                    $"Error trying to load settings file.\n\nError Message: { error.Message } \n\nStack Trace: { error.StackTrace }",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Environment.Exit(0);
            }
        }

        public static void Save()
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<Setting>));

                using (StreamWriter writer = new StreamWriter(SETTING_FILE))
                {
                    serializer.Serialize(writer, Settings);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(
                    $"Error trying to save settings.\n\nError Message: { error.Message } \n\nStack Trace: { error.StackTrace }",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public static void MakeDefaultSetting(Setting setting)
        {
            Settings.ForEach(s => s.IsDefaultSetting = s == setting ? true : false);            
            
            Save();

            MessageBox.Show("The default setting has been successfully changed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool FileExists()
        {
            return File.Exists(SETTING_FILE);
        }
    }
}
