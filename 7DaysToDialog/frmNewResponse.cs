using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _7DaysToDialog
{
    public partial class frmNewResponse : Form
    {
        public List<String> VisibilityTypes = new List<string>();
        public List<String> RequirementTypes = new List<string>();
        public List<String> Operators = new List<string>();


        public frmNewResponse()
        {
            InitializeComponent();
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

            Operators.Add("GTE");
            Operators.Add("GT");
            Operators.Add("LTE");
            Operators.Add("LT");
            Operators.Add("EQ");

            this.cboOperator.Items.Add(Operators.ToArray());
            this.cboRequirement.Items.AddRange(RequirementTypes.ToArray());
            this.cboVisibility.Items.AddRange(VisibilityTypes.ToArray());
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
