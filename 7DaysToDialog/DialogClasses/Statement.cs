﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace _7DaysToDialog
{
    [Serializable]
    public class Statement
    {
        public String ID;
        public String Text;
        public String NextStatement = "";
        public String PreviousStatement ="";
        public Dictionary<String, Response> Responses = new Dictionary<string, Response>();
        public Dictionary<String, String> QuestEntries = new Dictionary<string, String>();

        public Statement()
        {

        }

        public XmlNode GenerateXMLNode( XmlDocument doc)
        {
            XmlAttribute value;

            XmlNode statementNode = doc.CreateElement("statement");
            statementNode.Attributes.Append(Utilities.GenerateAttribute("id", ID, doc));

            // Start to Generate Localization text file
            Utilities.AddToLocalization(ID, Text);
            statementNode.Attributes.Append(Utilities.GenerateAttribute("text", ID, doc));

            //statementNode.Attributes.Append(Utilities.GenerateAttribute("text", Text, doc));
            value = Utilities.GenerateAttribute("nextstatementid", NextStatement, doc);
            if (value != null)
                statementNode.Attributes.Append(value);
          //  statementNode.Attributes.Append(Utilities.GenerateAttribute("previousstatement", PreviousStatement, doc));

            
            foreach(KeyValuePair<string, Response> response in Responses)
            {
                XmlNode responseNode = doc.CreateElement("response_entry");
                responseNode.Attributes.Append(Utilities.GenerateAttribute("id", response.Key, doc));
                responseNode.Attributes.Append(Utilities.GenerateAttribute("ref_text", response.Value.Text, doc));
                statementNode.AppendChild(responseNode);
            }
            foreach(KeyValuePair<string, String> QuestEntry in QuestEntries)
            {
                XmlNode questNode = doc.CreateElement("quest_entry");
                questNode.Attributes.Append(Utilities.GenerateAttribute("type",QuestEntry.Value, doc));
                questNode.Attributes.Append(Utilities.GenerateAttribute("id", QuestEntry.Key, doc));
                statementNode.AppendChild(questNode);
            }

            return statementNode;
        }

        public Statement(String strID, string strText, string strNextStatement, string strPrevious = "")
        {
            ID = strID;
            Text = strText;
            NextStatement = strNextStatement;
            PreviousStatement = strPrevious;
        }

        public void AddResponse(Response response)
        {
            AddResponse(response.ID, response);
        }

        public void AddResponse(String response_entry, Response response = null)
        {
            foreach(KeyValuePair<string, Response> temp in Responses)
            {
                if(temp.Value.ID == response.ID)
                {
                    temp.Value.NextStatement = response.NextStatement;
                    temp.Value.Text = response.Text;
                    return;
                }
            }

            Responses.Add(response.ID, response);
        }

   
        

        public void AddQuest(String listIndex, String type )
        {
            if (QuestEntries.ContainsKey(listIndex))
                return;
            QuestEntries.Add(listIndex, type);
        }
    }
}
