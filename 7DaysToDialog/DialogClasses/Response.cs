using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _7DaysToDialog
{
    public class Response
    {
        public String ID;
        public String Text;
        public String NextStatement;
        public Dictionary<String, Requirement> Requirements = new Dictionary<string, Requirement>();

        public Response(String strID, String strText, String strNext)
        {
            ID = strID;
            Text = strText;
            NextStatement = strNext;
        }

        public void AddRequirement(String requirement_key, Requirement requirement)
        {
            if(Requirements.ContainsKey(requirement_key))
                return;
            Requirements.Add(requirement_key, requirement);
        }
        public Response()
        {
        }

    }
}
