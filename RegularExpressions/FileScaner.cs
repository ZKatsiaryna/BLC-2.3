using RegularExpressions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RegularExpressions
{
    class FileScaner
    {
        public int countSymbolsIsReplaced { get; private set; }
        public int countSymbolsNotReplaced { get; private set; }
        public string ScanFilePath { get; private set; }
        public string BackupPath { get; private set; }
        private bool EnableCopyFile { get; set; }
        private bool EnableSaveFile { get; set; }

        private string StringWithMultipleSpaces { get; set; }
        private List<string> listChangeText { get; set; }
        private bool isReplaceable = false;
        private FileInfo FileInf { get; set; }
        ILog Log { get; set; }
        CustomConfigurationSection CustomConfig { get; set; }

        public FileScaner()
        {

        }

        public FileScaner(string scanFilePath, ILog log, CustomConfigurationSection customConfig)
        {
            ScanFilePath = scanFilePath;
            BackupPath = customConfig.SaveToBackupFolder.DestinationPath;
            EnableCopyFile = customConfig.SaveToBackupFolder.IsEnabled;
            EnableSaveFile = customConfig.SaveChanges.IsChangesSave;
            FileInf = new FileInfo(scanFilePath);
            Log =log;
            CustomConfig = customConfig;
        }

        public void PrintFileInfo()
        {
            Log.WriteFileInfo(FileInf);
        }

        public bool IsExistOtherSymbols()
        {
            ReadFile();
            var listText = StringExtensional.RemoveNewlines(StringWithMultipleSpaces);
            //string infoAboutSymbols = CustomConfig.FileFormatStringInfo.StringFormatInfo;
            string pattern = "[А-Яа-яЁё]+";
            if (Regex.IsMatch(StringWithMultipleSpaces, pattern))
            {
                for (int i = 0; i < listText.Count; i++)
                {
                    foreach (Match match in Regex.Matches(listText[i], pattern))
                    {
                        string infoAboutSymbols = String.Format(CustomConfig.FileFormatStringSubstringInfo.StringFormatInfo, i + 1, match.Index, match.Value);
                        var strToChange = ReplaceSymbols(match.Value);
                        listText[i] = listText[i].Replace(match.Value, strToChange);
                        if (isReplaceable)
                        {
                            Log.WriteSymbolsInfo(infoAboutSymbols + " - the value can be replaced");
                        }
                        else { Log.WriteSymbolsInfo(infoAboutSymbols); }
                    }
                }
            }
            Log.WriteScanResult(countSymbolsIsReplaced, countSymbolsNotReplaced);

            if (countSymbolsIsReplaced > 0)
            {
                listChangeText = listText;
                if (EnableCopyFile)
                    CopyFile();
                if (EnableSaveFile)
                    SaveChanges();
                return true;
            }
            return false;
        }

        private string ReplaceSymbols(string strToReplace)
        {
            Translit symbolsDictionary = new Translit();

            StringBuilder replaceString = new StringBuilder();
            foreach (var symbol in strToReplace)
            {
                var value = "";

                if (symbolsDictionary.russianToEnglishsymbols.TryGetValue(symbol.ToString(), out value))
                {
                    countSymbolsIsReplaced++;
                    replaceString.Append(value);
                    isReplaceable = true;
                }
                else
                {
                    countSymbolsNotReplaced++;
                    replaceString.Append(symbol);
                    isReplaceable = false;
                }
            }

            return replaceString.ToString();
        }

        private void CopyFile()
        {
            File.Copy(ScanFilePath, Path.Combine(BackupPath, FileInf.Name));
        }

        public void SaveChanges()
        {
            using (StreamWriter sw = new StreamWriter(ScanFilePath, false, Encoding.Default))
            {
                var result = String.Join(Environment.NewLine,
                         listChangeText.Select(a => String.Join(", ", a)));
                sw.Write(result);
            }
        }

        private string ReadFile()
        {
            using (StreamReader streamReader = new StreamReader(ScanFilePath, Encoding.Default))
            {
                StringWithMultipleSpaces = streamReader.ReadToEnd();
            };
            return StringWithMultipleSpaces;
        }
    }
}
