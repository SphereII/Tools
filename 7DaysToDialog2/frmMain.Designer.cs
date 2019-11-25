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
            this.grpConversation = new System.Windows.Forms.GroupBox();
            this.cmbNPCs = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpAddNewResponse = new System.Windows.Forms.GroupBox();
            this.lblVisibility = new System.Windows.Forms.Label();
            this.cboVisibility = new System.Windows.Forms.ComboBox();
            this.lblOperators = new System.Windows.Forms.Label();
            this.cboOperators = new System.Windows.Forms.ComboBox();
            this.lblRequirements = new System.Windows.Forms.Label();
            this.cboRequirements = new System.Windows.Forms.ComboBox();
            this.lblStatements = new System.Windows.Forms.Label();
            this.cmbStatements = new System.Windows.Forms.ComboBox();
            this.chkResponseID = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblNewResponse = new System.Windows.Forms.Label();
            this.txtResponseID = new System.Windows.Forms.TextBox();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.grpResponses = new System.Windows.Forms.GroupBox();
            this.treeReplies = new System.Windows.Forms.TreeView();
            this.grpNPC = new System.Windows.Forms.GroupBox();
            this.rtbStatement = new System.Windows.Forms.RichTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ResponsesMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.treeDialogs = new System.Windows.Forms.TreeView();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enabledExtensionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddNewNPC = new System.Windows.Forms.Button();
            this.txtAddNewNPC = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpConversation.SuspendLayout();
            this.grpAddNewResponse.SuspendLayout();
            this.grpResponses.SuspendLayout();
            this.grpNPC.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpConversation
            // 
            this.grpConversation.Controls.Add(this.cmbNPCs);
            this.grpConversation.Controls.Add(this.btnSave);
            this.grpConversation.Controls.Add(this.grpAddNewResponse);
            this.grpConversation.Controls.Add(this.grpResponses);
            this.grpConversation.Controls.Add(this.chkResponseID);
            this.grpConversation.Controls.Add(this.grpNPC);
            this.grpConversation.Controls.Add(this.txtResponseID);
            this.grpConversation.Location = new System.Drawing.Point(419, 27);
            this.grpConversation.Name = "grpConversation";
            this.grpConversation.Size = new System.Drawing.Size(750, 607);
            this.grpConversation.TabIndex = 0;
            this.grpConversation.TabStop = false;
            this.grpConversation.Text = "Conversation";
            // 
            // cmbNPCs
            // 
            this.cmbNPCs.FormattingEnabled = true;
            this.cmbNPCs.Location = new System.Drawing.Point(333, 18);
            this.cmbNPCs.Name = "cmbNPCs";
            this.cmbNPCs.Size = new System.Drawing.Size(121, 21);
            this.cmbNPCs.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(460, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpAddNewResponse
            // 
            this.grpAddNewResponse.Controls.Add(this.cboVisibility);
            this.grpAddNewResponse.Controls.Add(this.lblVisibility);
            this.grpAddNewResponse.Controls.Add(this.panel1);
            this.grpAddNewResponse.Controls.Add(this.lblRequirements);
            this.grpAddNewResponse.Controls.Add(this.cboRequirements);
            this.grpAddNewResponse.Controls.Add(this.lblStatements);
            this.grpAddNewResponse.Controls.Add(this.cmbStatements);
            this.grpAddNewResponse.Controls.Add(this.btnAdd);
            this.grpAddNewResponse.Controls.Add(this.lblNewResponse);
            this.grpAddNewResponse.Controls.Add(this.txtResponse);
            this.grpAddNewResponse.Location = new System.Drawing.Point(17, 318);
            this.grpAddNewResponse.Name = "grpAddNewResponse";
            this.grpAddNewResponse.Size = new System.Drawing.Size(718, 283);
            this.grpAddNewResponse.TabIndex = 2;
            this.grpAddNewResponse.TabStop = false;
            this.grpAddNewResponse.Text = "Add New Response";
            // 
            // lblVisibility
            // 
            this.lblVisibility.AutoSize = true;
            this.lblVisibility.Location = new System.Drawing.Point(397, 71);
            this.lblVisibility.Name = "lblVisibility";
            this.lblVisibility.Size = new System.Drawing.Size(127, 13);
            this.lblVisibility.TabIndex = 10;
            this.lblVisibility.Text = "If the requirement is false:";
            // 
            // cboVisibility
            // 
            this.cboVisibility.FormattingEnabled = true;
            this.cboVisibility.Location = new System.Drawing.Point(409, 89);
            this.cboVisibility.Name = "cboVisibility";
            this.cboVisibility.Size = new System.Drawing.Size(77, 21);
            this.cboVisibility.TabIndex = 9;
            // 
            // lblOperators
            // 
            this.lblOperators.AutoSize = true;
            this.lblOperators.Location = new System.Drawing.Point(14, 10);
            this.lblOperators.Name = "lblOperators";
            this.lblOperators.Size = new System.Drawing.Size(249, 13);
            this.lblOperators.TabIndex = 8;
            this.lblOperators.Text = "Extra condition for the operational Value ( operator )";
            // 
            // cboOperators
            // 
            this.cboOperators.FormattingEnabled = true;
            this.cboOperators.Location = new System.Drawing.Point(17, 26);
            this.cboOperators.Name = "cboOperators";
            this.cboOperators.Size = new System.Drawing.Size(221, 21);
            this.cboOperators.TabIndex = 7;
            // 
            // lblRequirements
            // 
            this.lblRequirements.AutoSize = true;
            this.lblRequirements.Location = new System.Drawing.Point(397, 25);
            this.lblRequirements.Name = "lblRequirements";
            this.lblRequirements.Size = new System.Drawing.Size(220, 13);
            this.lblRequirements.TabIndex = 6;
            this.lblRequirements.Text = "Show this Response only when the following:";
            // 
            // cboRequirements
            // 
            this.cboRequirements.FormattingEnabled = true;
            this.cboRequirements.Location = new System.Drawing.Point(409, 43);
            this.cboRequirements.Name = "cboRequirements";
            this.cboRequirements.Size = new System.Drawing.Size(238, 21);
            this.cboRequirements.TabIndex = 5;
            // 
            // lblStatements
            // 
            this.lblStatements.AutoSize = true;
            this.lblStatements.Location = new System.Drawing.Point(7, 71);
            this.lblStatements.Name = "lblStatements";
            this.lblStatements.Size = new System.Drawing.Size(168, 13);
            this.lblStatements.TabIndex = 4;
            this.lblStatements.Text = "Link this response to a statement. ";
            // 
            // cmbStatements
            // 
            this.cmbStatements.FormattingEnabled = true;
            this.cmbStatements.Location = new System.Drawing.Point(7, 89);
            this.cmbStatements.Name = "cmbStatements";
            this.cmbStatements.Size = new System.Drawing.Size(383, 21);
            this.cmbStatements.TabIndex = 3;
            // 
            // chkResponseID
            // 
            this.chkResponseID.AutoSize = true;
            this.chkResponseID.Checked = true;
            this.chkResponseID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkResponseID.Location = new System.Drawing.Point(549, 191);
            this.chkResponseID.Name = "chkResponseID";
            this.chkResponseID.Size = new System.Drawing.Size(166, 17);
            this.chkResponseID.TabIndex = 2;
            this.chkResponseID.Text = "Auto Generate Response ID?";
            this.toolTip1.SetToolTip(this.chkResponseID, "Keep this checked to auto-generate an ID used to link the statements. Or unselect" +
        ", and enter your own unique ID.");
            this.chkResponseID.UseVisualStyleBackColor = true;
            this.chkResponseID.CheckedChanged += new System.EventHandler(this.chkResponseID_CheckedChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(623, 161);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblNewResponse
            // 
            this.lblNewResponse.AutoSize = true;
            this.lblNewResponse.Location = new System.Drawing.Point(4, 25);
            this.lblNewResponse.Name = "lblNewResponse";
            this.lblNewResponse.Size = new System.Drawing.Size(195, 13);
            this.lblNewResponse.TabIndex = 1;
            this.lblNewResponse.Text = "What would you like to say to the NPC?";
            // 
            // txtResponseID
            // 
            this.txtResponseID.Location = new System.Drawing.Point(541, 226);
            this.txtResponseID.Name = "txtResponseID";
            this.txtResponseID.ReadOnly = true;
            this.txtResponseID.Size = new System.Drawing.Size(165, 20);
            this.txtResponseID.TabIndex = 2;
            // 
            // txtResponse
            // 
            this.txtResponse.Location = new System.Drawing.Point(7, 44);
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.Size = new System.Drawing.Size(383, 20);
            this.txtResponse.TabIndex = 0;
            this.txtResponse.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtResponse_KeyUp);
            // 
            // grpResponses
            // 
            this.grpResponses.Controls.Add(this.treeReplies);
            this.grpResponses.Location = new System.Drawing.Point(17, 152);
            this.grpResponses.Name = "grpResponses";
            this.grpResponses.Size = new System.Drawing.Size(518, 160);
            this.grpResponses.TabIndex = 1;
            this.grpResponses.TabStop = false;
            this.grpResponses.Text = "You Can Say...";
            // 
            // treeReplies
            // 
            this.treeReplies.Location = new System.Drawing.Point(7, 19);
            this.treeReplies.Name = "treeReplies";
            this.treeReplies.Size = new System.Drawing.Size(500, 129);
            this.treeReplies.TabIndex = 0;
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
            this.treeDialogs.Location = new System.Drawing.Point(22, 72);
            this.treeDialogs.Name = "treeDialogs";
            this.treeDialogs.ShowNodeToolTips = true;
            this.treeDialogs.Size = new System.Drawing.Size(391, 476);
            this.treeDialogs.TabIndex = 1;
            this.treeDialogs.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeDialogs_AfterSelect);
            this.treeDialogs.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeDialogs_NodeMouseClick);
            this.treeDialogs.Click += new System.EventHandler(this.treeDialogs_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1181, 24);
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
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.openFileToolStripMenuItem.Text = "&Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // closeFileToolStripMenuItem
            // 
            this.closeFileToolStripMenuItem.Name = "closeFileToolStripMenuItem";
            this.closeFileToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.closeFileToolStripMenuItem.Text = "&Close File";
            this.closeFileToolStripMenuItem.Click += new System.EventHandler(this.closeFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(121, 6);
            // 
            // saveFileToolStripMenuItem
            // 
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.saveFileToolStripMenuItem.Text = "Save File";
            this.saveFileToolStripMenuItem.Click += new System.EventHandler(this.saveFileToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enabledExtensionsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
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
            // btnAddNewNPC
            // 
            this.btnAddNewNPC.Location = new System.Drawing.Point(194, 44);
            this.btnAddNewNPC.Name = "btnAddNewNPC";
            this.btnAddNewNPC.Size = new System.Drawing.Size(102, 23);
            this.btnAddNewNPC.TabIndex = 3;
            this.btnAddNewNPC.Text = "Add New NPC";
            this.btnAddNewNPC.UseVisualStyleBackColor = true;
            this.btnAddNewNPC.Click += new System.EventHandler(this.btnAddNewNPC_Click);
            // 
            // txtAddNewNPC
            // 
            this.txtAddNewNPC.Location = new System.Drawing.Point(22, 46);
            this.txtAddNewNPC.Name = "txtAddNewNPC";
            this.txtAddNewNPC.Size = new System.Drawing.Size(166, 20);
            this.txtAddNewNPC.TabIndex = 4;
            this.txtAddNewNPC.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAddNewNPC_KeyUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboOperators);
            this.panel1.Controls.Add(this.lblOperators);
            this.panel1.Location = new System.Drawing.Point(7, 161);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 100);
            this.panel1.TabIndex = 9;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 646);
            this.Controls.Add(this.btnAddNewNPC);
            this.Controls.Add(this.txtAddNewNPC);
            this.Controls.Add(this.treeDialogs);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.grpConversation);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmMain";
            this.Text = "7 Days To Dialog";
            this.grpConversation.ResumeLayout(false);
            this.grpConversation.PerformLayout();
            this.grpAddNewResponse.ResumeLayout(false);
            this.grpAddNewResponse.PerformLayout();
            this.grpResponses.ResumeLayout(false);
            this.grpNPC.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
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
        private System.Windows.Forms.Label lblRequirements;
        private System.Windows.Forms.ComboBox cboRequirements;
        private System.Windows.Forms.Label lblVisibility;
        private System.Windows.Forms.ComboBox cboVisibility;
        private System.Windows.Forms.Label lblOperators;
        private System.Windows.Forms.ComboBox cboOperators;
        private System.Windows.Forms.Panel panel1;
    }
}

