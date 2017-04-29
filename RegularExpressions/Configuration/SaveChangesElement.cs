using System.Configuration;

namespace RegularExpressions.Configuration
{
    class SaveChangesElement : ConfigurationElement
    {
        [ConfigurationProperty("enable", IsRequired = true, DefaultValue = true)]
        public bool IsChangesSave
        {
            get { return (bool)this["enable"]; }
        }
    }
}
