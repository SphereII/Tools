using System;
using System.Collections.Generic;
using AutoUpdaterDotNET;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;


namespace _7DaysToDialog
{
    public partial class frmMain : Form
    {
        TreeNode ClickNode = null;
        XmlDocument doc = new XmlDocument();

        public List<NPC> NPCs = new List<NPC>();
        public Statement Temporary = null;
        public NPC SelectedNPC = null;

      
        public frmMain()
        {
            InitializeComponent();
     
            lblVersion.Text = "Version: " + Assembly.GetEntryAssembly().GetName().Version.ToString();

            // Updates the menu with the correct setting
            enabledExtensionsToolStripMenuItem.Checked = (bool)Properties.Settings.Default["Extensions"];

            treeDialogs.DrawMode = TreeViewDrawMode.OwnerDrawText;
            treeReplies.DrawMode = TreeViewDrawMode.OwnerDrawText;

            rdoUseExisting_CheckedChanged(null, null);
            InitMenu();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            String strFilename = sender.ToString().Remove(0,4);
                
                if (File.Exists(strFilename))
                OpenFile(strFilename);
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
                if (btnAdd.Text == "Add")
                    txtResponseID.Text = "responseID_" + Utilities.RandomString().GetHashCode();
            }

            // Generate a new response.
            Response response = new Response();

            if (txtResponseID.Tag is Response)
            {
                response = txtResponseID.Tag as Response;
            }
            response.ID = txtResponseID.Text.Trim();
            if (String.IsNullOrEmpty(response.ID))
                response.ID = "response_" + Utilities.RandomString().GetHashCode();
            response.Text = txtResponse.Text;

            if(this.rdoUseExisting.Checked)
            {
                ComboboxItem NextStatement = cmbStatements.SelectedItem as ComboboxItem;
                if(NextStatement != null && NextStatement.Text != "None")
                    response.NextStatement = NextStatement.Value.ToString(); // Statement_key
            }
            else
            {
                if(this.txtCreateNewStatement.TextLength > 0)
                {
                    String strKey = "statement_" + this.txtCreateNewStatement.Text.ToString().GetHashCode();
                    Statement newStatement = new Statement(strKey, this.txtCreateNewStatement.Text, this.rtbStatement.Tag as String, this.rtbStatement.Tag as String);
                    GetCurrentNPC().AddStatement(newStatement);
                    response.NextStatement = strKey;
                    RebuildTreeNode();
                }
            }
            UpdateNode(response);

            txtResponse.Text = "";
            txtResponseID.Text = "";
            txtResponseID.Tag = null;
            btnAdd.Text = "Add";
            this.txtCreateNewStatement.Text = "";
            this.cmbStatements.SelectedIndex = 0;

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

            int NodePosition = 0;
            // If a node doesn't exist, then create one. Remove the existing one.
            if (targetNode != null)
            {
                NodePosition = targetNode.Index;
                treeReplies.Nodes.Remove(targetNode);
            }
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
            treeReplies.Nodes.Insert(NodePosition, targetNode);
            treeReplies.Update();
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
                if (ClickNode == null)
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
                DialogsContextMenu.Items.Add("Paste Statement").Click += new EventHandler(PasteStatement);
                DialogsContextMenu.Items.Add(new ToolStripSeparator());
                DialogsContextMenu.Items.Add("Remove NPC").Click += new EventHandler(RemoveNPC);
                DialogsContextMenu.Items.Add("Clone NPC").Click += new EventHandler(CloneNPC);
                DialogsContextMenu.Items.Add("Rename NPC").Click += new EventHandler(RenameNPC);
                DialogsContextMenu.Items.Add(new ToolStripSeparator());
                DialogsContextMenu.Items.Add("Save NPC").Click += new EventHandler(SaveNPC);
            }
            if (node.Tag is Statement)
            {
                DialogsContextMenu.Items.Insert(0, new ToolStripLabel(node.Parent.Text));
                DialogsContextMenu.Items.Add(new ToolStripSeparator());
                DialogsContextMenu.Items.Add("New Statement").Click += new EventHandler(NewStatement);
                DialogsContextMenu.Items.Add("Delete Statement").Click += new EventHandler(DeleteStatement);
                DialogsContextMenu.Items.Add("Copy Statement").Click += new EventHandler(CopyStatement);


            }
        }

        public void RenameNPC(object sender, EventArgs e)
        {
            if (ClickNode == null)
                return;

            if (ClickNode.Tag is NPC)
            {
                SelectedNPC = ClickNode.Tag as NPC;
                frmRename frmRenameNPC = new frmRename();
                frmRenameNPC.NPCName = SelectedNPC.Name;
                frmRenameNPC.ShowDialog();
                if (frmRenameNPC.DialogResult == DialogResult.OK)
                {
                    foreach (NPC npc in NPCs)
                    {
                        if (npc.Name == SelectedNPC.Name)
                        {
                            npc.Name = frmRenameNPC.NPCName;
                            break;
                        }
                    }
                }
                SelectedNPC = null;
                RebuildTreeNode();

            }
        }
        public void CloneNPC(object sender, EventArgs e)
        {
            if (ClickNode == null)
                return;

            if (ClickNode.Tag is NPC)
            {
                SelectedNPC = ClickNode.Tag as NPC;
                NPC newNPC = NPC.DeepClone(SelectedNPC);
                newNPC.Name = SelectedNPC.Name + " ( Clone " + NPCs.Count + " )";
                //NPC newNPC = SelectedNPC.Clone( strName );
                NPCs.Add(newNPC);
                SelectedNPC = null;
                RebuildTreeNode();

            }
        }
        public void SaveNPC(object sender, EventArgs e)
        {
            if (ClickNode == null)
                return;

            if (ClickNode.Tag is NPC)
            {
                SelectedNPC = ClickNode.Tag as NPC;
                saveFileToolStripMenuItem_Click(null, null);
            }
        }
        public void CopyStatement(object sender, EventArgs e)
        {
            if (ClickNode == null)
                return;

            if (ClickNode.Tag is Statement)
            {
                Temporary = ClickNode.Tag as Statement;
                SelectedNPC = ClickNode.Parent.Tag as NPC;
            }
        }


        public void PasteStatement(object sender, EventArgs e)
        {
            if (ClickNode == null)
                return;

            if (Temporary == null)
                return;

            if (ClickNode.Tag is NPC)
            {
                NPC myNPC = ClickNode.Tag as NPC;
                myNPC.AddStatement(Temporary);
                foreach (KeyValuePair<string, Response> keyValuePair in Temporary.Responses)
                {
                    if ( SelectedNPC.Statements.ContainsKey( keyValuePair.Key ))
                        myNPC.AddStatement(SelectedNPC.Statements[keyValuePair.Key]);
                    if (SelectedNPC.Responses.ContainsKey(keyValuePair.Key))
                        myNPC.AddResponse(SelectedNPC.Responses[keyValuePair.Key]);
                }
                Temporary = null;
                SelectedNPC = null;
                RebuildTreeNode();

            }
        }



        public void DeleteStatement(object sender, EventArgs e)
        {
            if(ClickNode == null)
                return;

            if(ClickNode.Tag is Statement)
            {
                Statement statement = ClickNode.Tag as Statement;
                NPC npc = ClickNode.Parent.Tag as NPC;
                if(npc != null)
                {
                    npc.Statements.Remove(statement.ID);
                }
            }

            RebuildTreeNode();

        }
        public void RemoveNPC(object sender, EventArgs e)
        {
            if(ClickNode == null)
                return;

            if(ClickNode.Tag is NPC)
                NPCs.Remove(ClickNode.Tag as NPC);
            RebuildTreeNode();
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
            String strKey = "statement_" + Utilities.RandomString().GetHashCode();
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
                ResponsesMenu.Items.Add("Add New Response").Click += new EventHandler(NewResponse);
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

        private void NewResponse(object sender, EventArgs e)
        {
            NPC currentNPC = GetCurrentNPC();
            txtResponse.Text = "";
            txtResponseID.Text = "";
            btnAdd.Text = "Add";
            this.txtCreateNewStatement.Text = "";
            this.cmbNPCs.SelectedIndex = this.cmbNPCs.FindStringExact(currentNPC.Name);
            this.cmbStatements.SelectedIndex = 0;
            //btnSave_Click(null, null);
            
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
            if(this.rtbStatement.Tag is Statement)
            {
                Statement statement = this.rtbStatement.Tag as Statement;
                statement.AddQuest("0", "add");
                statement.AddQuest("1", "add");
                statement.AddQuest("2", "add");
                statement.AddQuest("3", "add");
                statement.AddQuest("4", "add");
                
            }
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
            txtResponseID.Tag = response;

            if(string.IsNullOrEmpty(response.NextStatement))
                this.cmbStatements.SelectedIndex = 0;
            else
            {
                foreach(ComboboxItem item in this.cmbStatements.Items)
                {
                    if(item.Value.ToString() == response.NextStatement)
                    {
                        this.cmbStatements.SelectedItem = item;
                        break;
                    }
                }
            }

        }

        private void treeDialogs_Click(object sender, EventArgs e)
        {
            this.pnlInformation.SendToBack();

        }


        private void treeDialogs_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.pnlInformation.SendToBack();

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

                if (ClickNode.Parent == null)
                    return;

                treeReplies.SelectedNode = ClickNode;
                if (ClickNode.Tag is NPC)
                    this.pnlInformation.BringToFront();
                if(ClickNode.Tag is Statement)
                    SetStatement(ClickNode.Tag as Statement);

                if (ClickNode.Tag is Response)
                    SetStatement(ClickNode.Parent.Tag as Statement);
                if (ClickNode.Tag is Requirement)
                    SetStatement(ClickNode.Parent.Parent.Tag as Statement);
                if (ClickNode.Tag is Action)
                    SetStatement(ClickNode.Parent.Parent.Tag as Statement);
            }
        }

        private void SetStatement(Statement statement)
        {
            if(statement == null)
                return;

            grpConversation.Visible = true;
            rtbStatement.Text = Utilities.GetLocalization(statement.Text).Trim();
            rtbStatement.Tag = statement.ID;
            treeReplies.Nodes.Clear();
            foreach(KeyValuePair<string, Response> response in statement.Responses.Reverse())
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
            txtResponseID.Tag = null;
            this.cmbStatements.SelectedIndex = 0;
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

                        //If there's no replies, then it's just an empty statement that returns back to the main statement.
                        if(this.treeReplies.Nodes.Count == 0)
                        {
                            Response temp = new Response();
                            temp.ID = statement.NextStatement;
                            temp.Text = "Next";
                            temp.NextStatement = statement.NextStatement;

                            TreeNode node = new TreeNode();
                            node.Text = temp.Text;
                            node.Tag = temp;
                            this.treeReplies.Nodes.Add(node);

                        }
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

        public void OpenFile(String strFileName)
        {
            doc.Load(strFileName);
            Properties.Settings.Default["LastPath"] = Path.GetDirectoryName( strFileName);
            Properties.Settings.Default.Save();

            foreach (XmlNode dialogNode in doc.SelectNodes("//dialog"))
                NPCs.Add(new NPC(dialogNode));

            Utilities.InitLocalization(Path.GetDirectoryName(strFileName));
            RebuildTreeNode();

            if (!Properties.Settings.Default["Recent"].ToString().Contains(strFileName))
            {
                Properties.Settings.Default["Recent"] += ";" + strFileName;
                Properties.Settings.Default.Save();
            }
        }
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
   

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
                String strLastPath = Properties.Settings.Default["LastPath"].ToString();
                if ( String.IsNullOrEmpty( strLastPath ))
                    saveFileDialog.InitialDirectory = "c:\\";
                else
                    saveFileDialog.InitialDirectory = strLastPath;
                saveFileDialog.Filter = "dialogs.xml files (*.xml)|*.xml";
                if ( SelectedNPC == null )
                    saveFileDialog.Title = "Save Dialogs.xml";
                else
                    saveFileDialog.Title = "Saving " + SelectedNPC.Name;
                saveFileDialog.FilterIndex = 2;
              //  saveFileDialog.RestoreDirectory = true;

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
                        // 
                        if (SelectedNPC != null && SelectedNPC != npc)
                            continue;
                        XmlNode npcNode = saveDoc.CreateElement("dialog");
                        XmlAttribute npcID = saveDoc.CreateAttribute("id");
                        XmlAttribute startStatement = saveDoc.CreateAttribute("startstatementid");

                        npcID.Value = npc.Name;
                        npcNode.Attributes.Append(npcID);

                        startStatement.Value = "start";
                        npcNode.Attributes.Append(startStatement);

                        append.AppendChild(npcNode);

                        foreach(KeyValuePair<string, Statement> statement in npc.Statements)
                            npcNode.AppendChild(statement.Value.GenerateXMLNode(saveDoc));

                        foreach(KeyValuePair<string, Response> response in npc.Responses)
                            npcNode.AppendChild(response.Value.GenerateXMLNode(saveDoc));

               
                    }

                    String strLocalizationFile = Path.Combine(Path.GetDirectoryName(saveFileDialog.FileName), "Localization.txt");
                    Utilities.WriteLocalization(strLocalizationFile);
                    saveDoc.Save(saveFileDialog.FileName);
                }
            }
            SelectedNPC = null;
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
                this.treeDialogs.Visible = true;
            }
            else
            {
                MessageBox.Show("Please enter in a new NPC name, and press the Add NPC Button.");
            }
            this.txtAddNewNPC.Text = "";
        }
        void RebuildTreeNode()
        {
            this.treeDialogs.Visible = true;
            
            treeDialogs.Nodes.Clear();

            if (NPCs.Count == 0)
            {
                this.pnlInformation.BringToFront();
                return;
            }
            else
            {
                this.pnlInformation.SendToBack();
            }
            treeDialogs.SuspendLayout();
            foreach (NPC npc in NPCs)
            {
                TreeNode npcNode = new TreeNode(npc.Name);
                npcNode.Tag = npc;

                foreach(KeyValuePair<string, Statement> statement in npc.Statements)
                {
                    TreeNode statementNode = new TreeNode();
                    statementNode.Tag = statement.Value;
                    statementNode.Text = Utilities.GetLocalization(statement.Value.Text).Replace("\n", "") + " ( " + statement.Value.ID + " )";
                    foreach(KeyValuePair<string, string> Quests in statement.Value.QuestEntries)
                    {
                        TreeNode questNode = new TreeNode();
                        questNode.Text = "Quest Entry ( " + Quests.Key + " )";
                        questNode.Tag = Quests;
                        statementNode.Nodes.Add(questNode);

                    }

                    foreach(KeyValuePair<string, Response> response in statement.Value.Responses)
                    {
                        TreeNode responseNode = new TreeNode();
                        responseNode.Text = Utilities.GetLocalization(response.Value.Text) + " ( " + response.Value.ID + " )";
                        responseNode.Tag = response.Value;

                        foreach(Requirement requirement in response.Value.Requirements)
                        {
                            TreeNode requirementNode = new TreeNode();
                            requirementNode.Text = requirement.ToString();
                            requirementNode.Tag = requirement;
                            responseNode.Nodes.Add(requirementNode);
                        }
                        foreach (Action action in response.Value.Actions)
                        {
                            TreeNode actionNode = new TreeNode();
                            actionNode.Text = action.ToString();
                            actionNode.Tag = action;
                            responseNode.Nodes.Add(actionNode);
                        }

                         statementNode.Nodes.Add(responseNode);

                    }
                    npcNode.Nodes.Add(statementNode);
                }
                treeDialogs.Nodes.Add(npcNode);
            }

            
            UpdateNPCs();
            if (chkStatementOnly.Checked)
            {
                treeDialogs.CollapseAll();
                foreach (TreeNode node in this.treeDialogs.Nodes)
                {
                    if (node.Tag is Statement || node.Tag is NPC)
                        node.Expand();
                }
            }
            else
            {

                treeDialogs.ExpandAll();
            }
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
            treeDialogs.ResumeLayout();
        }

        // Update the NPC combo box
        public void UpdateNPCs()
        {
            NPC currentNPC = GetCurrentNPC();
            cmbNPCs.Items.Clear();
            foreach(NPC npc in NPCs)
                cmbNPCs.Items.Add(npc.Name);

            if(cmbNPCs.Items.Count > 0)
                cmbNPCs.SelectedIndex = 0;

            if (currentNPC != null)
                cmbNPCs.SelectedIndex = cmbNPCs.FindStringExact(currentNPC.Name);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(cmbNPCs.SelectedItem == null)
                return;

            NPC npc = GetCurrentNPC();

            String strKey = rtbStatement.Tag.ToString();
        
            Statement newStatement = new Statement(strKey, rtbStatement.Text.TrimEnd(), "");
            foreach(TreeNode node in treeReplies.Nodes)
            {
                Response response = node.Tag as Response;
                if(response == null)
                    continue;

                newStatement.AddResponse(response.ID, response);
                npc.AddResponse(response);
            }

            if (treeReplies.Nodes.Count == 0)
            {
                MessageBox.Show("This statement does not have any responses. You could get stuck in an empty dialog session. Please make a generic response and reference an other statement.", "Missing Return Statement", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            npc.AddStatement(newStatement);
            RebuildTreeNode();
            grpAddNewResponse.Visible = false;
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

        private void rdoUseExisting_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlCreateNew.Visible = false;
            this.pnlLinkExisting.Visible = false;
            if(this.rdoCreateNew.Checked)
                this.pnlCreateNew.Visible = true;
            else
                this.pnlLinkExisting.Visible = true;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if ( this.treeReplies.SelectedNode != null )
                MoveNode(this.treeReplies, this.treeReplies.SelectedNode, true);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if(this.treeReplies.SelectedNode != null)
                MoveNode(this.treeReplies, this.treeReplies.SelectedNode, false);

        }

        public void MoveNode(TreeView tv, TreeNode node, bool up)
        {

            if((node.PrevNode == null) && up)
            {
                return;
            }

            if((node.NextNode == null) && !up)
            {
                return;
            }

            int newIndex = up ? node.Index - 1 : node.Index + 1;

            var nodes = tv.Nodes;
            if(node.Parent != null)
            {
                nodes = node.Parent.Nodes;
            }

            nodes.Remove(node);
            nodes.Insert(newIndex, node);
            this.treeReplies.SelectedNode = node;
            Statement statement = GetCurrentNPC().Statements[this.rtbStatement.Tag.ToString()];
            statement.Responses = new Dictionary<string, Response>();
            foreach(TreeNode myNode in this.treeReplies.Nodes)
            {
                if ( myNode.Tag is Response)
                    statement.AddResponse(myNode.Tag as Response);
            }

        }

        private void treeReplies_DrawNode(object sender, DrawTreeNodeEventArgs e)
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

        private void InitMenu()
        {
            string[] recents = Properties.Settings.Default["Recent"].ToString().Split(';');
            while (recents.Length > 5)
            {
                recents = recents.Skip(1).ToArray();
            }

            List<ToolStripItem> removeItems = new List<ToolStripItem>();
            if (this.fileToolStripMenuItem.HasDropDownItems)
            {

                foreach (var temp in this.fileToolStripMenuItem.DropDownItems)
                {
                    ToolStripMenuItem item = temp as ToolStripMenuItem;
                    if (item != null )
                    {
                        if (item.Text.Contains("): "))
                            removeItems.Add(item);
                    }
                }
                if (removeItems != null)
                {
                    foreach (ToolStripItem item in removeItems)
                        this.fileToolStripMenuItem.DropDownItems.Remove(item);
                }
            }
            int Counter = 1;
            foreach (string strRecent in recents.Reverse())
            {
                if (string.IsNullOrEmpty(strRecent))
                    continue;
                ToolStripMenuItem item = new ToolStripMenuItem(strRecent);
                item.Size = new System.Drawing.Size(180, 22);
                item.Text = Counter + "): " + strRecent;
                item.Name = strRecent;
                item.Click += new System.EventHandler(OpenFile_Click);
                this.fileToolStripMenuItem.DropDownItems.Add(item);
                Counter++;
            }
            // Populate the recent in the correct order
            foreach (string strRecent in recents)
                Properties.Settings.Default["Recent"] += ";" + strRecent;

            Properties.Settings.Default.Save();
        }

        private void dialogToolStripMenuItem_Click(object sender, EventArgs e)
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
                    OpenFile(strFile);
                    String strFolder = Path.GetDirectoryName(strFile);
                    Utilities.InitLocalization(strFolder);

                }
            }
        }

        private void localizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strFile;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                String strDefaultFolder = @"C:\Program Files (x86)\Steam\steamapps\common\7 Days To Die\Data\Config";
                if (Directory.Exists(strDefaultFolder))
                    openFileDialog.InitialDirectory = strDefaultFolder;
                else
                    openFileDialog.InitialDirectory = "c:\\";

                openFileDialog.Filter = "Localization files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    strFile = openFileDialog.FileName;
                    Utilities.InitLocalization(strFile);
                }
            }
        }

        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoUpdater.ReportErrors = true;
            AutoUpdater.Start("https://raw.githubusercontent.com/SphereII/Tools/master/7DaysToDialogInstaller/AutoUpdate.xml");

        }

        private void btnAddNewResponse_Click(object sender, EventArgs e)
        {
            grpAddNewResponse.Visible = true;
        }

        private void tutorialToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void chkStatementOnly_CheckedChanged(object sender, EventArgs e)
        {
            RebuildTreeNode();
        }

        private void rtbInformation_TextChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}