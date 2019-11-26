using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace _7DaysToDialog
{
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

        public void AddAction(Action myAction)
        {
 
            Actions.Add(myAction);
        }

        public XmlNode GenerateXMLNode(XmlDocument doc)
        {
            XmlNode responseNode = doc.CreateElement("response");
            responseNode.Attributes.Append(Utilities.GenerateAttribute("id", ID, doc));
            responseNode.Attributes.Append(Utilities.GenerateAttribute("text", Text, doc));
            responseNode.Attributes.Append(Utilities.GenerateAttribute("nextstatementid", NextStatement, doc));

            foreach(Requirement require in Requirements)
            {
                XmlNode requireNode = doc.CreateElement("requirement");
                requireNode.Attributes.Append(Utilities.GenerateAttribute("type", require.Type, doc));
                requireNode.Attributes.Append(Utilities.GenerateAttribute("value", require.Value, doc));
                requireNode.Attributes.Append(Utilities.GenerateAttribute("requirementType", require.requirementType, doc));
                requireNode.Attributes.Append(Utilities.GenerateAttribute("operator", require.Operator, doc));
                requireNode.Attributes.Append(Utilities.GenerateAttribute("id", require.ID, doc));
                requireNode.Attributes.Append(Utilities.GenerateAttribute("Hash", require.Hash, doc));
                responseNode.AppendChild(requireNode);
            }

            foreach(Action action in Actions)
            {
                XmlNode actionNode = doc.CreateElement("action");
                actionNode.Attributes.Append(Utilities.GenerateAttribute("type", action.ActionType, doc));
                actionNode.Attributes.Append(Utilities.GenerateAttribute("id", action.ID, doc));
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
