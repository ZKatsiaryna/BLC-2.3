using RegularExpressions.Configuration;
using System;
using System.IO;

namespace RegularExpressions
{
    class ConsoleLog : ILog
    {
        CustomConfigurationSection CustomConfig;

        public ConsoleLog(CustomConfigurationSection customConfig)
        {
            CustomConfig = customConfig;
        }

        public void WriteFileInfo (FileInfo fileInf)
        {       
            Console.WriteLine(CustomConfig.FileFormatStringInfo.StringFormatInfo, fileInf.Name, fileInf.Extension, fileInf.Length);
        }

        public void WriteScanResult(int countSymbolsIsReplaced, int countSymbolsNotReplaced)
        {
            Console.WriteLine(CustomConfig.FileFormatStringResult.StringFormatResult, countSymbolsIsReplaced + countSymbolsNotReplaced, countSymbolsIsReplaced);
        }

        public void WriteSymbolsInfo(string infoAboutSymbols)
        {
            Console.WriteLine(infoAboutSymbols);
        }


    }
}
