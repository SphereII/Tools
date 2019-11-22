namespace _7DaysToDialog
{
    partial class frmNewResponse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewResponse));
            this.cboRequirement = new System.Windows.Forms.ComboBox();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.lblResponseID = new System.Windows.Forms.Label();
            this.lstRequirements = new System.Windows.Forms.ListBox();
            this.grpAddRequirement = new System.Windows.Forms.GroupBox();
            this.cboVisibility = new System.Windows.Forms.ComboBox();
            this.lblrequirementType = new System.Windows.Forms.Label();
            this.lblVisibility = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.btnAddRequirement = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.grpRequirements = new System.Windows.Forms.GroupBox();
            this.txtHelp = new System.Windows.Forms.RichTextBox();
            this.cboOperator = new System.Windows.Forms.ComboBox();
            this.lblOperator = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDisplay = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.grpAddRequirement.SuspendLayout();
            this.grpRequirements.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboRequirement
            // 
            this.cboRequirement.FormattingEnabled = true;
            this.cboRequirement.Location = new System.Drawing.Point(18, 45);
            this.cboRequirement.Name = "cboRequirement";
            this.cboRequirement.Size = new System.Drawing.Size(236, 21);
            this.cboRequirement.TabIndex = 0;
            // 
            // txtResponse
            // 
            this.txtResponse.Location = new System.Drawing.Point(12, 30);
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.Size = new System.Drawing.Size(219, 20);
            this.txtResponse.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtResponse, "This is a unique identifer for this response.");
            // 
            // lblResponseID
            // 
            this.lblResponseID.AutoSize = true;
            this.lblResponseID.Location = new System.Drawing.Point(9, 14);
            this.lblResponseID.Name = "lblResponseID";
            this.lblResponseID.Size = new System.Drawing.Size(69, 13);
            this.lblResponseID.TabIndex = 2;
            this.lblResponseID.Text = "Response ID";
            // 
            // lstRequirements
            // 
            this.lstRequirements.FormattingEnabled = true;
            this.lstRequirements.Location = new System.Drawing.Point(12, 26);
            this.lstRequirements.Name = "lstRequirements";
            this.lstRequirements.Size = new System.Drawing.Size(293, 134);
            this.lstRequirements.TabIndex = 3;
            // 
            // grpAddRequirement
            // 
            this.grpAddRequirement.Controls.Add(this.textBox1);
            this.grpAddRequirement.Controls.Add(this.label2);
            this.grpAddRequirement.Controls.Add(this.lblOperator);
            this.grpAddRequirement.Controls.Add(this.cboOperator);
            this.grpAddRequirement.Controls.Add(this.btnAddRequirement);
            this.grpAddRequirement.Controls.Add(this.txtValue);
            this.grpAddRequirement.Controls.Add(this.label1);
            this.grpAddRequirement.Controls.Add(this.lblVisibility);
            this.grpAddRequirement.Controls.Add(this.lblrequirementType);
            this.grpAddRequirement.Controls.Add(this.cboVisibility);
            this.grpAddRequirement.Controls.Add(this.cboRequirement);
            this.grpAddRequirement.Location = new System.Drawing.Point(12, 125);
            this.grpAddRequirement.Name = "grpAddRequirement";
            this.grpAddRequirement.Size = new System.Drawing.Size(278, 483);
            this.grpAddRequirement.TabIndex = 5;
            this.grpAddRequirement.TabStop = false;
            this.grpAddRequirement.Text = "Add Requirement";
            // 
            // cboVisibility
            // 
            this.cboVisibility.FormattingEnabled = true;
            this.cboVisibility.Location = new System.Drawing.Point(9, 236);
            this.cboVisibility.Name = "cboVisibility";
            this.cboVisibility.Size = new System.Drawing.Size(245, 21);
            this.cboVisibility.TabIndex = 1;
            // 
            // lblrequirementType
            // 
            this.lblrequirementType.AutoSize = true;
            this.lblrequirementType.Location = new System.Drawing.Point(15, 29);
            this.lblrequirementType.Name = "lblrequirementType";
            this.lblrequirementType.Size = new System.Drawing.Size(118, 13);
            this.lblrequirementType.TabIndex = 2;
            this.lblrequirementType.Text = "Pick a requirement type";
            // 
            // lblVisibility
            // 
            this.lblVisibility.AutoSize = true;
            this.lblVisibility.Location = new System.Drawing.Point(6, 220);
            this.lblVisibility.Name = "lblVisibility";
            this.lblVisibility.Size = new System.Drawing.Size(237, 13);
            this.lblVisibility.TabIndex = 3;
            this.lblVisibility.Text = "What happens when the requirement is not true?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Enter a value";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(18, 130);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(236, 20);
            this.txtValue.TabIndex = 6;
            // 
            // btnAddRequirement
            // 
            this.btnAddRequirement.Location = new System.Drawing.Point(101, 284);
            this.btnAddRequirement.Name = "btnAddRequirement";
            this.btnAddRequirement.Size = new System.Drawing.Size(75, 23);
            this.btnAddRequirement.TabIndex = 7;
            this.btnAddRequirement.Text = "Add";
            this.btnAddRequirement.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(88, 166);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(135, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete Selected";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.button1_Click);
            // 
            // grpRequirements
            // 
            this.grpRequirements.Controls.Add(this.lstRequirements);
            this.grpRequirements.Controls.Add(this.btnDelete);
            this.grpRequirements.Location = new System.Drawing.Point(296, 242);
            this.grpRequirements.Name = "grpRequirements";
            this.grpRequirements.Size = new System.Drawing.Size(305, 195);
            this.grpRequirements.TabIndex = 9;
            this.grpRequirements.TabStop = false;
            this.grpRequirements.Text = "Requirements";
            // 
            // txtHelp
            // 
            this.txtHelp.Location = new System.Drawing.Point(632, 30);
            this.txtHelp.Name = "txtHelp";
            this.txtHelp.ReadOnly = true;
            this.txtHelp.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtHelp.Size = new System.Drawing.Size(396, 252);
            this.txtHelp.TabIndex = 10;
            this.txtHelp.Text = resources.GetString("txtHelp.Text");
            // 
            // cboOperator
            // 
            this.cboOperator.FormattingEnabled = true;
            this.cboOperator.Location = new System.Drawing.Point(18, 186);
            this.cboOperator.Name = "cboOperator";
            this.cboOperator.Size = new System.Drawing.Size(236, 21);
            this.cboOperator.TabIndex = 8;
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.Location = new System.Drawing.Point(15, 170);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(96, 13);
            this.lblOperator.TabIndex = 9;
            this.lblOperator.Text = "Operator (Optional)";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(18, 91);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(236, 20);
            this.textBox1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Enter an ID ( Identifier )";
            // 
            // txtDisplay
            // 
            this.txtDisplay.AutoSize = true;
            this.txtDisplay.Location = new System.Drawing.Point(9, 70);
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.Size = new System.Drawing.Size(28, 13);
            this.txtDisplay.TabIndex = 12;
            this.txtDisplay.Text = "Text";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 86);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(486, 20);
            this.textBox2.TabIndex = 11;
            // 
            // frmNewResponse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 620);
            this.Controls.Add(this.txtDisplay);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtHelp);
            this.Controls.Add(this.grpRequirements);
            this.Controls.Add(this.grpAddRequirement);
            this.Controls.Add(this.lblResponseID);
            this.Controls.Add(this.txtResponse);
            this.Name = "frmNewResponse";
            this.Text = "frmNewResponse";
            this.grpAddRequirement.ResumeLayout(false);
            this.grpAddRequirement.PerformLayout();
            this.grpRequirements.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboRequirement;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.Label lblResponseID;
        private System.Windows.Forms.ListBox lstRequirements;
        private System.Windows.Forms.GroupBox grpAddRequirement;
        private System.Windows.Forms.ComboBox cboVisibility;
        private System.Windows.Forms.Label lblVisibility;
        private System.Windows.Forms.Label lblrequirementType;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddRequirement;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cboOperator;
        private System.Windows.Forms.GroupBox grpRequirements;
        private System.Windows.Forms.RichTextBox txtHelp;
        private System.Windows.Forms.Label lblOperator;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtDisplay;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}