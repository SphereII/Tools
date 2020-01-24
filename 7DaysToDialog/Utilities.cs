using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace _7DaysToDialog
{
    public static class Utilities
    {
        public static Dictionary<string, string> Localization = new Dictionary<string, string>();
        public static Dictionary<string, string> NewLocalization = new Dictionary<string, string>();
        public static int LanguageIndex = -1;

        private static Random random = new Random();
        public static string RandomString(int length = 16)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static bool IsInVisualStudio
        {
            get
            {

                return Debugger.IsAttached;

                //bool inIDE = false;
                //string[] args = System.Environment.GetCommandLineArgs();
                //if (args != null && args.Length > 0)
                //{
                //    string prgName = args[0].ToUpper();
                //    inIDE = prgName.EndsWith("VSHOST.EXE");
                //}
                //return inIDE;
            }
        }
        public static System.String CutStart(this System.String s, System.String what)
        {
            if (s.StartsWith(what))
                return s.Substring(what.Length);
            else
                return s;
        }
        public static XmlAttribute GenerateAttribute(String strName, String strValue, XmlDocument doc)
        {
            if (String.IsNullOrEmpty(strValue))
                return null;
            XmlAttribute attribute = doc.CreateAttribute(strName);
            attribute.Value = strValue;
            return attribute;

        }
        static public String GetLocalization(String strText)
        {
            if (Localization.ContainsKey(strText))
                return Localization[strText];
            //if (LocalizationQuest.ContainsKey(strText))
            //    return LocalizationQuest[strText];
            return strText;
        }
        public static void InitLocalization(String strPath)
        {
            if (File.Exists(strPath))
                Localization = LoadCsv(strPath);

            if (File.Exists(Path.Combine(strPath, "Localization.txt")))
                Localization = LoadCsv(Path.Combine(strPath, "Localization.txt"));
        }
        static private Dictionary<string, string> LoadCsv(String strFilename)
        {
            Dictionary<string, string> Temp = new Dictionary<string, string>();
            TextFieldParser parser = new TextFieldParser(new StreamReader(strFilename));

            parser.HasFieldsEnclosedInQuotes = true;
            parser.SetDelimiters(",");

            string[] fields;

            while (!parser.EndOfData)
            {
                fields = parser.ReadFields();

                // We need to find out which column is the english
                if (LanguageIndex == -1)
                {
                    for (int x = 0; x < fields.Length; x++)
                    {
                        if (fields[x].ToLower() == "english")
                        {
                            LanguageIndex = x;
                            break;
                        }
                    }
                }


                if (!Temp.ContainsKey(fields[0].ToString()))
                    Temp.Add(fields[0], fields[LanguageIndex]);
            }

            parser.Close();

            return Temp;
        }

        static public bool AddToLocalization(String strKey, String strEntry)
        {
            if (NewLocalization.ContainsKey(strKey))
            {
                NewLocalization[strKey] = strEntry;
                return true;
            }
            NewLocalization.Add(strKey, strEntry);
            return true;
        }

        static public void WriteLocalization(String strFile)
        {
            // No Localization loaded.
            //if (File.Exists(strFile))
            //{
            //    TextFieldParser parser = new TextFieldParser(new StreamReader(strFile));
            //    parser.HasFieldsEnclosedInQuotes = true;
            //    parser.SetDelimiters(",");

            //    string[] fields;
            //    int KeyIndex = 0;
            //    int EnglishIndex = 0;
            //    using (System.IO.StreamWriter file = new System.IO.StreamWriter(strFile + "_New"))
            //    {

            //        while (!parser.EndOfData)
            //        {
            //            String strWriteLine = "";
            //            fields = parser.ReadFields();
            //            for (int x = 0; x < fields.Length; x++)
            //            {
            //                if (strWriteLine.Length == 0)
            //                    strWriteLine += "\"" + fields[x] + "\"";
            //                else
            //                    strWriteLine += "," + "\"" + fields[x] + "\"";

            //                if (fields[x].ToLower() == "english")
            //                    EnglishIndex = x;
            //            }
            //            // Exception to skil vanilla localization
            //            if (!strWriteLine.Contains("dialog_trader_"))
            //                file.WriteLine(strWriteLine);

            //        }
            //        parser.Close();

            //        foreach (KeyValuePair<string, string> local in NewLocalization)
            //        {
            //            if (local.Value.Contains("dialog_trader_"))
            //                continue;
            //            file.WriteLine("\"" + local.Key + "\"," + "\"" + local.Value + "\"");
            //        }

            //    }
            //    if (File.Exists(strFile))
            //        File.Delete(strFile);
            //    File.Move(strFile + "_New", strFile);

            //}
            //else
            {
                String Header = "Key,English";
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(strFile))
                {
                    file.WriteLine(Header);
                    foreach (KeyValuePair<string, string> local in NewLocalization)
                    {
                        if (local.Value.Contains("dialog_trader_"))
                            continue;
                        file.WriteLine("\"" + local.Key + "\"," + "\"" + local.Value + "\"");
                    }
                }
            }
        }
        static public TreeNode FromID(string itemId, TreeNode rootNode)
        {
            foreach (TreeNode node in rootNode.Nodes)
            {
                if (node.Tag is Statement)
                    if ((node.Tag as Statement).ID == itemId)
                        return node;
                TreeNode next = FromID(itemId, node);
                if (next != null)
                    return next;
            }
            return null;
        }

    }

    public class ComboboxItem
    {
        public ComboboxItem()
        {
        }
        public ComboboxItem(String strText, object objValue)
        {
            Text = strText;
            Value = objValue;
        }
        public string Text
        {
            get; set;
        }
        public object Value
        {
            get; set;
        }

        public override string ToString()
        {
            return Text;
        }
    }



}
