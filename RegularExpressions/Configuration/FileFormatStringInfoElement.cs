using System.Configuration;


namespace RegularExpressions.Configuration
{
    class FileFormatStringInfoElement : ConfigurationElement
    {
        [ConfigurationProperty("stringFormat")]
        public string StringFormatInfo
        {
            get { return (string)base["stringFormat"]; }
        }
    }
}
