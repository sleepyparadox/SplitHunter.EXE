using SplitHunter.EXE.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplitHunter.EXE.Editor
{
    public class SplitTreeEditor
    {
        public Splits Value { get; set; }
        TreeView _treeView;

        public SplitTreeEditor(TreeView treeView)
        {
            _treeView = treeView;
        }

        
        public void Refresh()
        {
            _treeView.Nodes.Clear();

            if (Value == null)
            {
                _treeView.Visible = false;
                return;
            }
            _treeView.Visible = true;

            if (Value.Any())
            {
                foreach(var split in Value)
                {
                    var splitNode = new TreeNode(split.Name);
                    {
                        splitNode.Nodes.Add("Name: " + split.Name);
                        splitNode.Nodes.Add("Best: " + split.Best.NullableToString());
                        splitNode.Nodes.Add("Current: " + split.Current.NullableToString());
                    }

                    _treeView.Nodes.Add(splitNode);
                }
            }
            else
            {
                _treeView.Nodes.Add(new TreeNode("//empty"));
            }
        }
    }
}
