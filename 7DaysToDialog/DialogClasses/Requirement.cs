using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _7DaysToDialog
{
    [Serializable]
    public class Requirement
    {
        public String ID;
        public String Type;
        public String Value;
        public String requirementType;
        public String Operator;
        public String Hash;

        public Requirement()
        {

        }

        public Requirement(String strType, String strValue, String strID, String strRequirementType = "Hide",  String strOperator = "")
        {
            Type = strType;
            Value = strValue;
            ID = strID;
            requirementType = strRequirementType;
            Operator = strOperator;
            Hash = "Requirement_" + ToString().GetHashCode();
        }

        
        public override string ToString()
        {
            String strDisplay = Type + " : " + requirementType + " if not " + ID  ;
            if (!String.IsNullOrEmpty(Operator))
                strDisplay += " is " + Operator;
            if (!String.IsNullOrEmpty(Value))
                strDisplay += " " + Value;
            return strDisplay;
        }
    }

    
}
