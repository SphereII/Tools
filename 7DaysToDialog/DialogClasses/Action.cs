using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7DaysToDialog
{
    public class Action
    {
        public String Hash;
        public String ActionType;
        public String ID;
        
        public Action(String strType, String strID)
        {
            ActionType = strType;
            ID = strID;
        }

        public override string ToString()
        {
            return "Action: " + ActionType + ": " + ID;
        }
    }
}
