﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

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

            // Set the drawmode for tree dialog. This helps keep the selected node highlighted.
            treeDialogs.DrawMode = TreeViewDrawMode.OwnerDrawText;
        }

        private void chkResponseID_CheckedChanged(object sender, EventArgs e)
        {
            txtResponseID.ReadOnly = !chkResponseID.Checked;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtResponse.Text.Length < 1)
            {
                MessageBox.Show("Please enter in what you'd like to say to the NPC");
                txtResponse.Focus();
                return;
            }
            if(!chkResponseID.Checked)
            {
                if(txtResponseID.MaxLength < 1)
                {
                    MessageBox.Show("Please enter in a unique response ID, or check the Auto Response checkbox.");
                    txtResponseID.Focus();
                    return;
                }
            }
            else
            {
                if(btnAdd.Text == "Add")
                    txtResponseID.Text = "responseID_" + txtResponse.Text.GetHashCode();
            }

            // Generate a new response.
            Response response = new Response();
            response.ID = txtResponseID.Text.Trim();
            response.Text = txtResponse.Text;

            ComboboxItem NextStatement = cmbStatements.SelectedItem as ComboboxItem;
            if(NextStatement != null && NextStatement.Text != "None")
                response.NextStatement = NextStatement.Value.ToString(); // Statement_key

            UpdateNode(response);

            txtResponse.Text = "";
            txtResponseID.Text = "";
            btnAdd.Text = "Add";

            btnSave_Click(null, null);
        }


        // Find the Response' node in the replies tree, remove it, and re-add it with the upated information.
        private void UpdateNode(Response response)
        {
            TreeNode targetNode = null;

            // see if a node already exists for this response.
            foreach(TreeNode searchNode in treeReplies.Nodes)
            {
                Response searchClass = searchNode.Tag as Response;
                if(searchClass.ID == response.ID)
                {
                    targetNode = searchNode;
                    break;
                }
            }

            // If a node doesn't exist, then create one. Remove the existing one.
            if(targetNode != null)
                treeReplies.Nodes.Remove(targetNode);

            targetNode = new TreeNode();
            targetNode.Text = Utilities.GetLocalization(response.Text);
            targetNode.ToolTipText = response.ToString();
            targetNode.Tag = response;
            foreach(Requirement requirement in response.Requirements)
            {
                TreeNode requirementNode = new TreeNode();
                requirementNode.Text = requirement.ToString();
                requirementNode.Tag = requirement;
                targetNode.Nodes.Add(requirementNode);
            }

            foreach(Action action in response.Actions)
            {
                TreeNode actionNode = new TreeNode();
                actionNode.Text = action.ToString();
                actionNode.Tag = action;
                targetNode.Nodes.Add(actionNode);
            }
            treeReplies.Nodes.Add(targetNode);
        }

        public void RefreshReplies()
        {

        }
        private void treeReplies_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                Point ClickPoint = new Point(e.X, e.Y);
                ClickNode = treeReplies.GetNodeAt(ClickPoint);
                if(ClickNode == null)
                    return;

                treeReplies.SelectedNode = ClickNode;
                GenerateContextMenu(ClickNode);
                Point ScreenPoint = treeReplies.PointToScreen(ClickPoint);
                Point FormPoint = PointToClient(ScreenPoint);
                ResponsesMenu.Show(this, FormPoint);
            }
            else if(e.Button == MouseButtons.Left)
            {
                Point ClickPoint = new Point(e.X, e.Y);
                ClickNode = treeReplies.GetNodeAt(ClickPoint);
                if(ClickNode == null)
                    return;

                EditResponse(null, null);
            }
        }

        public NPC GetCurrentNPC()
        {
            if(cmbNPCs.SelectedItem == null)
                return null;

            foreach(NPC npc in NPCs)
            {
                if(npc.Name == cmbNPCs.SelectedItem.ToString())
                    return npc;
            }
            return null;
        }

        private void GenerateDialogsContextMenu(TreeNode node)
        {
            DialogsContextMenu.Items.Clear();

            if(node.Tag is NPC)
            {
                DialogsContextMenu.Items.Insert(0, new ToolStripLabel(node.Text));
                DialogsContextMenu.Items.Add(new ToolStripSeparator());
                DialogsContextMenu.Items.Add("New Statement").Click += new EventHandler(NewStatement);
            }
            if(node.Tag is Statement)
            {
                DialogsContextMenu.Items.Insert(0, new ToolStripLabel(node.Parent.Text));
                DialogsContextMenu.Items.Add(new ToolStripSeparator());
                DialogsContextMenu.Items.Add("New Statement").Click += new EventHandler(NewStatement);
            }
        }

        private void NewStatement(object sender, EventArgs e)
        {
            if(ClickNode == null)
                return;

            if(ClickNode.Tag is NPC)
                cmbNPCs.SelectedIndex = cmbNPCs.FindStringExact(ClickNode.Text);
            else if(ClickNode.Tag is Statement)
                cmbNPCs.SelectedIndex = cmbNPCs.FindStringExact(ClickNode.Parent.Text);
            ClearForm(false);
            grpConversation.Visible = true;
            rtbStatement.Focus();
            String strKey = "statement_" + Utilities.RandomString(8).GetHashCode();
            rtbStatement.Tag = strKey;
            Statement newStatement = new Statement(strKey, "New Statement", "");
            GetCurrentNPC().AddStatement(newStatement);
            RebuildTreeNode();
            SetStatement(newStatement);


        }
        private void GenerateContextMenu(TreeNode node)
        {
            ResponsesMenu.Items.Clear();
            ResponsesMenu.Items.Insert(0, new ToolStripLabel(node.Text));
            if(node.Tag is Response)
            {
                ResponsesMenu.Items.Insert(1, new ToolStripSeparator());
                ResponsesMenu.Items.Add("Delete Response").Click += new EventHandler(RemoveResponse);
                ResponsesMenu.Items.Add("Edit Response").Click += new EventHandler(EditResponse);
                ResponsesMenu.Items.Add(new ToolStripSeparator());
                ResponsesMenu.Items.Add("Add Requirement").Click += new EventHandler(AddRequirement);
                ResponsesMenu.Items.Add("Add Action").Click += new EventHandler(AddAction);
                ResponsesMenu.Items.Add("Add Quest Entry").Click += new EventHandler(AddQuestEntry);
            }
            if(node.Tag is Requirement)
            {
                ResponsesMenu.Items.Add("Edit Requirement").Click += new EventHandler(EditRequirement);
                ResponsesMenu.Items.Add("Remove Requirement").Click += new EventHandler(RemoveRequirement);
            }
            if(node.Tag is Action)
            {
                ResponsesMenu.Items.Add("Add Action").Click += new EventHandler(AddAction);
                ResponsesMenu.Items.Add("Edit Action").Click += new EventHandler(EditAction);
                ResponsesMenu.Items.Add("Remove Action").Click += new EventHandler(RemoveAction);
            }

            if(node.Tag is QuestEntry)
            {
                ResponsesMenu.Items.Add("Edit QuestEntry").Click += new EventHandler(AddQuestEntry);
                ResponsesMenu.Items.Add("Remove QuestEntry").Click += new EventHandler(AddQuestEntry);
            }

        }

        private void AddAction(object sender, EventArgs e)
        {
            if(ClickNode == null)
                return;

            frmAction frm = new frmAction();
            frm.ShowDialog();
            if(frm.DialogResult == DialogResult.OK)
            {
                Response response = ClickNode.Tag as Response;
                foreach(Action action in response.Actions)
                {
                    if(action.Hash == frm.action.Hash)
                        return;
                }
                response.AddAction(frm.action);

                UpdateNode(response);
                ClickNode = null;
            }
        }

        private void EditAction(object sender, EventArgs e)
        {
            if (ClickNode == null)
                return;

            Action action = ClickNode.Tag as Action;
            if (action == null)
                return;

            frmAction frm = new frmAction();
            frm.SetAction(action);

            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                Response response = ClickNode.Parent.Tag as Response;
                if (response == null)
                    return;

                response.AddAction(frm.action);
                UpdateNode(response);
                ClickNode = null;
            }

        }

        private void RemoveAction(object sender, EventArgs e)
        {
            if (ClickNode == null)
                return;

            Action action = ClickNode.Tag as Action;
            if (action == null)
                return;
            Response response = ClickNode.Parent.Tag as Response;
            if (response == null)
                return;

            response.Actions.Remove(action);
            treeReplies.Nodes.Remove(ClickNode);
            ClickNode = null;
        }
        private void AddQuestEntry(object sender, EventArgs e)
        {

        }
        private void AddRequirement(object sender, EventArgs e)
        {
            if(ClickNode == null)
                return;

            frmRequirement frm = new frmRequirement();
            frm.ShowDialog();
            if(frm.DialogResult == DialogResult.OK)
            {
                Response response = ClickNode.Tag as Response;
                foreach(Requirement require in response.Requirements)
                {
                    if(require.Hash == frm.requirement.Hash)
                        return;
                }
                response.AddRequirement(frm.requirement);

                UpdateNode(response);
                ClickNode = null;
            }

        }

        private void EditRequirement(object sender, EventArgs e)
        {
            if(ClickNode == null)
                return;

            Requirement requirement = ClickNode.Tag as Requirement;
            if(requirement == null)
                return;

            frmRequirement frm = new frmRequirement();
            frm.SetRequirement(requirement);

            frm.ShowDialog();
            if(frm.DialogResult == DialogResult.OK)
            {
                Response response = ClickNode.Parent.Tag as Response;
                if(response == null)
                    return;

                response.AddRequirement(frm.requirement);
                UpdateNode(response);
                ClickNode = null;
            }

        }

        private void RemoveRequirement(object sender, EventArgs e)
        {
            if(ClickNode == null)
                return;

            Requirement requirement = ClickNode.Tag as Requirement;
            if(requirement == null)
                return;
            Response response = ClickNode.Parent.Tag as Response;
            if(response == null)
                return;

            response.Requirements.Remove(requirement);
            treeReplies.Nodes.Remove(ClickNode);
            ClickNode = null;
        }
        private void RemoveResponse(object sender, EventArgs e)
        {
            if(ClickNode == null)
                return;

            treeReplies.Nodes.Remove(ClickNode);
            Response response = ClickNode.Tag as Response;
            String strNPC = cmbNPCs.SelectedItem.ToString();
            NPC currentNPC = GetCurrentNPC();
            if(currentNPC != null)
                currentNPC.Responses.Remove(response.ID);
            foreach(KeyValuePair<string, Statement> keyValuePair in currentNPC.Statements)
                keyValuePair.Value.Responses.Remove(response.ID);
            ClickNode = null;
        }

        private void EditResponse(object sender, EventArgs e)
        {
            if(ClickNode == null)
                return;

            btnAdd.Text = "Save";
            Response response = ClickNode.Tag as Response;
            if(response == null)
                return;
            txtResponse.Text = Utilities.GetLocalization(response.Text);
            txtResponseID.Text = response.ID;
        }

        private void treeDialogs_Click(object sender, EventArgs e)
        {


        }


        private void treeDialogs_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                Point ClickPoint = new Point(e.X, e.Y);
                ClickNode = treeDialogs.GetNodeAt(ClickPoint);
                if(ClickNode == null)
                    return;

                treeDialogs.SelectedNode = ClickNode;
                GenerateDialogsContextMenu(ClickNode);
                Point ScreenPoint = treeDialogs.PointToScreen(ClickPoint);
                Point FormPoint = PointToClient(ScreenPoint);
                DialogsContextMenu.Show(this, FormPoint);
            }
            if(e.Button == MouseButtons.Left)
            {
                Point ClickPoint = new Point(e.X, e.Y);
                ClickNode = treeDialogs.GetNodeAt(ClickPoint);
                if(ClickNode == null)
                    return;

                if(ClickNode.Parent == null)
                    return;

                treeReplies.SelectedNode = ClickNode;
                //if(ClickNode.Tag is Statement)
                //    SetStatement(ClickNode.Tag as Statement);
            }
        }

        private void SetStatement(Statement statement)
        {
            if(statement == null)
                return;

            grpConversation.Visible = true;
            rtbStatement.Text = Utilities.GetLocalization(statement.Text);
            treeReplies.Nodes.Clear();
            foreach(KeyValuePair<string, Response> response in statement.Responses)
                UpdateNode(response.Value);

           
            //foreach(TreeNode node in this.treeDialogs.Nodes)
            //{
            //    TreeNode myNode = Utilities.FromID(statement.ID, node);
            //    if(myNode != null)
            //        this.treeDialogs.SelectedNode = myNode;
            //}
            txtResponse.Focus();
            txtResponse.Text = "";
            txtResponseID.Text = "";
        }
        private void SetStatement()
        {
            if(ClickNode == null)
                return;
            if(ClickNode.Level == 1)
            {
                foreach(NPC npc in NPCs)
                {
                    if(npc.Name == ClickNode.Parent.Text)
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
            if(e.Button == MouseButtons.Left)
            {
                Point ClickPoint = new Point(e.X, e.Y);
                ClickNode = treeReplies.GetNodeAt(ClickPoint);
                if(ClickNode == null)
                    return;

                Response response = ClickNode.Tag as Response;
                if(response == null)
                    return;

                TreeNode itemNode = null;
                foreach(TreeNode node in treeDialogs.Nodes)
                {
                    // Look for the next statement in the list.
                    itemNode = Utilities.FromID(response.NextStatement, node);
                    if(itemNode != null)
                        break;
                }

                if(itemNode == null)
                    return;

                ClickNode = itemNode;
                treeDialogs.SelectedNode = ClickNode;

             
            }
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strFile;
            using(OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                String strDefaultFolder = @"C:\Program Files (x86)\Steam\steamapps\common\7 Days To Die\Data\Config";
                if(Directory.Exists(strDefaultFolder))
                    openFileDialog.InitialDirectory = strDefaultFolder;
                else
                    openFileDialog.InitialDirectory = "c:\\";

                openFileDialog.Filter = "dialogs.xml files (*.xml)|*.xml";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    strFile = openFileDialog.FileName;
                    doc.Load(strFile);
                    foreach(XmlNode dialogNode in doc.SelectNodes("//dialog"))
                        NPCs.Add(new NPC(dialogNode));

                    Utilities.InitLocalization(Path.GetDirectoryName(strFile));
                    RebuildTreeNode();
                }
            }

        }

        private void ClearForm(bool fullClear = false)
        {
            if(fullClear)
            {
                NPCs.Clear();
                doc = new XmlDocument();
                treeDialogs.Nodes.Clear();
            }
            treeReplies.Nodes.Clear();
            txtResponse.Text = "";
            txtResponseID.Text = "";
            rtbStatement.Text = "";

        }
        private void closeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearForm(true);
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = "c:\\";
                saveFileDialog.Filter = "dialogs.xml files (*.xml)|*.xml";
                saveFileDialog.Title = "Save an dialogs";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;

                if(saveFileDialog.ShowDialog() == DialogResult.OK)
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

                    foreach(NPC npc in NPCs)
                    {
                        XmlNode npcNode = saveDoc.CreateElement("dialog");
                        XmlAttribute npcID = saveDoc.CreateAttribute("id");
                        XmlAttribute startStatement = saveDoc.CreateAttribute("startstatementid");
                        startStatement.Value = "start";
                        npcNode.Attributes.Append(startStatement);

                        npcID.Value = npc.Name;
                        npcNode.Attributes.Append(npcID);

                        append.AppendChild(npcNode);

                        foreach(KeyValuePair<string, Statement> statement in npc.Statements)
                            npcNode.AppendChild(statement.Value.GenerateXMLNode(saveDoc));

                        foreach(KeyValuePair<string, Response> response in npc.Responses)
                            npcNode.AppendChild(response.Value.GenerateXMLNode(saveDoc));

                        saveDoc.Save(saveFileDialog.FileName);
                    }
                }
            }

        }



        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAddNewNPC_Click(object sender, EventArgs e)
        {
            if(txtAddNewNPC.Text.Length > 0)
            {
                NPC newNPC = new NPC(txtAddNewNPC.Text);
                NPCs.Add(newNPC);

                String strKey = "start";
                rtbStatement.Tag = strKey;

                Statement start = new Statement(strKey, "Hello there", "");
                newNPC.Statements.Add("start", start);
                treeDialogs.Nodes.Add(newNPC.Name);
                RebuildTreeNode();
                SetStatement(newNPC.Statements["start"]);


            }
        }
        void RebuildTreeNode()
        {
            treeDialogs.Nodes.Clear();
            foreach(NPC npc in NPCs)
            {
                TreeNode npcNode = new TreeNode(npc.Name);
                npcNode.Tag = npc;

                foreach(KeyValuePair<string, Statement> statement in npc.Statements)
                {
                    TreeNode statementNode = new TreeNode();
                    statementNode.Tag = statement.Value;
                    statementNode.Text = Utilities.GetLocalization(statement.Value.Text).Replace("\n", "") + " ( " + statement.Value.ID + " )";
                    foreach(KeyValuePair<string, Response> response in statement.Value.Responses)
                    {
                        TreeNode responseNode = new TreeNode();
                        responseNode.Text = Utilities.GetLocalization(response.Value.Text) + " ( " + response.Value.ID + " )";
                        responseNode.Tag = response.Value;

                        foreach(Requirement requirement in response.Value.Requirements)
                        {
                            TreeNode requirementNode = new TreeNode();
                            requirementNode.Tag = requirement;
                            responseNode.Nodes.Add(requirementNode);
                        }

                        //  statementNode.Nodes.Add(responseNode);
                    }
                    npcNode.Nodes.Add(statementNode);
                }
                treeDialogs.Nodes.Add(npcNode);
            }
            UpdateNPCs();
            treeDialogs.ExpandAll();


            cmbStatements.Items.Clear();
            ComboboxItem item = new ComboboxItem();
            item.Text = "None";
            item.Value = "None";
            cmbStatements.Items.Add(item);
            foreach(KeyValuePair<string, Statement> statement in GetCurrentNPC().Statements)
            {
                item = new ComboboxItem();
                item.Text = Utilities.GetLocalization(statement.Value.Text) + " ( " + statement.Key + " ) ";
                item.Value = statement.Key;
                cmbStatements.Items.Add(item);
            }

            cmbStatements.SelectedIndex = 0;
        }

        // Update the NPC combo box
        public void UpdateNPCs()
        {
            cmbNPCs.Items.Clear();
            foreach(NPC npc in NPCs)
                cmbNPCs.Items.Add(npc.Name);

            if(cmbNPCs.Items.Count > 0)
                cmbNPCs.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(cmbNPCs.SelectedItem == null)
                return;

            NPC npc = GetCurrentNPC();

            String strKey = rtbStatement.Tag.ToString();
        
            Statement newStatement = new Statement(strKey, rtbStatement.Text, "");
            foreach(TreeNode node in treeReplies.Nodes)
            {
                Response response = node.Tag as Response;
                if(response == null)
                    continue;


                newStatement.AddResponse(response.ID, response);
                npc.AddResponse(response);

            }

            npc.AddStatement(newStatement);
            RebuildTreeNode();
        }

        private void treeDialogs_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(treeDialogs.SelectedNode == null)
                return;

            // if for any reaspon, there's more than 2 levels of node, point to the parent.
            if(treeDialogs.SelectedNode.Level > 2)
                treeDialogs.SelectedNode = treeDialogs.SelectedNode.Parent;

            // Re-check, just in case the above ParentNode is null.
            if(treeDialogs.SelectedNode == null)
                return;

            // Set the current selected NPC is.
            if(treeDialogs.SelectedNode.Tag is NPC)
            {
                grpConversation.Visible = false;
                treeDialogs.Enabled = true;
            }
            if(treeDialogs.SelectedNode.Tag is Statement)
            {
                grpConversation.Visible = true;
                // this.treeDialogs.Enabled = false;

                cmbNPCs.SelectedIndex = cmbNPCs.FindStringExact(treeDialogs.SelectedNode.Parent.Text);

                // Don't clear the entire form, just the conversation.
                ClearForm(false);
                SetStatement(treeDialogs.SelectedNode.Tag as Statement);
            }
        }

        private void enabledExtensionsToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["Extensions"] = enabledExtensionsToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
        }

        // This method keeps the selected node highlighted, even if the focus is taken off of it to another control.
        private void treeDialogs_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if(e.Node == null)
                return;

            // if treeview's HideSelection property is "True", 
            // this will always returns "False" on unfocused treeview
            var selected = (e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected;
            var unfocused = !e.Node.TreeView.Focused;

            // we need to do owner drawing only on a selected node
            // and when the treeview is unfocused, else let the OS do it for us
            if(selected && unfocused)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
            // this.treeDialogs.Enabled = true;
            if(treeDialogs.Nodes[0] != null)
                treeDialogs.SelectedNode = treeDialogs.Nodes[0];

        }

        private void txtAddNewNPC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                btnAddNewNPC_Click(null, null);
            }
        }

        private void txtResponse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;


                btnAdd_Click(null, null);
            }
        }
    }
}