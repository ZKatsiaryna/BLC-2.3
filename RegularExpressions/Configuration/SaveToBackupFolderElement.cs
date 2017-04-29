using System.Configuration;


namespace RegularExpressions
{
    class SaveToBackupFolderElement : ConfigurationElement
    {
        [ConfigurationProperty("destinationPath")]
        public string DestinationPath
        {
            get { return (string)this["destinationPath"]; }
        }

        [ConfigurationProperty("enable", DefaultValue = true)]
        public bool IsEnabled
        {
            get { return (bool)this["enable"]; }
        }
    }
}
