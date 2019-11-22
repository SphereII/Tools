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
            if(disposing && (components != null))
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
            this.txtSteamPath = new System.Windows.Forms.TextBox();
            this.btLoad = new System.Windows.Forms.Button();
            this.treeDialogs = new System.Windows.Forms.TreeView();
            this.grpDialog = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lstResponses = new System.Windows.Forms.ListBox();
            this.lblDialog = new System.Windows.Forms.Label();
            this.txtStatement = new System.Windows.Forms.RichTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.grpDialog.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSteamPath
            // 
            this.txtSteamPath.Location = new System.Drawing.Point(12, 23);
            this.txtSteamPath.Name = "txtSteamPath";
            this.txtSteamPath.Size = new System.Drawing.Size(429, 20);
            this.txtSteamPath.TabIndex = 0;
            this.txtSteamPath.Text = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\7 Days To Die";
            // 
            // btLoad
            // 
            this.btLoad.Location = new System.Drawing.Point(447, 20);
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(75, 23);
            this.btLoad.TabIndex = 1;
            this.btLoad.Text = "Load";
            this.btLoad.UseVisualStyleBackColor = true;
            this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
            // 
            // treeDialogs
            // 
            this.treeDialogs.Location = new System.Drawing.Point(32, 84);
            this.treeDialogs.Name = "treeDialogs";
            this.treeDialogs.Size = new System.Drawing.Size(409, 408);
            this.treeDialogs.TabIndex = 2;
            this.treeDialogs.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeDialogs_AfterSelect);
            // 
            // grpDialog
            // 
            this.grpDialog.Controls.Add(this.btnDelete);
            this.grpDialog.Controls.Add(this.btnAddNew);
            this.grpDialog.Controls.Add(this.button1);
            this.grpDialog.Controls.Add(this.lstResponses);
            this.grpDialog.Controls.Add(this.lblDialog);
            this.grpDialog.Controls.Add(this.txtStatement);
            this.grpDialog.Location = new System.Drawing.Point(465, 84);
            this.grpDialog.Name = "grpDialog";
            this.grpDialog.Size = new System.Drawing.Size(751, 408);
            this.grpDialog.TabIndex = 3;
            this.grpDialog.TabStop = false;
            this.grpDialog.Text = "Dialog";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Create New Conversation";
            this.toolTip1.SetToolTip(this.button1, "Clear the form and start a new conversation");
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lstResponses
            // 
            this.lstResponses.FormattingEnabled = true;
            this.lstResponses.Location = new System.Drawing.Point(184, 202);
            this.lstResponses.Name = "lstResponses";
            this.lstResponses.Size = new System.Drawing.Size(374, 134);
            this.lstResponses.TabIndex = 2;
            // 
            // lblDialog
            // 
            this.lblDialog.AutoSize = true;
            this.lblDialog.Location = new System.Drawing.Point(181, 16);
            this.lblDialog.Name = "lblDialog";
            this.lblDialog.Size = new System.Drawing.Size(88, 13);
            this.lblDialog.TabIndex = 1;
            this.lblDialog.Text = "Dialog Statement";
            // 
            // txtStatement
            // 
            this.txtStatement.Location = new System.Drawing.Point(184, 37);
            this.txtStatement.Name = "txtStatement";
            this.txtStatement.Size = new System.Drawing.Size(504, 96);
            this.txtStatement.TabIndex = 0;
            this.txtStatement.Text = "";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(184, 173);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(122, 23);
            this.btnAddNew.TabIndex = 4;
            this.btnAddNew.Text = "Add New Response";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(414, 173);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(144, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete Selected Response";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 538);
            this.Controls.Add(this.grpDialog);
            this.Controls.Add(this.treeDialogs);
            this.Controls.Add(this.btLoad);
            this.Controls.Add(this.txtSteamPath);
            this.Name = "frmMain";
            this.Text = "7 Days to Dialog";
            this.grpDialog.ResumeLayout(false);
            this.grpDialog.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSteamPath;
        private System.Windows.Forms.Button btLoad;
        private System.Windows.Forms.TreeView treeDialogs;
        private System.Windows.Forms.GroupBox grpDialog;
        private System.Windows.Forms.Label lblDialog;
        private System.Windows.Forms.RichTextBox txtStatement;
        private System.Windows.Forms.ListBox lstResponses;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddNew;
    }
}

