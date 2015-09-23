using SplitHunter.EXE.Data;
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

namespace SplitHunter.EXE.Editor
{
    public partial class SplitEditor : Form
    {
        public Splits CurrentSplits
        {
            get { return _treeEditor.Value; }
            set
            {
                _treeEditor.Value = value;
                Render();
            }
        }

        public SplitEditor()
        {
            InitializeComponent();
            _treeEditor = new SplitTreeEditor(TreeView);
            Render();
        }

        public void Render(object s = null, EventArgs e = null)
        {
            if (CurrentSplits == null)
                Text = "SplitHunter.EXE";
            else
                Text = (CurrentSplits.Dirty ? "*" : "") + CurrentSplits.Name;
            _treeEditor.Refresh();
        }

        private void NewEmpty(object s = null, EventArgs e = null)
        {
            CurrentSplits = Splits.NewEmpty();
        }

        private void CloneExisting(object s = null, EventArgs e = null)
        {
            if (!Directory.Exists(Splits.DefaultSplitsDirectory))
                Directory.CreateDirectory(Splits.DefaultSplitsDirectory);

            var dialog = new OpenFileDialog();
            dialog.Filter = FileFilter;
            dialog.InitialDirectory = Splits.DefaultSplitsDirectory.ToWindowsPath();
            dialog.AutoUpgradeEnabled = false;
            dialog.Multiselect = false;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                CurrentSplits = Splits.CloneExisting(dialog.FileName);
            }
        }

        private void Save(object s = null, EventArgs e = null)
        {
            if (!File.Exists(CurrentSplits.FullPath))
            {
                SaveAsClicked();
                return;
            }

            CurrentSplits.Save();
            Render();
        }

        private void SaveAsClicked(object s = null, EventArgs e = null)
        {
            if (!Directory.Exists(Splits.DefaultSplitsDirectory))
                Directory.CreateDirectory(Splits.DefaultSplitsDirectory);

            var dialog = new SaveFileDialog();
            dialog.Filter = FileFilter;
            dialog.AutoUpgradeEnabled = false;
            dialog.FileName = CurrentSplits.FullPath.ToWindowsPath();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                CurrentSplits.FullPath = dialog.FileName;
                CurrentSplits.Save();
                Render();
            }
        }

        private const string FileFilter = "txt (*.txt)|*.txt|csv (*.csv)|*.csv|All Files (*.*)|*.*";
        private SplitTreeEditor _treeEditor;
    }
}
