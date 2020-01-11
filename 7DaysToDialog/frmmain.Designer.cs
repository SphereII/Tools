namespace _7DaysToDialog
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.grpConversation = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbNPCs = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpAddNewResponse = new System.Windows.Forms.GroupBox();
            this.pnlCreateNew = new System.Windows.Forms.Panel();
            this.txtCreateNewStatement = new System.Windows.Forms.TextBox();
            this.lblnewStatement = new System.Windows.Forms.Label();
            this.pnlLinkExisting = new System.Windows.Forms.Panel();
            this.cmbStatements = new System.Windows.Forms.ComboBox();
            this.lblStatements = new System.Windows.Forms.Label();
            this.rdoCreateNew = new System.Windows.Forms.RadioButton();
            this.rdoUseExisting = new System.Windows.Forms.RadioButton();
            this.txtResponseID = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.chkResponseID = new System.Windows.Forms.CheckBox();
            this.lblNewResponse = new System.Windows.Forms.Label();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.grpResponses = new System.Windows.Forms.GroupBox();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.treeReplies = new System.Windows.Forms.TreeView();
            this.grpNPC = new System.Windows.Forms.GroupBox();
            this.rtbStatement = new System.Windows.Forms.RichTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ResponsesMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.treeDialogs = new System.Windows.Forms.TreeView();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dialogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enabledExtensionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddNewNPC = new System.Windows.Forms.Button();
            this.txtAddNewNPC = new System.Windows.Forms.TextBox();
            this.DialogsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnAddNewResponse = new System.Windows.Forms.Button();
            this.lblAddNewResponse = new System.Windows.Forms.Label();
            this.tutorialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpConversation.SuspendLayout();
            this.grpAddNewResponse.SuspendLayout();
            this.pnlCreateNew.SuspendLayout();
            this.pnlLinkExisting.SuspendLayout();
            this.grpResponses.SuspendLayout();
            this.grpNPC.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpConversation
            // 
            this.grpConversation.Controls.Add(this.btnCancel);
            this.grpConversation.Controls.Add(this.cmbNPCs);
            this.grpConversation.Controls.Add(this.btnSave);
            this.grpConversation.Controls.Add(this.grpAddNewResponse);
            this.grpConversation.Controls.Add(this.grpResponses);
            this.grpConversation.Controls.Add(this.grpNPC);
            this.grpConversation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpConversation.Location = new System.Drawing.Point(0, 0);
            this.grpConversation.Name = "grpConversation";
            this.grpConversation.Size = new System.Drawing.Size(553, 716);
            this.grpConversation.TabIndex = 0;
            this.grpConversation.TabStop = false;
            this.grpConversation.Text = "Conversation";
            this.grpConversation.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(355, 16);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(180, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel Conversation";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbNPCs
            // 
            this.cmbNPCs.FormattingEnabled = true;
            this.cmbNPCs.Location = new System.Drawing.Point(11, 18);
            this.cmbNPCs.Name = "cmbNPCs";
            this.cmbNPCs.Size = new System.Drawing.Size(174, 21);
            this.cmbNPCs.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(191, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(161, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save Conversation";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpAddNewResponse
            // 
            this.grpAddNewResponse.Controls.Add(this.pnlCreateNew);
            this.grpAddNewResponse.Controls.Add(this.pnlLinkExisting);
            this.grpAddNewResponse.Controls.Add(this.rdoCreateNew);
            this.grpAddNewResponse.Controls.Add(this.rdoUseExisting);
            this.grpAddNewResponse.Controls.Add(this.txtResponseID);
            this.grpAddNewResponse.Controls.Add(this.btnAdd);
            this.grpAddNewResponse.Controls.Add(this.chkResponseID);
            this.grpAddNewResponse.Controls.Add(this.lblNewResponse);
            this.grpAddNewResponse.Controls.Add(this.txtResponse);
            this.grpAddNewResponse.Location = new System.Drawing.Point(17, 439);
            this.grpAddNewResponse.Name = "grpAddNewResponse";
            this.grpAddNewResponse.Size = new System.Drawing.Size(518, 272);
            this.grpAddNewResponse.TabIndex = 2;
            this.grpAddNewResponse.TabStop = false;
            this.grpAddNewResponse.Text = "Add New Response";
            this.grpAddNewResponse.Visible = false;
            // 
            // pnlCreateNew
            // 
            this.pnlCreateNew.Controls.Add(this.txtCreateNewStatement);
            this.pnlCreateNew.Controls.Add(this.lblnewStatement);
            this.pnlCreateNew.Location = new System.Drawing.Point(9, 95);
            this.pnlCreateNew.Name = "pnlCreateNew";
            this.pnlCreateNew.Size = new System.Drawing.Size(503, 93);
            this.pnlCreateNew.TabIndex = 9;
            // 
            // txtCreateNewStatement
            // 
            this.txtCreateNewStatement.Location = new System.Drawing.Point(60, 26);
            this.txtCreateNewStatement.Multiline = true;
            this.txtCreateNewStatement.Name = "txtCreateNewStatement";
            this.txtCreateNewStatement.Size = new System.Drawing.Size(437, 58);
            this.txtCreateNewStatement.TabIndex = 6;
            // 
            // lblnewStatement
            // 
            this.lblnewStatement.AutoSize = true;
            this.lblnewStatement.Location = new System.Drawing.Point(9, 10);
            this.lblnewStatement.Name = "lblnewStatement";
            this.lblnewStatement.Size = new System.Drawing.Size(117, 13);
            this.lblnewStatement.TabIndex = 5;
            this.lblnewStatement.Text = "Create New Statement:";
            // 
            // pnlLinkExisting
            // 
            this.pnlLinkExisting.Controls.Add(this.cmbStatements);
            this.pnlLinkExisting.Controls.Add(this.lblStatements);
            this.pnlLinkExisting.Location = new System.Drawing.Point(9, 95);
            this.pnlLinkExisting.Name = "pnlLinkExisting";
            this.pnlLinkExisting.Size = new System.Drawing.Size(503, 87);
            this.pnlLinkExisting.TabIndex = 8;
            // 
            // cmbStatements
            // 
            this.cmbStatements.FormattingEnabled = true;
            this.cmbStatements.Location = new System.Drawing.Point(60, 26);
            this.cmbStatements.Name = "cmbStatements";
            this.cmbStatements.Size = new System.Drawing.Size(437, 21);
            this.cmbStatements.TabIndex = 3;
            // 
            // lblStatements
            // 
            this.lblStatements.AutoSize = true;
            this.lblStatements.Location = new System.Drawing.Point(9, 10);
            this.lblStatements.Name = "lblStatements";
            this.lblStatements.Size = new System.Drawing.Size(97, 13);
            this.lblStatements.TabIndex = 4;
            this.lblStatements.Text = "Existing Statement:";
            // 
            // rdoCreateNew
            // 
            this.rdoCreateNew.AutoSize = true;
            this.rdoCreateNew.Location = new System.Drawing.Point(174, 71);
            this.rdoCreateNew.Name = "rdoCreateNew";
            this.rdoCreateNew.Size = new System.Drawing.Size(132, 17);
            this.rdoCreateNew.TabIndex = 7;
            this.rdoCreateNew.Text = "Create New Statement";
            this.rdoCreateNew.UseVisualStyleBackColor = true;
            // 
            // rdoUseExisting
            // 
            this.rdoUseExisting.AutoSize = true;
            this.rdoUseExisting.Checked = true;
            this.rdoUseExisting.Location = new System.Drawing.Point(21, 71);
            this.rdoUseExisting.Name = "rdoUseExisting";
            this.rdoUseExisting.Size = new System.Drawing.Size(147, 17);
            this.rdoUseExisting.TabIndex = 6;
            this.rdoUseExisting.TabStop = true;
            this.rdoUseExisting.Text = "Link to Existing Statement";
            this.rdoUseExisting.UseVisualStyleBackColor = true;
            this.rdoUseExisting.CheckedChanged += new System.EventHandler(this.rdoUseExisting_CheckedChanged);
            // 
            // txtResponseID
            // 
            this.txtResponseID.Location = new System.Drawing.Point(291, 217);
            this.txtResponseID.Name = "txtResponseID";
            this.txtResponseID.ReadOnly = true;
            this.txtResponseID.Size = new System.Drawing.Size(165, 20);
            this.txtResponseID.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(218, 242);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // chkResponseID
            // 
            this.chkResponseID.AutoSize = true;
            this.chkResponseID.Checked = true;
            this.chkResponseID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkResponseID.Location = new System.Drawing.Point(290, 194);
            this.chkResponseID.Name = "chkResponseID";
            this.chkResponseID.Size = new System.Drawing.Size(166, 17);
            this.chkResponseID.TabIndex = 2;
            this.chkResponseID.Text = "Auto Generate Response ID?";
            this.toolTip1.SetToolTip(this.chkResponseID, "Keep this checked to auto-generate an ID used to link the statements. Or unselect" +
        ", and enter your own unique ID.");
            this.chkResponseID.UseVisualStyleBackColor = true;
            this.chkResponseID.CheckedChanged += new System.EventHandler(this.chkResponseID_CheckedChanged);
            // 
            // lblNewResponse
            // 
            this.lblNewResponse.AutoSize = true;
            this.lblNewResponse.Location = new System.Drawing.Point(6, 25);
            this.lblNewResponse.Name = "lblNewResponse";
            this.lblNewResponse.Size = new System.Drawing.Size(195, 13);
            this.lblNewResponse.TabIndex = 1;
            this.lblNewResponse.Text = "What would you like to say to the NPC?";
            // 
            // txtResponse
            // 
            this.txtResponse.Location = new System.Drawing.Point(9, 44);
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.Size = new System.Drawing.Size(500, 20);
            this.txtResponse.TabIndex = 0;
            this.txtResponse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtResponse_KeyDown);
            // 
            // grpResponses
            // 
            this.grpResponses.Controls.Add(this.lblAddNewResponse);
            this.grpResponses.Controls.Add(this.btnAddNewResponse);
            this.grpResponses.Controls.Add(this.btnDown);
            this.grpResponses.Controls.Add(this.btnUp);
            this.grpResponses.Controls.Add(this.treeReplies);
            this.grpResponses.Location = new System.Drawing.Point(17, 152);
            this.grpResponses.Name = "grpResponses";
            this.grpResponses.Size = new System.Drawing.Size(518, 281);
            this.grpResponses.TabIndex = 1;
            this.grpResponses.TabStop = false;
            this.grpResponses.Text = "You Can Say...";
            // 
            // btnDown
            // 
            this.btnDown.BackgroundImage = global::_7DaysToDialog.Properties.Resources.down_arrow_6;
            this.btnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDown.Location = new System.Drawing.Point(9, 92);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(23, 23);
            this.btnDown.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnDown, "Move the selected response down");
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.BackgroundImage = global::_7DaysToDialog.Properties.Resources.up_arrow_7;
            this.btnUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUp.Location = new System.Drawing.Point(9, 48);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(23, 23);
            this.btnUp.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btnUp, "Move the selected response up");
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // treeReplies
            // 
            this.treeReplies.HideSelection = false;
            this.treeReplies.Location = new System.Drawing.Point(38, 19);
            this.treeReplies.Name = "treeReplies";
            this.treeReplies.Size = new System.Drawing.Size(469, 192);
            this.treeReplies.TabIndex = 0;
            this.treeReplies.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treeReplies_DrawNode);
            this.treeReplies.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeReplies_NodeMouseClick);
            this.treeReplies.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeReplies_NodeMouseDoubleClick);
            // 
            // grpNPC
            // 
            this.grpNPC.Controls.Add(this.rtbStatement);
            this.grpNPC.Location = new System.Drawing.Point(17, 45);
            this.grpNPC.Name = "grpNPC";
            this.grpNPC.Size = new System.Drawing.Size(518, 101);
            this.grpNPC.TabIndex = 0;
            this.grpNPC.TabStop = false;
            this.grpNPC.Text = "NPC Says...";
            // 
            // rtbStatement
            // 
            this.rtbStatement.Location = new System.Drawing.Point(7, 20);
            this.rtbStatement.Name = "rtbStatement";
            this.rtbStatement.Size = new System.Drawing.Size(500, 64);
            this.rtbStatement.TabIndex = 0;
            this.rtbStatement.Text = "";
            // 
            // ResponsesMenu
            // 
            this.ResponsesMenu.Name = "ResponsesMenu";
            this.ResponsesMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // treeDialogs
            // 
            this.treeDialogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeDialogs.HideSelection = false;
            this.treeDialogs.Location = new System.Drawing.Point(0, 37);
            this.treeDialogs.Name = "treeDialogs";
            this.treeDialogs.ShowNodeToolTips = true;
            this.treeDialogs.Size = new System.Drawing.Size(422, 674);
            this.treeDialogs.TabIndex = 1;
            this.treeDialogs.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treeDialogs_DrawNode);
            this.treeDialogs.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeDialogs_AfterSelect);
            this.treeDialogs.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeDialogs_NodeMouseClick);
            this.treeDialogs.Click += new System.EventHandler(this.treeDialogs_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(984, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.closeFileToolStripMenuItem,
            this.toolStripSeparator2,
            this.saveFileToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem,
            this.toolStripSeparator1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dialogToolStripMenuItem,
            this.localizationToolStripMenuItem});
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.openFileToolStripMenuItem.Text = "&Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // dialogToolStripMenuItem
            // 
            this.dialogToolStripMenuItem.Name = "dialogToolStripMenuItem";
            this.dialogToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.dialogToolStripMenuItem.Text = "Dialog...";
            this.dialogToolStripMenuItem.Click += new System.EventHandler(this.dialogToolStripMenuItem_Click);
            // 
            // localizationToolStripMenuItem
            // 
            this.localizationToolStripMenuItem.Name = "localizationToolStripMenuItem";
            this.localizationToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.localizationToolStripMenuItem.Text = "Localization...";
            this.localizationToolStripMenuItem.Click += new System.EventHandler(this.localizationToolStripMenuItem_Click);
            // 
            // closeFileToolStripMenuItem
            // 
            this.closeFileToolStripMenuItem.Name = "closeFileToolStripMenuItem";
            this.closeFileToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.closeFileToolStripMenuItem.Text = "&Close File";
            this.closeFileToolStripMenuItem.Click += new System.EventHandler(this.closeFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(141, 6);
            // 
            // saveFileToolStripMenuItem
            // 
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.saveFileToolStripMenuItem.Text = "Save File As...";
            this.saveFileToolStripMenuItem.Click += new System.EventHandler(this.saveFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(141, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(141, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enabledExtensionsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // enabledExtensionsToolStripMenuItem
            // 
            this.enabledExtensionsToolStripMenuItem.CheckOnClick = true;
            this.enabledExtensionsToolStripMenuItem.Name = "enabledExtensionsToolStripMenuItem";
            this.enabledExtensionsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.enabledExtensionsToolStripMenuItem.Text = "Enabled Extensions";
            this.enabledExtensionsToolStripMenuItem.ToolTipText = "When enabled, additional features from 0-SphereIICore are available.";
            this.enabledExtensionsToolStripMenuItem.CheckedChanged += new System.EventHandler(this.enabledExtensionsToolStripMenuItem_CheckedChanged);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkForUpdateToolStripMenuItem,
            this.tutorialToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // checkForUpdateToolStripMenuItem
            // 
            this.checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
            this.checkForUpdateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.checkForUpdateToolStripMenuItem.Text = "Check For Update";
            this.checkForUpdateToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdateToolStripMenuItem_Click);
            // 
            // btnAddNewNPC
            // 
            this.btnAddNewNPC.Location = new System.Drawing.Point(180, 8);
            this.btnAddNewNPC.Name = "btnAddNewNPC";
            this.btnAddNewNPC.Size = new System.Drawing.Size(102, 23);
            this.btnAddNewNPC.TabIndex = 3;
            this.btnAddNewNPC.Text = "Add New NPC";
            this.btnAddNewNPC.UseVisualStyleBackColor = true;
            this.btnAddNewNPC.Click += new System.EventHandler(this.btnAddNewNPC_Click);
            // 
            // txtAddNewNPC
            // 
            this.txtAddNewNPC.Location = new System.Drawing.Point(8, 8);
            this.txtAddNewNPC.Name = "txtAddNewNPC";
            this.txtAddNewNPC.Size = new System.Drawing.Size(166, 20);
            this.txtAddNewNPC.TabIndex = 4;
            this.txtAddNewNPC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddNewNPC_KeyDown);
            // 
            // DialogsContextMenu
            // 
            this.DialogsContextMenu.Name = "ResponsesMenu";
            this.DialogsContextMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 24);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 718);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblVersion);
            this.splitContainer1.Panel1.Controls.Add(this.treeDialogs);
            this.splitContainer1.Panel1.Controls.Add(this.txtAddNewNPC);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddNewNPC);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grpConversation);
            this.splitContainer1.Size = new System.Drawing.Size(981, 718);
            this.splitContainer1.SplitterDistance = 422;
            this.splitContainer1.TabIndex = 6;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(289, 9);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(48, 13);
            this.lblVersion.TabIndex = 5;
            this.lblVersion.Text = "Version: ";
            // 
            // btnAddNewResponse
            // 
            this.btnAddNewResponse.Location = new System.Drawing.Point(205, 217);
            this.btnAddNewResponse.Name = "btnAddNewResponse";
            this.btnAddNewResponse.Size = new System.Drawing.Size(130, 23);
            this.btnAddNewResponse.TabIndex = 3;
            this.btnAddNewResponse.Text = "Add New Response";
            this.btnAddNewResponse.UseVisualStyleBackColor = true;
            this.btnAddNewResponse.Click += new System.EventHandler(this.btnAddNewResponse_Click);
            // 
            // lblAddNewResponse
            // 
            this.lblAddNewResponse.AutoSize = true;
            this.lblAddNewResponse.Location = new System.Drawing.Point(157, 255);
            this.lblAddNewResponse.Name = "lblAddNewResponse";
            this.lblAddNewResponse.Size = new System.Drawing.Size(210, 13);
            this.lblAddNewResponse.TabIndex = 4;
            this.lblAddNewResponse.Text = "Right click on a Response for more options";
            // 
            // tutorialToolStripMenuItem
            // 
            this.tutorialToolStripMenuItem.Name = "tutorialToolStripMenuItem";
            this.tutorialToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tutorialToolStripMenuItem.Text = "Tutorial";
            this.tutorialToolStripMenuItem.Click += new System.EventHandler(this.tutorialToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 742);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmMain";
            this.Text = "7 Days To Dialog";
            this.grpConversation.ResumeLayout(false);
            this.grpAddNewResponse.ResumeLayout(false);
            this.grpAddNewResponse.PerformLayout();
            this.pnlCreateNew.ResumeLayout(false);
            this.pnlCreateNew.PerformLayout();
            this.pnlLinkExisting.ResumeLayout(false);
            this.pnlLinkExisting.PerformLayout();
            this.grpResponses.ResumeLayout(false);
            this.grpResponses.PerformLayout();
            this.grpNPC.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpConversation;
        private System.Windows.Forms.GroupBox grpAddNewResponse;
        private System.Windows.Forms.CheckBox chkResponseID;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblNewResponse;
        private System.Windows.Forms.TextBox txtResponseID;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.GroupBox grpResponses;
        private System.Windows.Forms.TreeView treeReplies;
        private System.Windows.Forms.GroupBox grpNPC;
        private System.Windows.Forms.RichTextBox rtbStatement;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip ResponsesMenu;
        private System.Windows.Forms.TreeView treeDialogs;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btnAddNewNPC;
        private System.Windows.Forms.TextBox txtAddNewNPC;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbNPCs;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enabledExtensionsToolStripMenuItem;
        private System.Windows.Forms.Label lblStatements;
        private System.Windows.Forms.ComboBox cmbStatements;
        private System.Windows.Forms.ContextMenuStrip DialogsContextMenu;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtCreateNewStatement;
        private System.Windows.Forms.Label lblnewStatement;
        private System.Windows.Forms.RadioButton rdoCreateNew;
        private System.Windows.Forms.RadioButton rdoUseExisting;
        private System.Windows.Forms.Panel pnlCreateNew;
        private System.Windows.Forms.Panel pnlLinkExisting;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem dialogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localizationToolStripMenuItem;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdateToolStripMenuItem;
        private System.Windows.Forms.Label lblAddNewResponse;
        private System.Windows.Forms.Button btnAddNewResponse;
        private System.Windows.Forms.ToolStripMenuItem tutorialToolStripMenuItem;
    }
}

