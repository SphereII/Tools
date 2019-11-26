using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7DaysToDialog
{
    public partial class frmRequirement : Form
    {
        public List<String> VisibilityTypes = new List<string>();
        public List<RequirementItem> RequirementTypes = new List<RequirementItem>();
        public List<String> Operators = new List<string>();

        public Requirement requirement = new Requirement();
        public frmRequirement()
        {
            InitializeComponent();

            VisibilityTypes.Clear();
            VisibilityTypes.Add("Hide");
            VisibilityTypes.Add("AlternateText");

            Operators.Clear();
            Operators.Add("None");
            Operators.Add("GTE");
            Operators.Add("GT");
            Operators.Add("LTE");
            Operators.Add("LT");
            Operators.Add("EQ");

            RequirementTypes.Clear();
            RequirementTypes.Add(new RequirementItem("None"));
            RequirementTypes.Add(new RequirementItem("Buff"));
            RequirementTypes.Add(new RequirementItem("QuestStatus"));
            RequirementTypes.Add(new RequirementItem("Skill"));
            RequirementTypes.Add(new RequirementItem("Admin"));

            // Extensions enabled.
            if ((bool)Properties.Settings.Default["Extensions"])
            {
                RequirementItem item = new RequirementItem("HasCVarSDX, Mods", "Condition to determine the cvar value to the supplied value", "The value for this cvar to pass the check", "The cvar name");
                item.Value.strLabelValue = "Cvar Value:";
                item.Value.strLabelID = "Cvar Name:";
                item.Value.strExample = @"<requirement type='HasCVarSDX, Mods' requirementtype='Hide' id='cursesamaramorgan' operator='gte' value='1' />";
                RequirementTypes.Add( item);

                item = new RequirementItem("HasBuffSDX, Mods", "", "The buff name. This can include more than one buff, seperated by a comma. Requirement is true if any of them are found on the player.", "");
                item.Value.strLabelValue = "Buff(s):";
                item.Value.strLabelID = "";
                RequirementTypes.Add(item);

                item = new RequirementItem("HasItemSDX, Mods", "", "How many of the item does the player need to have? Defaults to 1.", "The name of the item to require the player to have.");
                item.Value.strLabelID = "ItemName:";
                item.Value.strLabelValue = "Count:";
                RequirementTypes.Add(item);

                item = new RequirementItem("HasQuestSDX, Mods", "","","");
                item.Value.strLabelID = "";
                item.Value.strLabelValue = "";
                RequirementTypes.Add(item);

                item = new RequirementItem("HasTaskSDX, Mods", "", "NPC Only: Check if the NPC has a particular AI Task.", "");
                item.Value.strLabelValue = "AI Task:";
                item.Value.strLabelID = "";
                RequirementTypes.Add(item);

                // For NPC's that are hired.
                item = new RequirementItem("Hired, Mods", "", "Optional: Set to not to show the response if the NPC is not hired.", "");
                item.Value.strLabelValue = "Set to Not to reverse condition:";
                item.Value.strLabelID = "";
                RequirementTypes.Add(item);

                item = new RequirementItem("PatrolSDX, Mods", "", "Optional: Set to not to show the response if hte NPC is not hired.", "");
                item.Value.strLabelValue = "AI Task:";
                item.Value.strLabelID = "";
                RequirementTypes.Add(item);

            }

            this.cboRequirements.Items.AddRange(RequirementTypes.ToArray());
            this.cboVisibility.Items.AddRange(VisibilityTypes.ToArray());
            this.cboOperators.Items.AddRange(Operators.ToArray());
            this.cboRequirements.SelectedIndex = 0;
            this.cboVisibility.SelectedIndex = 0;
            this.cboOperators.SelectedIndex = 0;
        }

        public void SetRequirement(Requirement req)
        {
                this.cboVisibility.SelectedIndex = this.cboVisibility.FindStringExact(req.requirementType);
                this.cboRequirements.SelectedIndex = this.cboRequirements.FindStringExact(req.Type);

                if (!String.IsNullOrEmpty(req.Operator))
                    this.cboOperators.SelectedIndex = this.cboOperators.FindStringExact(req.Operator);

                if (!String.IsNullOrEmpty(req.Value))
                    this.txtValue.Text = req.Value;

                if (!String.IsNullOrEmpty(req.ID))
                    this.txtID.Text = req.ID;

            requirement.Hash = req.Hash;
        }
        private void cboRequirements_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            requirement.requirementType = this.cboVisibility.SelectedItem.ToString();
            if (this.cboOperators.SelectedItem.ToString() != "None")
                requirement.Operator = this.cboOperators.SelectedItem.ToString();
            requirement.Type = this.cboRequirements.SelectedItem.ToString();
            if (!String.IsNullOrEmpty(this.txtValue.Text))
                requirement.Value = this.txtValue.Text;

            if (!String.IsNullOrEmpty(this.txtID.Text))
                requirement.ID = this.txtID.Text;

            if ( String.IsNullOrEmpty( requirement.Hash))
                requirement.Hash =  "Requirement_" + requirement.ToString().GetHashCode();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cboRequirements_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cboRequirements.SelectedItem == null)
                return;

            this.txtValue.Text = "";
            this.txtID.Text = "";

            RequirementItem item = this.cboRequirements.SelectedItem as RequirementItem;
            if (item == null)
                return;

            this.txtValue.Visible = !String.IsNullOrEmpty(item.Value.hasValue);
            this.cboOperators.Visible = !String.IsNullOrEmpty(item.Value.hasOperator);
            this.txtID.Visible = !String.IsNullOrEmpty(item.Value.hasID);

            this.lblID.Text = item.Value.strLabelID;
            this.lblID.Visible = this.txtID.Visible;
            this.lblValue.Text = item.Value.strLabelValue;
            this.lblValue.Visible = this.txtValue.Visible;

            this.lblOperator.Visible = this.cboOperators.Visible;
        }
    }

    public class RequirementItem
    {
        public struct RequirementType
        {
            public String Text;
            public String hasOperator;
            public String hasValue;
            public String hasID;
            public String strLabelValue;
            public String strLabelID;
            public String strExample;
        }

        public RequirementType Value = new RequirementType();

        public RequirementItem()
        {
        }

        public RequirementItem(String strText, String hasOperator = "", String hasValue = "", String hasID = "")
        {
            Text = strText;
            Value.Text = Text;
            Value.hasID = hasID;
            Value.hasOperator = hasOperator;
            Value.hasValue = hasValue;

        }
        public string Text
        {
            get; set;
        }
        public RequirementType Requirement
        {
            get
            {
                return Value;
            }
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
