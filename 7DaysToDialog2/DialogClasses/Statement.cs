using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace _7DaysToDialog
{

    public class Statement
    {
        public String ID;
        public String Text;
        public String NextStatement;
        public String PreviousStatement;
        public Dictionary<String, Response> Responses = new Dictionary<string, Response>();
        public Dictionary<String, QuestEntry> QuestEntries = new Dictionary<string, QuestEntry>();

        public Statement()
        {

        }
        public Statement(String strID, string strText, string strNextStatement, string strPrevious = "")
        {
            ID = strID;
            Text = strText;
            NextStatement = strNextStatement;
            PreviousStatement = strPrevious;
        }

        public void AddResponse(String response_entry, Response response = null)
        {
            if (Responses.ContainsKey(response_entry))
                return;
            Responses.Add(response_entry, response);
        }

        public void AddQuest(String id, QuestEntry quest )
        {
            if (QuestEntries.ContainsKey(id))
                return;
            QuestEntries.Add(id, quest);
        }
    }
}
