using SplitHunter.EXE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplitHunter.EXE.Editor
{
    public class SplitNode : TreeNode
    {
        public readonly Split Split;
        public SplitNode(Split split)
        {
            Split = split;
            _nameNode = new EditableNode("Name", split.Name, NameChanged);

            Nodes.Add(_nameNode);
            _bestNode = new EditableNode("Best", split.Best.NullableToString(), BestTimeChanged);
            Nodes.Add(_bestNode);

            _currentNode = new EditableNode("Current", split.Current.NullableToString(), CurrentTimeChanged);
            Nodes.Add(_currentNode);

            Render();
        }

        public void Render()
        {
            Text = Split.Name;
            _nameNode.RenderText();
            _bestNode.RenderText();
            _currentNode.RenderText();
        }

        private bool NameChanged(string input)
        {
            Split.Name = input;
            Text = Split.Name;
            return true;
        }

        private bool BestTimeChanged(string input)
        {
            if(input.ToLower().Contains("null"))
            {
                Split.Best = null;
                return true;
            }

            TimeSpan parsed;
            if (TimeSpan.TryParse(input, out parsed))
            {
                Split.Best = parsed;
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CurrentTimeChanged(string input)
        {
            if (input.ToLower().Contains("null"))
            {
                Split.Best = null;
                return true;
            }

            TimeSpan parsed;
            if (TimeSpan.TryParse(input, out parsed))
            {
                Split.Current = parsed;
                return true;
            }
            else
            {
                return false;
            }
        }
        EditableNode _nameNode;
        EditableNode _bestNode;
        EditableNode _currentNode;
    }
}
