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
        List<SplitNode> _nodes = new List<SplitNode>();

        TreeView _treeView;
        TextBox _editText;
        Label _editLabel;

        EditableNode _editingNode;
        private SplitEditor _parent;

        public SplitTreeEditor(TreeView treeView, TextBox editText, Label editLabel, SplitEditor parent)
        {
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

        private void CheckForEnterKey(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                TryApplyEditChanges();
            }
        }

        public void Refresh()
        {
            if (Value == null)
            {
                _treeView.Visible = false;
                return;
            }
            _treeView.Visible = true;
            
            //Remove deleted nodes
            var nodesToRemove = _nodes.Where(n => Value.Contains(n.Split));
            foreach (var node in nodesToRemove)
                _treeView.Nodes.Remove(node);

            if (Value.Any())
            {
                foreach (var split in Value)
                {
                    var node = _nodes.FirstOrDefault(n => n.Split == split);

                    if (node == null)
                        node = new SplitNode(split);

                    _treeView.Nodes.Add(node);
                }
            }
            else
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
