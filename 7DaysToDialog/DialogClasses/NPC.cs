﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _7DaysToDialog
{
    public class NPC
    {
        public String Name;
        public Dictionary<string, Statement> Statements = new Dictionary<string, Statement>();
        public Dictionary<string, Response> Responses = new Dictionary<string, Response>();
        
        public NPC(String strName )
        {
            this.Name = strName;
        }

        public NPC(XmlNode node)
        {
            this.Name = ReadAttribute(node, "id");
            PopulateResponses(node);
            PopulateStatements(node);
        }

        public string ReadAttribute(XmlNode node, String strAttribute)
        {
            if (node == null || node.Attributes == null)
                return "";
            if (node.Attributes[strAttribute] == null)
                return "";
            return node.Attributes[strAttribute].Value;
        }

        public void AddResponse(Response response)
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
                            QuestEntry newquestEntry = new QuestEntry(strType, listindex);
                            statement.AddQuest(listindex, newquestEntry);

                        }

                    }
                    Statements.Add(strID, statement);
                }
            }
        }

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
                    strText = ReadAttribute(child, "text");
                    strNext = ReadAttribute(child, "nextstatementid");
                    Response response = new Response(strID, strText, strNext);
                    foreach (XmlNode subNode in child.ChildNodes)
                    {
                        if (subNode.Name.Contains("requirement"))
                        {
                            String strType = ReadAttribute(subNode, "type");
                            String strValue = ReadAttribute(subNode, "value");
                            String strRequirementType = ReadAttribute(subNode, "requirementType");
                            String strRequireID = ReadAttribute(subNode, "id");

                            String strOperator = ReadAttribute(subNode, "operator");
                            Requirement require = new Requirement(strType, strValue, strRequireID, strRequirementType, strOperator);
                            response.AddRequirement(require);
                        }

                        if (subNode.Name.Contains("action"))
                        {
                            String strType = ReadAttribute(subNode, "type");
                            String strActionID = ReadAttribute(subNode, "id");
                            Action newAction = new Action(strType, strActionID);
                            response.AddAction(newAction);
                        }
                    }
                    Responses.Add(strID, response);
                }
            }
        }
    }
}