using System;
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
        public Dictionary<String, QuestEntry> QuestEntries = new Dictionary<string, QuestEntry>();

        public Statement()
        {

        }

        public XmlNode GenerateXMLNode( XmlDocument doc)
        {
            XmlAttribute value;

            XmlNode statementNode = doc.CreateElement("statement");
            statementNode.Attributes.Append(Utilities.GenerateAttribute("id", ID, doc));
            statementNode.Attributes.Append(Utilities.GenerateAttribute("text", Text, doc));
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
            foreach(KeyValuePair<string, QuestEntry> QuestEntry in QuestEntries)
            {
                XmlNode questNode = doc.CreateElement("quest_entry");
                questNode.Attributes.Append(Utilities.GenerateAttribute("type",QuestEntry.Value.QuestType, doc));
                questNode.Attributes.Append(Utilities.GenerateAttribute("id", QuestEntry.Value.ListIndex, doc));
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

   

        public void AddQuest(String id, QuestEntry quest )
        {
            if (QuestEntries.ContainsKey(id))
                return;
            QuestEntries.Add(id, quest);
        }
    }
}
