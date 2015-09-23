using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplitHunter.EXE.Editor
{
    public class EditableNode : TreeNode
    {
        public string Key;
        public string Value;
        public readonly TryEditEventArgs OnTextChanged;

        public EditableNode(string key, string val, TryEditEventArgs onTextChanged)
        {
            Key = key;
            Value = val;
            OnTextChanged = onTextChanged;
            RenderText();
        }

        public void HideText()
        {
            Text = string.Empty;
        }

        public void RenderText()
        {
            Text = string.Format("{0}: {1}", Key, Value);
        }
    }

}
