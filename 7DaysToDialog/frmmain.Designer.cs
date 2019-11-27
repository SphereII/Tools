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
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbNPCs = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpAddNewResponse = new System.Windows.Forms.GroupBox();
            this.lblStatements = new System.Windows.Forms.Label();
            this.cmbStatements = new System.Windows.Forms.ComboBox();
            this.txtResponseID = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.chkResponseID = new System.Windows.Forms.CheckBox();
            this.lblNewResponse = new System.Windows.Forms.Label();
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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enabledExtensionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddNewNPC = new System.Windows.Forms.Button();
            this.txtAddNewNPC = new System.Windows.Forms.TextBox();
            this.DialogsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.grpConversation.SuspendLayout();
            this.grpAddNewResponse.SuspendLayout();
            this.grpResponses.SuspendLayout();
            this.grpNPC.SuspendLayout();
            this.menuStrip.SuspendLayout();
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
            this.grpConversation.Location = new System.Drawing.Point(419, 27);
            this.grpConversation.Name = "grpConversation";
            this.grpConversation.Size = new System.Drawing.Size(552, 544);
            this.grpConversation.TabIndex = 0;
            this.grpConversation.TabStop = false;
            this.grpConversation.Text = "Conversation";
            this.grpConversation.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(87, 19);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.btnSave.Location = new System.Drawing.Point(6, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpAddNewResponse
            // 
            this.grpAddNewResponse.Controls.Add(this.lblStatements);
            this.grpAddNewResponse.Controls.Add(this.cmbStatements);
            this.grpAddNewResponse.Controls.Add(this.txtResponseID);
            this.grpAddNewResponse.Controls.Add(this.btnAdd);
            this.grpAddNewResponse.Controls.Add(this.chkResponseID);
            this.grpAddNewResponse.Controls.Add(this.lblNewResponse);
            this.grpAddNewResponse.Controls.Add(this.txtResponse);
            this.grpAddNewResponse.Location = new System.Drawing.Point(17, 318);
            this.grpAddNewResponse.Name = "grpAddNewResponse";
            this.grpAddNewResponse.Size = new System.Drawing.Size(518, 218);
            this.grpAddNewResponse.TabIndex = 2;
            this.grpAddNewResponse.TabStop = false;
            this.grpAddNewResponse.Text = "Add New Response";
            // 
            // lblStatements
            // 
            this.lblStatements.AutoSize = true;
            this.lblStatements.Location = new System.Drawing.Point(4, 142);
            this.lblStatements.Name = "lblStatements";
            this.lblStatements.Size = new System.Drawing.Size(168, 13);
            this.lblStatements.TabIndex = 4;
            this.lblStatements.Text = "Link this response to a statement. ";
            // 
            // cmbStatements
            // 
            this.cmbStatements.FormattingEnabled = true;
            this.cmbStatements.Location = new System.Drawing.Point(0, 158);
            this.cmbStatements.Name = "cmbStatements";
            this.cmbStatements.Size = new System.Drawing.Size(498, 21);
            this.cmbStatements.TabIndex = 3;
            // 
            // txtResponseID
            // 
            this.txtResponseID.Location = new System.Drawing.Point(7, 93);
            this.txtResponseID.Name = "txtResponseID";
            this.txtResponseID.ReadOnly = true;
            this.txtResponseID.Size = new System.Drawing.Size(165, 20);
            this.txtResponseID.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(210, 185);
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
            this.chkResponseID.Location = new System.Drawing.Point(9, 70);
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
            this.treeDialogs.HideSelection = false;
            this.treeDialogs.Location = new System.Drawing.Point(22, 72);
            this.treeDialogs.Name = "treeDialogs";
            this.treeDialogs.ShowNodeToolTips = true;
            this.treeDialogs.Size = new System.Drawing.Size(391, 499);
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
            this.settingsToolStripMenuItem});
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
            this.txtAddNewNPC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddNewNPC_KeyDown);
            // 
            // DialogsContextMenu
            // 
            this.DialogsContextMenu.Name = "ResponsesMenu";
            this.DialogsContextMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 589);
            this.Controls.Add(this.btnAddNewNPC);
            this.Controls.Add(this.txtAddNewNPC);
            this.Controls.Add(this.treeDialogs);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.grpConversation);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmMain";
            this.Text = "7 Days To Dialog";
            this.grpConversation.ResumeLayout(false);
            this.grpAddNewResponse.ResumeLayout(false);
            this.grpAddNewResponse.PerformLayout();
            this.grpResponses.ResumeLayout(false);
            this.grpNPC.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
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
    }
}

