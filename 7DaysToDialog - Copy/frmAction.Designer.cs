namespace _7DaysToDialog
{
    partial class frmAction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAction));
            this.lblPerformAction = new System.Windows.Forms.Label();
            this.cboActions = new System.Windows.Forms.ComboBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblText = new System.Windows.Forms.Label();
            this.rtHelp = new System.Windows.Forms.RichTextBox();
            this.cboOperators = new System.Windows.Forms.ComboBox();
            this.lblOperator = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblPerformAction
            // 
            this.lblPerformAction.AutoSize = true;
            this.lblPerformAction.Location = new System.Drawing.Point(12, 9);
            this.lblPerformAction.Name = "lblPerformAction";
            this.lblPerformAction.Size = new System.Drawing.Size(95, 13);
            this.lblPerformAction.TabIndex = 18;
            this.lblPerformAction.Text = "Peform this Action:";
            // 
            // cboActions
            // 
            this.cboActions.FormattingEnabled = true;
            this.cboActions.Location = new System.Drawing.Point(113, 6);
            this.cboActions.Name = "cboActions";
            this.cboActions.Size = new System.Drawing.Size(365, 21);
            this.cboActions.TabIndex = 17;
            this.cboActions.SelectionChangeCommitted += new System.EventHandler(this.cboActions_SelectionChangeCommitted);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(113, 68);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(140, 20);
            this.txtID.TabIndex = 19;
            this.txtID.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(178, 125);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(74, 125);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblText
            // 
            this.lblText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblText.Location = new System.Drawing.Point(21, 75);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(86, 13);
            this.lblText.TabIndex = 23;
            this.lblText.Text = "ID =";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblText.Visible = false;
            // 
            // rtHelp
            // 
            this.rtHelp.Location = new System.Drawing.Point(274, 44);
            this.rtHelp.Name = "rtHelp";
            this.rtHelp.ReadOnly = true;
            this.rtHelp.Size = new System.Drawing.Size(204, 96);
            this.rtHelp.TabIndex = 24;
            this.rtHelp.Text = "";
            // 
            // cboOperators
            // 
            this.cboOperators.FormattingEnabled = true;
            this.cboOperators.Location = new System.Drawing.Point(113, 37);
            this.cboOperators.Name = "cboOperators";
            this.cboOperators.Size = new System.Drawing.Size(140, 21);
            this.cboOperators.TabIndex = 25;
            // 
            // lblOperator
            // 
            this.lblOperator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOperator.Location = new System.Drawing.Point(21, 45);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(86, 13);
            this.lblOperator.TabIndex = 26;
            this.lblOperator.Text = "Operator:";
            this.lblOperator.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblOperator.Visible = false;
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.Location = new System.Drawing.Point(21, 101);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(86, 13);
            this.lblCount.TabIndex = 28;
            this.lblCount.Text = "Count  =";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCount.Visible = false;
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(113, 94);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(140, 20);
            this.txtCount.TabIndex = 27;
            this.txtCount.Visible = false;
            // 
            // frmAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 180);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.lblOperator);
            this.Controls.Add(this.cboOperators);
            this.Controls.Add(this.rtHelp);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblPerformAction);
            this.Controls.Add(this.cboActions);
            this.Controls.Add(this.txtID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAction";
            this.Text = "Add Action";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPerformAction;
        private System.Windows.Forms.ComboBox cboActions;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.RichTextBox rtHelp;
        private System.Windows.Forms.ComboBox cboOperators;
        private System.Windows.Forms.Label lblOperator;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox txtCount;
    }
}