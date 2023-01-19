using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //create root
            var root = new TreeNode() { Text = "C:", Tag = "c:\\" };
            treeView1.Nodes.Add(root);
            Build(root);

            //expand root
            root.Expand();
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }
        private void Build(TreeNode parent)
        {
            var path = parent.Tag as string;
            parent.Nodes.Clear();

            foreach (var dir in Directory.GetDirectories(path))parent.Nodes.Add(new TreeNode(Path.GetFileName(dir), new[] { new TreeNode("...") }) { Tag = dir });

            foreach (var file in Directory.GetFiles(path))parent.Nodes.Add(new TreeNode(Path.GetFileName(file), 1, 1) { Tag = file });
            
        }
        private void tvFiles_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            Build(e.Node);
        }
    }
}
