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
        public Splits SelectedSplits
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

            TreeView.PerformRecursive((control) =>
            {
                control.MouseClick += HandleClick;
            });
            Render();
        }


        private void HandleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            var mousePos = (sender as Control).GetWorldLocation();
            mousePos.X += e.X;
            mousePos.Y += e.Y;

            RightClickContext.Enabled = SelectedSplits != null;

            if (SelectedSplits == null)
                return;

            var selectedSplit = _treeEditor.GetSelectedSplit();
            if (selectedSplit != null)
            {
                DeleteSplitContextItem.Text = "Delete \"" + selectedSplit.Name + "\"";
                DeleteSplitContextItem.Enabled = true;
            }
            else
            {
                DeleteSplitContextItem.Text = "Delete Split";
                DeleteSplitContextItem.Enabled = false;
            }

            RightClickContext.Show(mousePos);
        }


        public void Render(object s = null, EventArgs e = null)
        {
            if (SelectedSplits == null)
                Text = "SplitHunter.EXE";
            else
                Text = (SelectedSplits.Dirty ? "*" : "") + SelectedSplits.Name;
            _treeEditor.Render();
        }

        private void NewEmpty(object s = null, EventArgs e = null)
        {
            SelectedSplits = Splits.NewEmpty();
        }

        private void CloneExisting(object s = null, EventArgs e = null)
        {
            string path;
            if(OpenFileDialog(out path))
            {
                SelectedSplits = Splits.CloneExisting(path.ToForwardPath());
            }
        }

        private void Open(object s = null, EventArgs e = null)
        {
            string path;
            if (OpenFileDialog(out path))
            {
                SelectedSplits = Splits.Open(path.ToForwardPath());
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
            if (!File.Exists(SelectedSplits.FullPath))
            {
                SaveAsClicked();
                return;
            }

            SelectedSplits.Save();
            Render();
        }

        private void SaveAsClicked(object s = null, EventArgs e = null)
        {
            if (!Directory.Exists(Splits.DefaultSplitsDirectory))
                Directory.CreateDirectory(Splits.DefaultSplitsDirectory);

            var dialog = new SaveFileDialog();
            dialog.Filter = FileFilter;
            dialog.AutoUpgradeEnabled = false;
            dialog.FileName = SelectedSplits.FullPath.ToBackSlashPath();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SelectedSplits.FullPath = dialog.FileName;
                SelectedSplits.Save();
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

        private void simpleTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedSplits == null
                || !SelectedSplits.Any())
            {
                MessageBox.Show("Requires splits");
                return;
            }

            new SimpleTimer(SelectedSplits, this).Show();
        }

        private void AddSplitBeforeSelection(object sender, EventArgs e)
        {
            if (SelectedSplits == null)
                return;

            var newSplit = new Split()
            {
                Name = "New Split",
            };

            var selectedSplit = _treeEditor.GetSelectedSplit();
            if (selectedSplit != null)
            {
                SelectedSplits.Insert(SelectedSplits.IndexOf(selectedSplit), newSplit);
            }
            else
            {
                SelectedSplits.Insert(0, newSplit);
            }
            SelectedSplits.Dirty = true;
            Render();
        }

        private void AddSplitAfterSelection(object sender, EventArgs e)
        {
            if (SelectedSplits == null)
                return;

            var newSplit = new Split()
            {
                Name = "New Split",
            };

            var selectedSplit = _treeEditor.GetSelectedSplit();
            if(selectedSplit != null)
            {
                SelectedSplits.Insert(SelectedSplits.IndexOf(selectedSplit) + 1, newSplit);
            }
            else
            {
                SelectedSplits.Insert(SelectedSplits.Count, newSplit);
            }
            SelectedSplits.Dirty = true;
            Render();
        }

        private void DeleteSplit(object sender, EventArgs e)
        {
            if (SelectedSplits == null)
                return;
            var selectedSplit = _treeEditor.GetSelectedSplit();
            if (selectedSplit == null
                || !SelectedSplits.Contains(selectedSplit))
                return;

            SelectedSplits.Remove(selectedSplit);
            SelectedSplits.Dirty = true;
            Render();
        }

        private const string FileFilter = "txt (*.txt)|*.txt|csv (*.csv)|*.csv|All Files (*.*)|*.*";
        private SplitTreeEditor _treeEditor;
        private Split _contextSplit;
    }
}
