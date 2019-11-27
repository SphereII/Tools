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
    public partial class frmAction : Form
    {
        public Action action = new Action();

        public frmAction()
        {
            InitializeComponent();

            this.cboActions.Items.Clear();

            // An action is a drop down value and description.
            ActionItem item = new ActionItem("Trader", "Trader Options:", "Valid Options: restock, trader, reset_quests" );
            this.cboActions.Items.Add(item);
            item = new ActionItem("AddJournalEntry", "Journal ID:", "This should match a Localization entry for a journal tip.");
            this.cboActions.Items.Add(item);
            item = new ActionItem("AddItem", "Item Name:" );
            this.cboActions.Items.Add(item);
            item = new ActionItem("AddBuff", "Buff Name:");
            this.cboActions.Items.Add(item);
            item = new ActionItem("AddQuest", "Quest Name:");
            this.cboActions.Items.Add(item);
            item = new ActionItem("CompleteQuest", "Quest Name:");
            this.cboActions.Items.Add(item);
            item = new ActionItem("Voice", "SoundDataNode:");
            this.cboActions.Items.Add(item);

            // Extensions enabled.
            if((bool)Properties.Settings.Default["Extensions"])
            {
                item = new ActionItem("OpenDialogSDX, Mods", "", "Opens the HireInformation Dialog window.");
                this.cboActions.Items.Add(item);

                item = new ActionItem("ShowToolTipSDX, Mods", "Tool Tip:", "Displays a Tool tip to the player.");
                this.cboActions.Items.Add(item);

                item = new ActionItem("ExecuteCommandSDX, Mods", "NPC Command:", "Valid Options:  TellMe, Showaffection, FollowMe, StayHere, GuardHere, Wander, SetPatrol, Patrol, Hire, OpenInventory, Loot, Dismiss");
                this.cboActions.Items.Add(item);

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            ActionItem item = this.cboActions.SelectedItem as ActionItem;
            if(item != null)
            {
                action.ActionType = item.Text;
                if (this.txtID.Visible)
                    action.ID = this.txtID.Text;
                else
                    action.ID = "";

                if (String.IsNullOrEmpty(action.Hash))
                    action.Hash = "Action_" + Utilities.RandomString(8).GetHashCode();
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        public void SetAction(Action action)
        {
            this.cboActions.SelectedIndex = this.cboActions.FindStringExact(action.ActionType);
            this.txtID.Text = action.ID;
            this.action.Hash = action.Hash;
            this.txtID.Visible = true;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboActions_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(this.cboActions.SelectedItem == null)
                return;

            ActionItem item = this.cboActions.SelectedItem as ActionItem;
            if(item != null)
            {
                this.rtHelp.Text = item.ToolTip;
                if(string.IsNullOrEmpty(item.Value))
                {
                    this.lblText.Visible = false;
                    this.txtID.Visible = false;
                }
                else
                {

                    this.lblText.Visible = true;
                    this.txtID.Visible = true;
                    this.lblText.Text = item.Value;
                  
                }
            }

        }
    }

    public class ActionItem
    {
        public ActionItem(String strText, String strValue, String strToolTip = "")
        {
            Text = strText;
            Value = strValue;
            ToolTip = strToolTip;
        }

        public string ToolTip
        {
            get; set;
        }
        public string Text
        {
            get; set;
        }
        public String Value
        {
            get; set;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
