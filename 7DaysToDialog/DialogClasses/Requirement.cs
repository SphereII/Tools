using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _7DaysToDialog
{
    public class Requirement
    {
        public List<String> VisibilityTypes = new List<string>();
        public List<String> RequirementTypes = new List<string>();
        public String Type;
        public String Value;
        public String requirementType;
        public String Operator;

        public void InitLists()
        {
            VisibilityTypes.Add("Hide");
            VisibilityTypes.Add("AlternateText");

            RequirementTypes.Add("Buff");
            RequirementTypes.Add("QuestStatus");
            RequirementTypes.Add("Skill");
            RequirementTypes.Add("Admin");

            // 0-SphereIICore
            RequirementTypes.Add("HasCVarSDX, Mods");
            RequirementTypes.Add("HasBuffSDX, Mods");
            RequirementTypes.Add("HasItemSDX, Mods");
            RequirementTypes.Add("HasQuestSDX, Mods");
            RequirementTypes.Add("HasBuffSDX, Mods");

            // For NPC's that are hired.
            RequirementTypes.Add("Hired, Mods");
            RequirementTypes.Add("PatrolSDX, Mods");

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
