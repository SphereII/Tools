using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace _7DaysToDialog
{
    [Serializable]
    public class Response
    {
        public String ID;
        public String Text;
        public String NextStatement;
        public List<Requirement> Requirements = new List<Requirement>();
        public List<Action> Actions = new List<Action>();

        public Response(String strID, String strText, String strNext)
        {
            ID = strID;
            Text = strText;
            NextStatement = strNext;
        }

        public override String ToString()
        {
            return this.ID + " : " + this.Text;
        }

        public void AddAction(Action action)
        {
            foreach (Action temp in Actions)
            {
                if (temp.Hash == action.Hash)
                {
                    temp.ID = action.ID;
                    temp.ActionType = action.ActionType;
                    temp.Value = action.Value;
                    temp.Operator = action.Operator;
                    return;
                }
            }
            Actions.Add(action);
        }

        public XmlNode GenerateXMLNode(XmlDocument doc)
        {
            XmlAttribute value;
            XmlNode responseNode = doc.CreateElement("response");
            responseNode.Attributes.Append(Utilities.GenerateAttribute("id", ID, doc));

            // Start to Generate Localization text file
            Utilities.AddToLocalization(ID, Text);
            responseNode.Attributes.Append(Utilities.GenerateAttribute("text", ID, doc));
//            responseNode.Attributes.Append(Utilities.GenerateAttribute("text", Text, doc));

             value = Utilities.GenerateAttribute("nextstatementid", NextStatement, doc);
            if (value != null)
                responseNode.Attributes.Append(value);
            
            foreach(Requirement require in Requirements)
            {
                XmlNode requireNode = doc.CreateElement("requirement");
                value = Utilities.GenerateAttribute("type", require.Type, doc);
                if (value != null)
                    requireNode.Attributes.Append(value);
                value = Utilities.GenerateAttribute("value", require.Value, doc);
                if (require.Type == "HasBuffSDX, Mods")
                {
                    if (value != null)
                        value = Utilities.GenerateAttribute("match", require.Value, doc);
                }
                if (value != null)
                    requireNode.Attributes.Append(value);
                value = Utilities.GenerateAttribute("requirementtype", require.requirementType, doc);
                if (value != null)
                    requireNode.Attributes.Append(value);
                value = Utilities.GenerateAttribute("operator", require.Operator, doc);
                if (value != null)
                    requireNode.Attributes.Append(value);
                value = Utilities.GenerateAttribute("id", require.ID, doc);
                if (value != null)
                    requireNode.Attributes.Append(value);
                value = Utilities.GenerateAttribute("Hash", require.Hash, doc);
                if (value != null)
                    requireNode.Attributes.Append(value);

                responseNode.AppendChild(requireNode);
            }

            foreach(Action action in Actions)
            {
                XmlNode actionNode = doc.CreateElement("action");
                if (action.ActionType != null)
                {
                    value = Utilities.GenerateAttribute("type", action.ActionType, doc);
                    if (value != null)
                        actionNode.Attributes.Append(value);
                }
                if (action.ID != null)
                {
                    value = Utilities.GenerateAttribute("id", action.ID, doc);
                    if (value != null)
                        actionNode.Attributes.Append(value);
                }
                if (action.Value != null)
                {
                    value = Utilities.GenerateAttribute("value", action.Value.ToString(), doc);
                    if (value != null)
                        actionNode.Attributes.Append(value);
                }
                if (action.Operator != null)
                {
                    value = Utilities.GenerateAttribute("operator", action.Operator.ToString(), doc);
                    if (value != null)
                        actionNode.Attributes.Append(value);
                }
                responseNode.AppendChild(actionNode);
            }

            return responseNode;
        }
        public void AddRequirement(Requirement requirement)
        {
            foreach (Requirement temp in Requirements)
            {
                if (temp.Hash == requirement.Hash)
                {
                    temp.ID = requirement.ID;
                    temp.Operator = requirement.Operator;
                    temp.requirementType = requirement.requirementType;
                    temp.Type = requirement.Type;
                    temp.Value = requirement.Value;
                    return;
                }
            }
            Requirements.Add(requirement);
        }
        public Response()
        {
        }

    }
}
