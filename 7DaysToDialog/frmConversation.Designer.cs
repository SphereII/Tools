namespace _7DaysToDialog
{
    partial class frmConversation
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
            this.btnNewConversation = new System.Windows.Forms.Button();
            this.diagramView1 = new MindFusion.Diagramming.WinForms.DiagramView();
            this.diagram1 = new MindFusion.Diagramming.Diagram();
            this.shapeListBox1 = new MindFusion.Diagramming.WinForms.ShapeListBox();
            this.shapeToolBar1 = new MindFusion.Diagramming.WinForms.ShapeToolBar();
            this.SuspendLayout();
            // 
            // btnNewConversation
            // 
            this.btnNewConversation.Location = new System.Drawing.Point(12, 39);
            this.btnNewConversation.Name = "btnNewConversation";
            this.btnNewConversation.Size = new System.Drawing.Size(122, 23);
            this.btnNewConversation.TabIndex = 1;
            this.btnNewConversation.Text = "New";
            this.btnNewConversation.UseVisualStyleBackColor = true;
            this.btnNewConversation.Click += new System.EventHandler(this.btnNewConversation_Click);
            // 
            // diagramView1
            // 
            this.diagramView1.AllowDrop = true;
            this.diagramView1.Diagram = this.diagram1;
            this.diagramView1.LicenseKey = null;
            this.diagramView1.Location = new System.Drawing.Point(246, 39);
            this.diagramView1.Name = "diagramView1";
            this.diagramView1.Size = new System.Drawing.Size(830, 475);
            this.diagramView1.TabIndex = 2;
            this.diagramView1.Text = "diagramView1";
            // 
            // diagram1
            // 
            this.diagram1.TouchThreshold = 0F;
            // 
            // shapeListBox1
            // 
            this.shapeListBox1.FormattingEnabled = true;
            this.shapeListBox1.Location = new System.Drawing.Point(12, 69);
            this.shapeListBox1.Name = "shapeListBox1";
            this.shapeListBox1.Size = new System.Drawing.Size(228, 421);
            this.shapeListBox1.TabIndex = 3;
            // 
            // shapeToolBar1
            // 
            this.shapeToolBar1.DropDownArrows = true;
            this.shapeToolBar1.Location = new System.Drawing.Point(0, 0);
            this.shapeToolBar1.Name = "shapeToolBar1";
            this.shapeToolBar1.Shapes = null;
            this.shapeToolBar1.ShowToolTips = true;
            this.shapeToolBar1.Size = new System.Drawing.Size(1101, 42);
            this.shapeToolBar1.TabIndex = 4;
            // 
            // frmConversation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 526);
            this.Controls.Add(this.shapeToolBar1);
            this.Controls.Add(this.shapeListBox1);
            this.Controls.Add(this.diagramView1);
            this.Controls.Add(this.btnNewConversation);
            this.Name = "frmConversation";
            this.Text = "frmConversation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnNewConversation;
        private MindFusion.Diagramming.WinForms.DiagramView diagramView1;
        private MindFusion.Diagramming.Diagram diagram1;
        private MindFusion.Diagramming.WinForms.ShapeListBox shapeListBox1;
        private MindFusion.Diagramming.WinForms.ShapeToolBar shapeToolBar1;
    }
}