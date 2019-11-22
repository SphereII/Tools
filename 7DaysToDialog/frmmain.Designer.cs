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
            this.txtSteamPath = new System.Windows.Forms.TextBox();
            this.btLoad = new System.Windows.Forms.Button();
            this.treeDialogs = new System.Windows.Forms.TreeView();
            this.grpDialog = new System.Windows.Forms.GroupBox();
            this.lblDialog = new System.Windows.Forms.Label();
            this.txtStatement = new System.Windows.Forms.RichTextBox();
            this.lstResponses = new System.Windows.Forms.ListBox();
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
            this.treeDialogs.Size = new System.Drawing.Size(804, 408);
            this.treeDialogs.TabIndex = 2;
            this.treeDialogs.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeDialogs_AfterSelect);
            // 
            // grpDialog
            // 
            this.grpDialog.Controls.Add(this.lstResponses);
            this.grpDialog.Controls.Add(this.lblDialog);
            this.grpDialog.Controls.Add(this.txtStatement);
            this.grpDialog.Location = new System.Drawing.Point(859, 84);
            this.grpDialog.Name = "grpDialog";
            this.grpDialog.Size = new System.Drawing.Size(445, 408);
            this.grpDialog.TabIndex = 3;
            this.grpDialog.TabStop = false;
            this.grpDialog.Text = "Dialog";
            // 
            // lblDialog
            // 
            this.lblDialog.AutoSize = true;
            this.lblDialog.Location = new System.Drawing.Point(326, 23);
            this.lblDialog.Name = "lblDialog";
            this.lblDialog.Size = new System.Drawing.Size(88, 13);
            this.lblDialog.TabIndex = 1;
            this.lblDialog.Text = "Dialog Statement";
            // 
            // txtStatement
            // 
            this.txtStatement.Location = new System.Drawing.Point(40, 39);
            this.txtStatement.Name = "txtStatement";
            this.txtStatement.Size = new System.Drawing.Size(374, 96);
            this.txtStatement.TabIndex = 0;
            this.txtStatement.Text = "";
            // 
            // lstResponses
            // 
            this.lstResponses.FormattingEnabled = true;
            this.lstResponses.Location = new System.Drawing.Point(40, 257);
            this.lstResponses.Name = "lstResponses";
            this.lstResponses.Size = new System.Drawing.Size(374, 95);
            this.lstResponses.TabIndex = 2;
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
    }
}

