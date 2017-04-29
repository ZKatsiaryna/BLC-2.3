using System.Configuration;


namespace RegularExpressions.Configuration
{
    class CustomConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("appName")]
        public string ApplicationName
        {
            get { return (string)base["appName"]; }
        }

        [ConfigurationProperty("FileFormatStringInfo")]
        public FileFormatStringInfoElement FileFormatStringInfo
        {
            get { return (FileFormatStringInfoElement)this["FileFormatStringInfo"]; }
        }

        [ConfigurationProperty("FileFormatStringInfoSubstring")]
        public FileFormatStringInfoSubstringElement FileFormatStringSubstringInfo
        {
            get { return (FileFormatStringInfoSubstringElement)this["FileFormatStringInfoSubstring"]; }
        }

        [ConfigurationProperty("FileFormatStringResult")]
        public FileFormatStringResultElement FileFormatStringResult
        {
            get { return (FileFormatStringResultElement)this["FileFormatStringResult"]; }
        }

        [ConfigurationProperty("SaveToBackupFolder")]
        public SaveToBackupFolderElement SaveToBackupFolder
        {
            get { return (SaveToBackupFolderElement)this["SaveToBackupFolder"]; }
        }

        [ConfigurationProperty("SaveChanges")]
        public SaveChangesElement SaveChanges
        {
            get { return (SaveChangesElement)this["SaveChanges"]; }
        }
    }
}
