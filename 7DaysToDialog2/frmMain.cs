using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace _7DaysToDialog
{
    public partial class frmMain : Form
    {
        TreeNode ClickNode = null;
        XmlDocument doc = new XmlDocument();

        public List<NPC> NPCs = new List<NPC>();

        public frmMain()
        {
            InitializeComponent();
            enabledExtensionsToolStripMenuItem.Checked = (bool)Properties.Settings.Default["Extensions"];
            this.treeDialogs.DrawMode = TreeViewDrawMode.OwnerDrawText;
        }

        private void chkResponseID_CheckedChanged(object sender, EventArgs e)
        {
            this.txtResponseID.ReadOnly = !chkResponseID.Checked;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.txtResponse.Text.Length < 1)
            {
                MessageBox.Show("Please enter in what you'd like to say to the NPC");
                this.txtResponse.Focus();
                return;
            }
            if (!this.chkResponseID.Checked)
            {
                if (this.txtResponseID.MaxLength < 1)
                {
                    MessageBox.Show("Please enter in a unique response ID, or check the Auto Response checkbox.");
                    this.txtResponseID.Focus();
                    return;
                }
            }
            else
            {
                if (this.btnAdd.Text == "Add")
                    this.txtResponseID.Text = "responseID_" + this.txtResponse.Text.GetHashCode();
            }

            Response responseClass = new Response();
            responseClass.ID = this.txtResponseID.Text.Trim();
            responseClass.Text = this.txtResponse.Text;
            UpdateNode(responseClass);

            this.txtResponse.Text = "";
            this.txtResponseID.Text = "";
            this.btnAdd.Text = "Add";

            btnSave_Click(null, null);
        }


        private void UpdateNode(Response responseClass )
        {
            TreeNode targetNode = null;

            // see if a node already exists for this response.
            foreach (TreeNode searchNode in this.treeReplies.Nodes)
            {
                Response searchClass = searchNode.Tag as Response;
                if (searchClass.ID == responseClass.ID)
                {
                    targetNode = searchNode;
                    break;
                }
            }

            // If a node doesn't exist, then create one. Remove the existing one.
            if (targetNode != null)
                this.treeReplies.Nodes.Remove(targetNode);

                targetNode = new TreeNode();

                targetNode.Text = Utilities.GetLocalization(responseClass.Text);
            targetNode.ToolTipText = responseClass.ToString();
            targetNode.Tag = responseClass;
            foreach (Requirement requirement in responseClass.Requirements)
            {
                TreeNode requirementNode = new TreeNode();
                requirementNode.Text = requirement.ToString();
                requirementNode.Tag = requirement;
                targetNode.Nodes.Add(requirementNode);
            }
            this.treeReplies.Nodes.Add(targetNode);
        }

        public void RefreshReplies()
        {
        
        }
        private void treeReplies_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point ClickPoint = new Point(e.X, e.Y);
                ClickNode = treeReplies.GetNodeAt(ClickPoint);
                if (ClickNode == null)
                    return;

                this.treeReplies.SelectedNode = ClickNode;
                GenerateContextMenu(ClickNode);
                Point ScreenPoint = treeReplies.PointToScreen(ClickPoint);
                Point FormPoint = this.PointToClient(ScreenPoint);
                ResponsesMenu.Show(this, FormPoint);
            }
            else if (e.Button == MouseButtons.Left)
            {
                Point ClickPoint = new Point(e.X, e.Y);
                ClickNode = treeReplies.GetNodeAt(ClickPoint);
                if (ClickNode == null)
                    return;

                EditResponse(null, null);
            }
        }

        public NPC GetCurrentNPC()
        {
            if (this.cmbNPCs.SelectedItem == null)
                return null;

            foreach (NPC npc in NPCs)
            {
                if (npc.Name == this.cmbNPCs.SelectedItem.ToString())
                    return npc;
            }
            return null;
        }

        private void GenerateDialogsContextMenu(TreeNode node)
        {
            DialogsContextMenu.Items.Clear();
            
            if (node.Tag is NPC)
            {
                DialogsContextMenu.Items.Insert(0, new ToolStripLabel(node.Text));
                DialogsContextMenu.Items.Add(new ToolStripSeparator());
                DialogsContextMenu.Items.Add("New Statement").Click += new EventHandler(NewStatement);
            }
            if (node.Tag is Statement)
            {
                DialogsContextMenu.Items.Insert(0, new ToolStripLabel(node.Parent.Text));
                DialogsContextMenu.Items.Add(new ToolStripSeparator());
                DialogsContextMenu.Items.Add("New Statement").Click += new EventHandler(NewStatement);
            }
        }

        private void NewStatement(object sender, EventArgs e)
        {
            if (ClickNode == null)
                return;

            if (ClickNode.Tag is NPC)
                this.cmbNPCs.SelectedIndex = this.cmbNPCs.FindStringExact(ClickNode.Text);
            else if (ClickNode.Tag is Statement)
                this.cmbNPCs.SelectedIndex = this.cmbNPCs.FindStringExact(ClickNode.Parent.Text);
            ClearForm(false);
            this.rtbStatement.Focus();

        }
        private void GenerateContextMenu(TreeNode node)
        {
            ResponsesMenu.Items.Clear();
            ResponsesMenu.Items.Insert(0, new ToolStripLabel(node.Text));
            if ( node.Tag is Response)
            {
                ResponsesMenu.Items.Insert(1, new ToolStripSeparator());
                ResponsesMenu.Items.Add("Delete Response").Click += new EventHandler(RemoveResponse);
                ResponsesMenu.Items.Add("Edit Response").Click += new EventHandler(EditResponse);
                ResponsesMenu.Items.Add(new ToolStripSeparator());
                ResponsesMenu.Items.Add("Add Requirement").Click += new EventHandler(AddRequirement);
                ResponsesMenu.Items.Add("Add Action").Click += new EventHandler(AddAction);
                ResponsesMenu.Items.Add("Add Quest Entry").Click += new EventHandler(AddQuestEntry);
            }
            if (node.Tag is Requirement) 
            {
                ResponsesMenu.Items.Add("Edit Requirement").Click += new EventHandler(EditRequirement);
                ResponsesMenu.Items.Add("Remove Requirement").Click += new EventHandler(RemoveRequirement);
            }
            if (node.Tag is Action)
            {
                ResponsesMenu.Items.Add("Edit Action").Click += new EventHandler(AddAction);
                ResponsesMenu.Items.Add("Remove Action").Click += new EventHandler(AddAction);
            }

            if (node.Tag is QuestEntry)
            {
                ResponsesMenu.Items.Add("Edit QuestEntry").Click += new EventHandler(AddQuestEntry);
                ResponsesMenu.Items.Add("Remove QuestEntry").Click += new EventHandler(AddQuestEntry);
            }

        }

        private void AddAction(object sender, EventArgs e)
        {

        }
        private void AddQuestEntry(object sender, EventArgs e)
        {

        }
        private void AddRequirement(object sender, EventArgs e)
        {
            if (ClickNode == null)
                return;

            frmRequirement frm = new frmRequirement();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                Response response = ClickNode.Tag as Response;
                foreach (Requirement require in response.Requirements)
                {
                    if (require.Hash == frm.requirement.Hash)
                        return;
                }
                response.AddRequirement(frm.requirement);
                UpdateNode(response);
                ClickNode = null;
            }

        }

        private void EditRequirement(object sender, EventArgs e)
        {
            if (ClickNode == null)
                return;

            Requirement requirement = ClickNode.Tag as Requirement;
            if (requirement == null)
                return;

            frmRequirement frm = new frmRequirement();
            frm.SetRequirement(requirement);

            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                Response response = ClickNode.Parent.Tag as Response;
                if (response == null)
                    return;


                response.AddRequirement(frm.requirement);
                UpdateNode(response);
                ClickNode = null;
            }

        }

        private void RemoveRequirement(object sender, EventArgs e)
        {
            if (ClickNode == null)
                return;

            Requirement requirement = ClickNode.Tag as Requirement;
            if (requirement == null)
                return;
            Response response = ClickNode.Parent.Tag as Response;
            if (response == null)
                return;

            response.Requirements.Remove(requirement);
            this.treeReplies.Nodes.Remove(ClickNode);
            ClickNode = null;
        }
        private void RemoveResponse(object sender, EventArgs e)
        {
            if (ClickNode == null)
                return;

            this.treeReplies.Nodes.Remove(ClickNode);
            Response response = ClickNode.Tag as Response;
            String strNPC = this.cmbNPCs.SelectedItem.ToString();
            NPC currentNPC = GetCurrentNPC();
            if ( currentNPC != null )
                currentNPC.Responses.Remove(response.ID);
                    foreach (KeyValuePair<string, Statement> keyValuePair in currentNPC.Statements)
                    {
                        keyValuePair.Value.Responses.Remove(response.ID);
                    }

            ClickNode = null;
        }

        private void EditResponse(object sender, EventArgs e)
        {
            if (ClickNode == null)
                return;

            this.btnAdd.Text = "Save";
            Response response = ClickNode.Tag as Response;
            if (response == null)
                return;
            this.txtResponse.Text = Utilities.GetLocalization(response.Text);
            this.txtResponseID.Text = response.ID;
        }

        private void treeDialogs_Click(object sender, EventArgs e)
        {
        

        }


        private void treeDialogs_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                    Point ClickPoint = new Point(e.X, e.Y);
                    ClickNode = treeDialogs.GetNodeAt(ClickPoint);
                    if (ClickNode == null)
                        return;

                    this.treeDialogs.SelectedNode = ClickNode;
                    GenerateDialogsContextMenu(ClickNode);
                    Point ScreenPoint = treeDialogs.PointToScreen(ClickPoint);
                    Point FormPoint = this.PointToClient(ScreenPoint);
                    DialogsContextMenu.Show(this, FormPoint);
            }
            if (e.Button == MouseButtons.Left)
            {
                Point ClickPoint = new Point(e.X, e.Y);
                ClickNode = treeDialogs.GetNodeAt(ClickPoint);
                if (ClickNode == null)
                    return;

                if (ClickNode.Parent == null)
                    return;

                this.treeReplies.SelectedNode = ClickNode;
                if (ClickNode.Tag is Statement)
                {
                    SetStatement(ClickNode.Tag as Statement);
                }

            }
        }

        private void SetStatement(Statement statement)
        {
            if (statement == null)
                return;

            this.grpConversation.Visible = true;
            this.rtbStatement.Text = Utilities.GetLocalization(statement.Text);
            this.treeReplies.Nodes.Clear();
            foreach (KeyValuePair<string, Response> response in statement.Responses)
                UpdateNode(response.Value);

            //  this.treeDialogs.Focus();
            this.txtResponse.Focus();
            this.txtResponse.Text = "";
            this.txtResponseID.Text = "";
        }
        private void SetStatement()
        {
            if (ClickNode == null)
                return;
            if (ClickNode.Level == 1)
            {
                foreach (NPC npc in NPCs)
                {
                    if (npc.Name == ClickNode.Parent.Text)
                    {
                        Statement statement = ClickNode.Tag as Statement;
                        SetStatement(statement);

                        // If there's no replies, then it's just an empty statement that returns back to the main statement.
                        //if (this.treeReplies.Nodes.Count == 0)
                        //{
                        //    Response temp = new Response();
                        //    temp.ID = statement.NextStatement;
                        //    temp.Text = "Next";
                        //    temp.NextStatement = statement.NextStatement;

                        //    TreeNode node = new TreeNode();
                        //    node.Text = temp.Text;
                        //    node.Tag = temp;
                        //    this.treeReplies.Nodes.Add(node);

                        //}
                    }
                }
            }
        }


        private void treeReplies_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point ClickPoint = new Point(e.X, e.Y);
                ClickNode = treeReplies.GetNodeAt(ClickPoint);
                if (ClickNode == null)
                    return;

                Response response = ClickNode.Tag as Response;
                if (response == null)
                    return;

                //Usage    
                TreeNode itemNode = null;
                foreach (TreeNode node in this.treeDialogs.Nodes)
                {
                    // Look for the next statement in the list.
                    itemNode = Utilities.FromID(response.NextStatement, node);
                    if (itemNode != null)
                        break;
                }

                if (itemNode == null)
                    return;

                ClickNode = itemNode;
                this.treeDialogs.SelectedNode = ClickNode;
                
                SetStatement();
            }
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strFile;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                String strDefaultFolder = @"C:\Program Files (x86)\Steam\steamapps\common\7 Days To Die\Data\Config";
                if (Directory.Exists(strDefaultFolder))
                    openFileDialog.InitialDirectory = strDefaultFolder;
                else
                    openFileDialog.InitialDirectory = "c:\\";

                openFileDialog.Filter = "dialogs.xml files (*.xml)|*.xml";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    strFile = openFileDialog.FileName;
                    doc.Load(strFile);
                    foreach (XmlNode dialogNode in doc.SelectNodes("//dialog"))
                        NPCs.Add(new NPC(dialogNode));

                    Utilities.InitLocalization(Path.GetDirectoryName( strFile ));
                    RebuildTreeNode();
                }
            }

        }

        private void ClearForm( bool fullClear = false)
        {
            if (fullClear)
            {
                NPCs.Clear();
                doc = new XmlDocument();
                this.treeDialogs.Nodes.Clear();
            }
            this.treeReplies.Nodes.Clear();
            this.txtResponse.Text = "";
            this.txtResponseID.Text = "";
            this.rtbStatement.Text = "";

        }
        private void closeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearForm(true);
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = "c:\\";
                saveFileDialog.Filter = "dialogs.xml files (*.xml)|*.xml";
                saveFileDialog.Title = "Save an dialogs";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    XmlDocument saveDoc = new XmlDocument();

                    XmlNode rootNode = saveDoc.CreateElement("configs");
                    saveDoc.AppendChild(rootNode);
                    saveDoc.InsertBefore(saveDoc.CreateComment("Created using the 7 Days To Dialog Application"), rootNode);
                    XmlNode append = saveDoc.CreateElement("append");
                    XmlAttribute xPath = saveDoc.CreateAttribute("xpath");
                    xPath.Value = "/dialogs";
                    append.Attributes.Append(xPath);
                    rootNode.AppendChild(append);

                    foreach (NPC npc in NPCs)
                    {
                        XmlNode npcNode = saveDoc.CreateElement("dialog");
                        XmlAttribute npcID = saveDoc.CreateAttribute("id");
                        npcID.Value = npc.Name;
                        npcNode.Attributes.Append(npcID);
                        append.AppendChild(npcNode);

                        foreach (KeyValuePair<string, Statement> statement in npc.Statements)
                        {
                            if (string.IsNullOrWhiteSpace(statement.Value.ID))
                                continue;

                            XmlNode statementNode = saveDoc.CreateElement("statement");
                            statementNode.Attributes.Append(GenerateAttribute("id", statement.Value.ID, saveDoc));
                            statementNode.Attributes.Append(GenerateAttribute("text", statement.Value.Text, saveDoc));
                            statementNode.Attributes.Append(GenerateAttribute("nextstatementid", statement.Value.NextStatement, saveDoc));
                            foreach (KeyValuePair<string, Response> response in statement.Value.Responses)
                            {
                                XmlNode responseNode = saveDoc.CreateElement("response_entry");
                                responseNode.Attributes.Append(GenerateAttribute("id", response.Value.ID, saveDoc));
                                responseNode.Attributes.Append(GenerateAttribute("ref_text", response.Value.Text, saveDoc));
                                statementNode.AppendChild(responseNode);
                            }
                            foreach (KeyValuePair<string, QuestEntry> QuestEntry in statement.Value.QuestEntries)
                            {
                                XmlNode questNode = saveDoc.CreateElement("quest_entry");
                                questNode.Attributes.Append(GenerateAttribute("type", QuestEntry.Value.QuestType, saveDoc));
                                questNode.Attributes.Append(GenerateAttribute("id", QuestEntry.Value.ListIndex, saveDoc));
                                statementNode.AppendChild(questNode);
                            }
                            npcNode.AppendChild(statementNode);
                        }

                        foreach (KeyValuePair<string, Response> response in npc.Responses)
                        {
                            XmlNode responseNode = saveDoc.CreateElement("response");
                            responseNode.Attributes.Append(GenerateAttribute("id", response.Value.ID, saveDoc));
                            responseNode.Attributes.Append(GenerateAttribute("text", response.Value.Text, saveDoc));
                            responseNode.Attributes.Append(GenerateAttribute("nextstatementid", response.Value.NextStatement, saveDoc));

                            foreach (Requirement require in response.Value.Requirements)
                            {
                                XmlNode requireNode = saveDoc.CreateElement("requirement");
                                requireNode.Attributes.Append(GenerateAttribute("type", require.Type, saveDoc));
                                requireNode.Attributes.Append(GenerateAttribute("value", require.Value, saveDoc));
                                requireNode.Attributes.Append(GenerateAttribute("requirementType", require.requirementType, saveDoc));
                                requireNode.Attributes.Append(GenerateAttribute("operator", require.Operator, saveDoc));
                                requireNode.Attributes.Append(GenerateAttribute("id", require.ID, saveDoc));
                                requireNode.Attributes.Append(GenerateAttribute("Hash", require.Hash, saveDoc));

                                responseNode.AppendChild(requireNode);

                            }

                            foreach (Action action in response.Value.Actions)
                            {
                                XmlNode actionNode = saveDoc.CreateElement("action");
                                actionNode.Attributes.Append(GenerateAttribute("type", action.ActionType, saveDoc));
                                actionNode.Attributes.Append(GenerateAttribute("id", action.ID, saveDoc));
                                responseNode.AppendChild(actionNode);

                            }
                            npcNode.AppendChild(responseNode);
                        }


                        saveDoc.Save(saveFileDialog.FileName);
                    }
                }
            }

        }

        public XmlAttribute GenerateAttribute(String strName, String strValue, XmlDocument doc)
        {
            XmlAttribute attribute = doc.CreateAttribute(strName);
            attribute.Value = strValue;
            return attribute;

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAddNewNPC_Click(object sender, EventArgs e)
        {
            if (this.txtAddNewNPC.Text.Length > 0)
            {
                NPC newNPC = new NPC(this.txtAddNewNPC.Text);
                NPCs.Add(newNPC);

                String strKey = "start";
                this.rtbStatement.Tag = strKey;

                Statement start = new Statement(strKey, "Hello there", "");
                newNPC.Statements.Add("start", start);
                this.treeDialogs.Nodes.Add(newNPC.Name);
                RebuildTreeNode();
              //  SetStatement(newNPC.Statements["start"]);


            }
        }
        void RebuildTreeNode()
        {
            this.treeDialogs.Nodes.Clear();
            foreach (NPC npc in NPCs)
            {
                TreeNode npcNode = new TreeNode();
                npcNode.Text = npc.Name;
                npcNode.Tag = npc;
                foreach (KeyValuePair<string, Statement> statement in npc.Statements)
                {
                    TreeNode statementNode = new TreeNode();
                    statementNode.Tag = statement.Value;
                    statementNode.Text = Utilities.GetLocalization(statement.Value.Text) + " ( " + statement.Value.ID + " )";
                    foreach (KeyValuePair<string, Response> response in statement.Value.Responses)
                    {
                        TreeNode responseNode = new TreeNode();
                        responseNode.Text = Utilities.GetLocalization(response.Value.Text) + " ( " + response.Value.ID + " )";
                        responseNode.Tag = response.Value;

                        foreach (Requirement requirement in response.Value.Requirements)
                        {
                            TreeNode requirementNode = new TreeNode();
                            requirementNode.Tag = requirement;
                            responseNode.Nodes.Add(requirementNode);
                        }

                        //  statementNode.Nodes.Add(responseNode);
                    }
                    npcNode.Nodes.Add(statementNode);
                }
                this.treeDialogs.Nodes.Add(npcNode);
            }
            UpdateNPCs();
            this.treeDialogs.ExpandAll();
            foreach(KeyValuePair<string, Statement> statement in GetCurrentNPC().Statements)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = Utilities.GetLocalization( statement.Value.Text );
                item.Value = statement.Key;

                this.cmbStatements.Items.Add(item);
            }
        }
        public void UpdateNPCs()
        {
            this.cmbNPCs.Items.Clear();
            foreach (NPC npc in NPCs)
                this.cmbNPCs.Items.Add(npc.Name);

            if (this.cmbNPCs.Items.Count > 0)
                this.cmbNPCs.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.cmbNPCs.SelectedItem == null)
                return;

            foreach (NPC npc in NPCs)
            {
                if (npc.Name == this.cmbNPCs.SelectedItem.ToString())
                {
                    String strKey = "statement_" + this.rtbStatement.Text.GetHashCode();
                    if (this.rtbStatement.Tag.ToString() == "start")
                        strKey = this.rtbStatement.Tag.ToString();

                    Statement newStatement = new Statement(strKey, this.rtbStatement.Text, "");
                    foreach (TreeNode node in this.treeReplies.Nodes)
                    {
                        Response response = node.Tag as Response;
                        if (response == null)
                            continue;

                       
                        newStatement.AddResponse(response.ID, response);
                        if ( !npc.Responses.ContainsKey( response.ID ))
                            npc.Responses.Add(response.ID, response);

                    }
                    if (!npc.Statements.ContainsKey(strKey))
                        npc.Statements.Add(strKey, newStatement);
                    else
                        npc.Statements[strKey] = newStatement;
                }
            }

            RebuildTreeNode();

        }

        private void treeDialogs_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.treeDialogs.SelectedNode == null)
                return;

            if (this.treeDialogs.SelectedNode.Level > 2)
                this.treeDialogs.SelectedNode = this.treeDialogs.SelectedNode.Parent;

            if (this.treeDialogs.SelectedNode != null)
            {
                if (this.treeDialogs.SelectedNode.Parent != null)
                    this.cmbNPCs.SelectedIndex = this.cmbNPCs.FindStringExact(this.treeDialogs.SelectedNode.Parent.Text);
                else
                {

                    this.cmbNPCs.SelectedIndex = this.cmbNPCs.FindStringExact(this.treeDialogs.SelectedNode.Text);
                    ClearForm(false);
                }
            }
        }

        private void txtAddNewNPC_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAddNewNPC_Click(null, null);
        }

        private void txtResponse_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAdd_Click(null, null);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void enabledExtensionsToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["Extensions"] = enabledExtensionsToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
        }

        private void lblStatements_Click(object sender, EventArgs e)
        {

        }

        private void cmbStatements_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddRequirement_Click(object sender, EventArgs e)
        {
            frmRequirement frm = new frmRequirement();
            frm.Text = "Add New Requirement for " + this.txtResponse.Text;
            frm.ShowDialog();
        }

        private void treeDialogs_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node == null) return;

            // if treeview's HideSelection property is "True", 
            // this will always returns "False" on unfocused treeview
            var selected = (e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected;
            var unfocused = !e.Node.TreeView.Focused;

            // we need to do owner drawing only on a selected node
            // and when the treeview is unfocused, else let the OS do it for us
            if (selected && unfocused)
            {
                var font = e.Node.NodeFont ?? e.Node.TreeView.Font;
                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, SystemColors.HighlightText, TextFormatFlags.GlyphOverhangPadding);
            }
            else
            {
                e.DrawDefault = true;
            }
        }
    }
}