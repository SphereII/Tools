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
            if (Actions.Contains(myAction))
                return;
            Actions.Add(myAction);
        }

        public void AddRequirement(Requirement requirement)
        {
            if(Requirements.Contains(requirement))
                return;
            Requirements.Add(requirement);
        }
        public Response()
        {
        }

    }
}
