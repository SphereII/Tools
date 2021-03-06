﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7DaysToDialog
{
    [Serializable]
    public class Action
    {
        public String Hash;
        public String ActionType;
        public String ID;
        public String Value;

        public String Operator;

        // Used when moving and copying around an action.
        public Action()
        {
        }

        // Generate a Hash when the information is all passed in, indicating its a new one.
        public Action(String strType, String strID, String strvalue, String strOperator)
        {
            ActionType = strType;
            ID = strID;
            Hash = "Action_" + Utilities.RandomString().GetHashCode();
            Value = strvalue;
            Operator = strOperator;
        }

        // Used to display in the TreeNodes
        public override string ToString()
        {
            String strDisplay = "Action: " + ActionType + ": " + ID;
            if (String.IsNullOrEmpty(Value))
                return strDisplay;
            return strDisplay + " when " + Operator + " " + Value + " )";
        }
    }
}
