using SplitHunter.EXE.Data;
using SplitHunter.EXE.Tools;
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
            _treeEditor = new SplitTreeEditor(TreeView, EditText, EditLabel, this);
            Render();
        }

        public void Render(object s = null, EventArgs e = null)
        {
            if (CurrentSplits == null)
                Text = "SplitHunter.EXE";
            else
                Text = (CurrentSplits.Dirty ? "*" : "") + CurrentSplits.Name;
            _treeEditor.Render();
        }

        private void NewEmpty(object s = null, EventArgs e = null)
        {
            CurrentSplits = Splits.NewEmpty();
        }

        private void CloneExisting(object s = null, EventArgs e = null)
        {
            string path;
            if(OpenFileDialog(out path))
            {
                CurrentSplits = Splits.CloneExisting(path.ToForwardPath());
            }
        }

        private void Open(object s = null, EventArgs e = null)
        {
            string path;
            if (OpenFileDialog(out path))
            {
                CurrentSplits = Splits.Open(path.ToForwardPath());
            }
        }

        private bool OpenFileDialog(out string path)
        {
            if (!Directory.Exists(Splits.DefaultSplitsDirectory))
                Directory.CreateDirectory(Splits.DefaultSplitsDirectory);

            var dialog = new OpenFileDialog();
            dialog.Filter = FileFilter;
            dialog.InitialDirectory = Splits.DefaultSplitsDirectory.ToBackSlashPath();
            dialog.AutoUpgradeEnabled = false;
            dialog.Multiselect = false;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                path = dialog.FileName;
                return true;
            }
            else
            {
                path = null;
                return false;
            }
        }

        public void Save(object s = null, EventArgs e = null)
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
            dialog.FileName = CurrentSplits.FullPath.ToBackSlashPath();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                CurrentSplits.FullPath = dialog.FileName;
                CurrentSplits.Save();
                Render();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                _treeEditor.TryApplyEditChanges();
                Save();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private const string FileFilter = "txt (*.txt)|*.txt|csv (*.csv)|*.csv|All Files (*.*)|*.*";
        private SplitTreeEditor _treeEditor;

        private void simpleTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentSplits == null
                || !CurrentSplits.Any())
            {
                MessageBox.Show("Requires splits");
                return;
            }

            new SimpleTimer(CurrentSplits, this).Show();
        }
    }
}
