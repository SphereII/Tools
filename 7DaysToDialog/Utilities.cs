using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace _7DaysToDialog
{
    public static class Utilities
    {
        public static XmlDocument doc = new XmlDocument();

        static public Statement GenerateStatement(XmlNode node)
        {
            Statement statement = new Statement();
            if(node == null)
                return null;

            statement.ID = Configure(node, "id");
            statement.Text = Configure(node, "text");
            statement.NextStatement = Configure(node, "nextstatement");

            foreach(XmlNode child in node)
            {
                if(child.Name.Contains("quest_entry"))
                    continue;
                if (child.Name.Contains("#comment"))
                    continue;
                String strResponse_ID = child.Attributes["id"].Value;
                String strXPath = String.Format("/dialogs/dialog[@id='{0}']/response[@id='{1}']", node.ParentNode.Attributes["id"].Value, strResponse_ID);
                foreach(XmlNode responseNode in doc.SelectNodes(strXPath))
                {
                    Response response = new Response();
                    response.ID = Configure(responseNode, "id");
                    response.Text = Configure(responseNode, "text");
                    response.NextStatement = Configure(responseNode, "nextstatement");

                    String requirementXPath = String.Format(strXPath + "/requirement");
                    foreach(XmlNode requirement in doc.SelectNodes(requirementXPath))
                    {
                        String strRequirement_key = Configure(requirement, "id");
                        Requirement require = new Requirement();
                        require.Type = Configure(requirement, "type");
                        require.Value = Configure(requirement, "value");
                        require.requirementType = Configure(requirement, "requirementtype");
                        require.Operator = Configure(requirement, "operator");
                        response.AddRequirement(strRequirement_key, require);
                    }
                    statement.AddResponse(strResponse_ID, response);
                }
            }

            return statement;
        }
        static public String Configure(XmlNode node, String key)
        {
            String result = "";
            if(node.Attributes[key] != null)
                result = node.Attributes[key].Value;

            return result;

        }

    }
}
