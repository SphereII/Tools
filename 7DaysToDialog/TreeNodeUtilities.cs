using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace _7DaysToDialog
{
    public class TreeNodeUtilities
    {

        public static void PopulateStatements(TreeView tree)
        {
            tree.Nodes.Clear();
            List<String> Filter = new List<string>();
            Filter.Add("response");
            Filter.Add("quest_entry");
            Filter.Add("comment");
            AddTreeViewChildNodes(tree.Nodes, Utilities.doc.DocumentElement, Filter);
        }

        public static void AddTreeViewChildNodes(
        TreeNodeCollection parent_nodes, XmlNode xml_node, List<String> Filter = null)
        {
            foreach(XmlNode child_node in xml_node.ChildNodes)
            {
                bool filter = false;
                String strDisplay;
                //if(Filter != null)
                //{
                //    foreach(String strFilter in Filter)
                //        if(child_node.Name.Contains(strFilter))
                //            filter = true;
                //}

                if(filter)
                    continue;
                if(child_node.Attributes == null)
                    continue;
                if ( child_node.Attributes["text"] != null )
                    strDisplay = child_node.Name + " ( " + child_node.Attributes["text"].Value + " )";
                if(child_node.Attributes["id"] != null)
                    strDisplay = child_node.Name + " ( " + child_node.Attributes["id"].Value + " )";
                else
                    strDisplay = child_node.Name;


                // Make the new TreeView node.
                TreeNode new_node = parent_nodes.Add(strDisplay);
                new_node.Tag = child_node;
                // Recursively make this node's descendants.
                AddTreeViewChildNodes(new_node.Nodes, child_node, Filter);

                // If this is a leaf node, make sure it's visible.
                if(new_node.Nodes.Count == 0)
                    new_node.EnsureVisible();
            }
        }

        public static void ParseStatment(TreeView tree, XmlDocument doc, XmlNode node)
        {
            tree.Nodes.Clear();
            //foreach(XmlNode response_entry in node.SelectNodes( strFilterXPath + "/statement[@id='" +node.Attributes["id"].Value + "']/response_entry"))
            foreach( XmlNode response_entry in node.ChildNodes)
            {
                String strFilterXPath = String.Format("/dialogs/dialog[@id='{0}']/response[@id='{1}']", node.ParentNode.Attributes["id"].Value, response_entry.Attributes["id"].Value);

                foreach(XmlNode response in doc.SelectNodes( strFilterXPath))
                {
                    AddTreeViewChildNodes(tree.Nodes, response);
                }
            }
        }
    }
}
