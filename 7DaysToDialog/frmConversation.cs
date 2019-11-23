using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _7DaysToDialog
{
    public partial class frmConversation : Form
    {
        public frmConversation()
        {
            InitializeComponent();
            //Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            //graph.AddEdge("A", "B");
            //graph.AddEdge("B", "C");
            //graph.AddEdge("A", "C").Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
            //graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
            //graph.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
            //Microsoft.Msagl.Drawing.Node c = graph.FindNode("C");
            //c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
            //c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;
            ////bind the graph to the viewer 
            //viewer.Graph = graph;
            ////associate the viewer with the form 
            //viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.Controls.Add(viewer);
        }

        private void btnNewConversation_Click(object sender, EventArgs e)
        {
            //Button newButton = new Button();
            //newButton.Text = "Woo";
            //this.flowLayoutPanel1.Controls.Add(newButton);
        }
    }
}
