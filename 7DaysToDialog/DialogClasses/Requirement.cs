﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _7DaysToDialog
{
    public class Requirement
    {

        public String Type;
        public String Value;
        public String requirementType;
        public String Operator;

        public void InitLists()
        {
  

        }

        public Requirement()
        {

        }
        public Requirement(String strType, String strValue, String strRequirementType = "Hide", String strOperator = "")
        {
            Type = strType;
            Value = strValue;
            requirementType = strRequirementType;
            Operator = strOperator;
            InitLists();
        }
    }

    
}