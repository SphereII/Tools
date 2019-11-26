namespace _7DaysToDialog
{
    partial class frmRequirement
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
            this.cboVisibility = new System.Windows.Forms.ComboBox();
            this.lblVisibility = new System.Windows.Forms.Label();
            this.pnlRequirements = new System.Windows.Forms.Panel();
            this.lblOperator = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.cboOperators = new System.Windows.Forms.ComboBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.lblRequirements = new System.Windows.Forms.Label();
            this.cboRequirements = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlRequirements.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboVisibility
            // 
            this.cboVisibility.FormattingEnabled = true;
            this.cboVisibility.Location = new System.Drawing.Point(23, 84);
            this.cboVisibility.Name = "cboVisibility";
            this.cboVisibility.Size = new System.Drawing.Size(365, 21);
            this.cboVisibility.TabIndex = 13;
            // 
            // lblVisibility
            // 
            this.lblVisibility.AutoSize = true;
            this.lblVisibility.Location = new System.Drawing.Point(20, 68);
            this.lblVisibility.Name = "lblVisibility";
            this.lblVisibility.Size = new System.Drawing.Size(245, 13);
            this.lblVisibility.TabIndex = 15;
            this.lblVisibility.Text = "If the requirement is false, do this to the Response:";
            // 
            // pnlRequirements
            // 
            this.pnlRequirements.Controls.Add(this.lblOperator);
            this.pnlRequirements.Controls.Add(this.lblValue);
            this.pnlRequirements.Controls.Add(this.lblID);
            this.pnlRequirements.Controls.Add(this.txtID);
            this.pnlRequirements.Controls.Add(this.cboOperators);
            this.pnlRequirements.Controls.Add(this.txtValue);
            this.pnlRequirements.Location = new System.Drawing.Point(12, 120);
            this.pnlRequirements.Name = "pnlRequirements";
            this.pnlRequirements.Size = new System.Drawing.Size(376, 88);
            this.pnlRequirements.TabIndex = 14;
            // 
            // lblOperator
            // 
            this.lblOperator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOperator.Location = new System.Drawing.Point(5, 28);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(109, 13);
            this.lblOperator.TabIndex = 18;
            this.lblOperator.Text = "operator=";
            this.lblOperator.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblOperator.Visible = false;
            // 
            // lblValue
            // 
            this.lblValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValue.Location = new System.Drawing.Point(5, 53);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(109, 13);
            this.lblValue.TabIndex = 17;
            this.lblValue.Text = "value=";
            this.lblValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValue.Visible = false;
            // 
            // lblID
            // 
            this.lblID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblID.Location = new System.Drawing.Point(13, 5);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(101, 13);
            this.lblID.TabIndex = 16;
            this.lblID.Text = "id=";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblID.Visible = false;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(118, 5);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(212, 20);
            this.txtID.TabIndex = 13;
            this.txtID.Visible = false;
            // 
            // cboOperators
            // 
            this.cboOperators.FormattingEnabled = true;
            this.cboOperators.Location = new System.Drawing.Point(118, 28);
            this.cboOperators.Name = "cboOperators";
            this.cboOperators.Size = new System.Drawing.Size(77, 21);
            this.cboOperators.TabIndex = 7;
            this.cboOperators.Visible = false;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(118, 53);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(212, 20);
            this.txtValue.TabIndex = 11;
            this.txtValue.Visible = false;
            // 
            // lblRequirements
            // 
            this.lblRequirements.AutoSize = true;
            this.lblRequirements.Location = new System.Drawing.Point(20, 19);
            this.lblRequirements.Name = "lblRequirements";
            this.lblRequirements.Size = new System.Drawing.Size(220, 13);
            this.lblRequirements.TabIndex = 12;
            this.lblRequirements.Text = "Show this Response only when the following:";
            // 
            // cboRequirements
            // 
            this.cboRequirements.FormattingEnabled = true;
            this.cboRequirements.Location = new System.Drawing.Point(23, 35);
            this.cboRequirements.Name = "cboRequirements";
            this.cboRequirements.Size = new System.Drawing.Size(365, 21);
            this.cboRequirements.TabIndex = 11;
            this.cboRequirements.SelectedIndexChanged += new System.EventHandler(this.cboRequirements_SelectedIndexChanged);
            this.cboRequirements.SelectionChangeCommitted += new System.EventHandler(this.cboRequirements_SelectionChangeCommitted);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(100, 214);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(267, 214);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmRequirement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 248);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboVisibility);
            this.Controls.Add(this.lblVisibility);
            this.Controls.Add(this.pnlRequirements);
            this.Controls.Add(this.lblRequirements);
            this.Controls.Add(this.cboRequirements);
            this.Name = "frmRequirement";
            this.Text = "Add Requirement";
            this.pnlRequirements.ResumeLayout(false);
            this.pnlRequirements.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboVisibility;
        private System.Windows.Forms.Label lblVisibility;
        private System.Windows.Forms.Panel pnlRequirements;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.ComboBox cboOperators;
        private System.Windows.Forms.Label lblRequirements;
        private System.Windows.Forms.ComboBox cboRequirements;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblOperator;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}