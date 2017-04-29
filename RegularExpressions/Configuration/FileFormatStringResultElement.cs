using System.Configuration;

namespace RegularExpressions.Configuration
{
    class FileFormatStringResultElement : ConfigurationElement
    {
        [ConfigurationProperty("stringFormat")]
        public string StringFormatResult
        {
            get { return (string)base["stringFormat"]; }
        }
    }
}
