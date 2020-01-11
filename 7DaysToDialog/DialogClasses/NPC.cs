using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _7DaysToDialog
{
    [Serializable]
    public class NPC 
    {
        public String Name;
        public Dictionary<string, Statement> Statements = new Dictionary<string, Statement>();
        public Dictionary<string, Response> Responses = new Dictionary<string, Response>();
        
        // Creating a new NPC
        public NPC(String strName )
        {
            this.Name = strName;
        }

        public static T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }

        //public NPC Clone( String strName)
        //{
        //    NPC newNPC = new NPC(strName);

        //    // Check if the response already exists, and if so, update it.
        //    foreach (KeyValuePair<string, Response> temp in Responses)
        //    {
        //        Response tempResponse = new Response(temp.Value.ID, temp.Value.Text, temp.Value.NextStatement));
        //        newNPC.AddResponse(tempResponse);
                   
        //    }

        //    foreach (KeyValuePair<string, Statement> temp in Statements)
        //        newNPC.AddStatement(new Statement(temp.Value.ID, temp.Value.Text, temp.Value.NextStatement));

        //    return newNPC;
        //}

        // Used when initializing a NPC from an XML file
        public NPC(XmlNode node)
        {
            this.Name = ReadAttribute(node, "id");
            PopulateResponses(node);
            PopulateStatements(node);
        }

        // Safely read in an attribute from the XML file, returns nothing if no attribute and value.
        public string ReadAttribute(XmlNode node, String strAttribute)
        {
            if (node == null || node.Attributes == null)
                return "";
            if (node.Attributes[strAttribute] == null)
                return "";
            return node.Attributes[strAttribute].Value;
        }

        // Add or update an existing response.
        public void AddResponse(Response response)
        {
            // Check if the response already exists, and if so, update it.
            foreach(KeyValuePair<string, Response> temp in Responses)
            {
                if(temp.Value.ID == response.ID)
                {
                    temp.Value.NextStatement = response.NextStatement;
                    temp.Value.Text = response.Text;
                    temp.Value.Requirements = response.Requirements;
                    temp.Value.Actions = response.Actions;
                    return;
                }
            }
            Responses.Add(response.ID, response);
        }

        // Add or update an existing statement.
        public void AddStatement(Statement statement)
        {
            foreach(KeyValuePair<string, Statement> temp in Statements)
            {
                if(temp.Value.ID == statement.ID)
                {
                    temp.Value.NextStatement = statement.NextStatement;
                    temp.Value.Text = statement.Text;
                    temp.Value.Responses = statement.Responses;
                    temp.Value.PreviousStatement = statement.PreviousStatement;
                    temp.Value.QuestEntries = statement.QuestEntries;
                    return;
                }
            }
            Statements.Add(statement.ID, statement);
        }

        // reads an imported XML's node and populates the NPC
        public void PopulateStatements(XmlNode node)
        {
            String strID;
            String strText;
            String strNext;
            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.Name.Contains("statement"))
                {
                    strID = ReadAttribute(child, "id");
                    strText = ReadAttribute(child, "text");
                    strNext = ReadAttribute(child, "nextstatementid");
                    Statement statement = new Statement(strID, strText, strNext);
                    foreach (XmlNode responseEntry in child.ChildNodes)
                    {
                        foreach (KeyValuePair<string, Response> response in Responses)
                        {
                            if ( response.Key == ReadAttribute( responseEntry, "id"))
                                statement.AddResponse(ReadAttribute(responseEntry, "id"), response.Value);
                        }

                        if (responseEntry.Name.Contains("quest_entry"))
                        {
                            String strType = ReadAttribute(responseEntry, "type");
                            String listindex = ReadAttribute(responseEntry, "listindex");
                            if (string.IsNullOrEmpty(listindex))
                                listindex = "1";
                            statement.AddQuest(listindex, strType);

                        }

                    }
                    Statements.Add(strID, statement);
                }
            }
        }

        // Reads an imported NPC and populates its responses.
        public void PopulateResponses(XmlNode node)
        {
            String strID;
            String strText;
            String strNext;
            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.Name.Contains("response"))
                {
                    strID = ReadAttribute(child, "id");
                    if (string.IsNullOrEmpty(strID))
                        strID = "response_" + Utilities.RandomString().GetHashCode();
                    strText = ReadAttribute(child, "text");
                    strNext = ReadAttribute(child, "nextstatementid");
                    Response response = new Response(strID, strText, strNext);
                    foreach (XmlNode subNode in child.ChildNodes)
                    {
                        if (subNode.Name.Contains("requirement"))
                        {
                            String strType = ReadAttribute(subNode, "type");
                            String strValue = ReadAttribute(subNode, "value");
                            String strRequirementType = ReadAttribute(subNode, "requirementtype");
                            String strRequireID = ReadAttribute(subNode, "id");

                            String strOperator = ReadAttribute(subNode, "operator");
                            Requirement require = new Requirement(strType, strValue, strRequireID, strRequirementType, strOperator);
                            response.AddRequirement(require);
                        }

                        if (subNode.Name.Contains("action"))
                        {
                            String strType = ReadAttribute(subNode, "type");
                            String strActionID = ReadAttribute(subNode, "id");
                            String strValue = ReadAttribute(subNode, "value");
                            String strOperator = ReadAttribute(subNode, "operator");
                            Action newAction = new Action(strType, strActionID, strValue, strOperator);
                            response.AddAction(newAction);
                        }
                    }
                    Responses.Add(strID, response);
                }
            }
        }
    }
}
