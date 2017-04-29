using RegularExpressions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;


namespace RegularExpressions
{
    class Program
    {
        public static CustomConfigurationSection CustomConfig;

        static void Main(string[] args)
        {
            CustomConfig = GetConfiguration();

            string filePath = @"D:\1\1.txt";
            ILog Log = new ConsoleLog(CustomConfig);
            FileScaner file = new FileScaner(filePath, Log, CustomConfig);
            file.PrintFileInfo();

            bool isExist = file.IsExistOtherSymbols();
        }

        private static CustomConfigurationSection GetConfiguration()
        {
            return (CustomConfigurationSection)ConfigurationManager.GetSection("CustomConfigurationSection");
        }
    }
}
