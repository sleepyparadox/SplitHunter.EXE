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
    public delegate bool TryEditEventArgs(string input);
    public class SplitTreeEditor
    {
        public Splits Value { get; set; }
        Dictionary<Split, SplitNode> _splitToNodeMapping = new Dictionary<Split, SplitNode>();

        TreeView _treeView;
        TextBox _editText;
        Label _editLabel;

        EditableNode _editingNode;
        SplitEditor _parent;

        public SplitTreeEditor(TreeView treeView, TextBox editText, Label editLabel,  SplitEditor parent)
        {
            //This is getting out of control, SplitTreeEditor should probably be a UserControl
            _parent = parent;
            _treeView = treeView;
           

           _treeView.Parent.Controls.Remove(editLabel);
            _treeView.Controls.Add(editLabel);

            _treeView.Parent.Controls.Remove(editText);
            _treeView.Controls.Add(editText);

            _editLabel = editLabel;
            _editText = editText;

            _editLabel.Visible = false;
            _editText.Visible = false;

            _treeView.DoubleClick += NodeSelectionChanged;
            _treeView.Click += (o, e) => TryApplyEditChanges();

            _editText.KeyPress += CheckForEnterKey;
        }

        public Split GetSelectedSplit()
        {
            if (_treeView.SelectedNode == null)
                return null;

            //If split property node, select parent
            if (_treeView.SelectedNode is EditableNode
                && _treeView.SelectedNode.Parent != null)
            {
                _treeView.SelectedNode = _treeView.SelectedNode.Parent;
            }

            if (_treeView.SelectedNode is SplitNode)
            {
                return (_treeView.SelectedNode as SplitNode).Split;
            }
            
            return null;
        }

        private void CheckForEnterKey(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                TryApplyEditChanges();
            }
        }

        public void Render()
        {
            if (Value == null)
            {
                _treeView.Visible = false;
                return;
            }
            _treeView.Visible = true;

            for (var index = 0; index < Value.Count; index++)
            {
                var split = Value[index];
                SplitNode splitNode;
                if (_splitToNodeMapping.ContainsKey(split))
                {
                    splitNode = _splitToNodeMapping[split];
                }
                else
                {
                    splitNode = new SplitNode(split);
                    _splitToNodeMapping.Add(split, splitNode);
                }

                //Update text
                splitNode.Render();

                if (index < _treeView.Nodes.Count
                    && _treeView.Nodes[index] == splitNode)
                {
                    //Already in place
                    continue;
                }

                if (_treeView.Nodes.Contains(splitNode))
                {
                    //In wrong place
                    _treeView.Nodes.Remove(splitNode);
                }

                //Insert correct spot
                _treeView.Nodes.Insert(index, splitNode);
            }

            //Remove excess nodes
            while(_treeView.Nodes.Count > Value.Count)
            {
                _treeView.Nodes.RemoveAt(_treeView.Nodes.Count - 1);
            }

            //Remove deleted split bindings
            var keysToRemove = _splitToNodeMapping.Keys.Where(key => !Value.Contains(key)).ToList();
            foreach(var key in keysToRemove)
            {
                _splitToNodeMapping.Remove(key);
            }

            if(_treeView.Nodes.Count == 0)
            {
                _treeView.Nodes.Add(new TreeNode("//empty"));
            }
        }

        public void TryApplyEditChanges()
        {
            if (_editingNode != null)
            {
                if (_editingNode.Value != _editText.Text
                    && _editingNode.OnTextChanged != null
                    && _editingNode.OnTextChanged(_editText.Text))
                {
                    _editingNode.Value = _editText.Text;
                    Value.Dirty = true;
                    _parent.Render();
                }

                _editingNode.RenderText();
                _editingNode = null;

                _editLabel.Visible = false;
                _editText.Visible = false;
            }

        }

        private void NodeSelectionChanged(object s = null, EventArgs e = null)
        {
            var selectedNode = _treeView.SelectedNode == null ? null : _treeView.SelectedNode as EditableNode;

            if (selectedNode == _editingNode)
                return;

            TryApplyEditChanges();

            if (selectedNode == null)
                return;

            _editingNode = selectedNode;
            _editingNode.HideText();
            _treeView.SelectedNode = null; //Hide selection

            selectedNode.Text = "";

            _editLabel.Visible = true;
            _editText.Visible = true;

            _editLabel.Text = selectedNode.Key;
            _editText.Text = selectedNode.Value;

            _editLabel.Left = selectedNode.Bounds.Left;
            _editLabel.Top = selectedNode.Bounds.Top;

            _editText.Left = _editLabel.Right;
            _editText.Top = _editLabel.Top;
        }
    }
}
