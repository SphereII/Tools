﻿using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7DaysToDialog
{
    public static class Utilities
    {
        public static Dictionary<string, string> Localization = new Dictionary<string, string>();
        public static Dictionary<string, string> LocalizationQuest = new Dictionary<string, string>();

     
        static public String GetLocalization(String strText)
        {
            if (Localization.ContainsKey(strText))
                return Localization[strText];
            if (LocalizationQuest.ContainsKey(strText))
                return LocalizationQuest[strText];
            return strText;
        }
        public static void InitLocalization(String strPath)
        {
            if (File.Exists(Path.Combine(strPath, "Localization - Quest.txt")))
                LocalizationQuest = LoadCsv(Path.Combine(strPath, "Localization - Quest.txt"));

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
                if (!Temp.ContainsKey(fields[0].ToString()))
                    Temp.Add(fields[0], fields[4]);
            }

            parser.Close();

            return Temp;
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


    public class RequirementIem
    {
        public struct RequirementType
        {
            public String Text;
            public bool hasOperator;
            public bool hasValue;
            public bool hasID;
        }

        public RequirementIem()
        {
        }
        public RequirementIem(String strText, bool hasOperator, bool hasValue, bool hasID )
        {
            Text = strText;
            RequirementType Value = new RequirementType();
            Value.Text = Text;
            Value.hasID = hasID;
            Value.hasOperator = hasOperator;
            Value.hasValue = hasValue;

        }
        public string Text
        {
            get; set;
        }
        public RequirementType Value
        {
            get; set;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
