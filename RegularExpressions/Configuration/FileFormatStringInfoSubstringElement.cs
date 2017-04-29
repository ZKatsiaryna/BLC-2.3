using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularExpressions.Configuration
{
    class FileFormatStringInfoSubstringElement : ConfigurationElement
    {
        [ConfigurationProperty("stringFormat")]
        public string StringFormatInfo
        {
            get { return (string)base["stringFormat"]; }
        }
    }
}
