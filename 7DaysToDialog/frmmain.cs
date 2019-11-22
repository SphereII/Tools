using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace _7DaysToDialog
{
    public partial class frmMain : Form
    {
        public static XmlDocument Dialogs = new XmlDocument();
        String strSteam = "";
        String strConfig = "";
        public frmMain()
        {
            InitializeComponent();

        }


        private void btLoad_Click(object sender, EventArgs e)
        {
            if(Directory.Exists(txtSteamPath.Text))
            {
                strSteam = txtSteamPath.Text;
                strConfig = Path.Combine(strSteam, "Data", "Config");

                if(File.Exists(Path.Combine(strConfig, "dialogs.xml")))
                {
                    XmlFile xmlFile = new XmlFile(strConfig, "dialogs.xml");
                    Utilities.doc.Load(Path.Combine(strConfig, "dialogs.xml"));
                    TreeNodeUtilities.PopulateStatements(treeDialogs);
                }
            }
        }

        public void GenerateStatements()
        {
            foreach(XmlNode node in Dialogs)
            {

            }
        }
        private void treeDialogs_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Tag != null)
            {
                if(e.Node.Text.Contains("statement"))
                {
                    XmlNode xml = e.Node.Tag as XmlNode;
                    Statement statement = Utilities.GenerateStatement(xml);
                    DisplayStatements(statement);
                }
            }
        }

        public void DisplayStatements(Statement currentStatement)
        {
            this.lstResponses.Items.Clear();
            this.txtStatement.Text = currentStatement.Text;
            foreach(KeyValuePair<string,  Response> response in currentStatement.Responses)
            {
                ListBoxItem item = new ListBoxItem();
                this.lstResponses.Items.Add(response.Value.Text);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtStatement.Text = "";
            this.lstResponses.Items.Clear();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmNewResponse newResponse = new frmNewResponse();
            newResponse.ShowDialog();
        }
    }

    public class ListBoxItem
    {
        public string Text
        {
            get; set;
        }
        public object Value
        {
            get; set;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
