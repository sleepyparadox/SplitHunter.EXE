using SplitHunter.EXE.Data;
using SplitHunter.EXE.Editor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplitHunter.EXE.Tools
{
    public partial class SimpleTimer : Form
    {
        TimeSpan Elapsed
        {
            get
            {
                var elapsed = _bankedTime;
                if (_recording)
                    elapsed += DateTime.Now - _recordStartAt;
                return elapsed;
            }
        }
        Split SelectedSplit
        {
            get
            {
                return _splits[_splitIndex];
            }
        }

        Timer _timer;
        TimeSpan _bankedTime;
        DateTime _recordStartAt;
        bool _recording;
        private Splits _splits;
        private int _splitIndex;
        private SplitEditor _parent;

        public SimpleTimer(Splits splits, SplitEditor parent)
        {
            InitializeComponent();

            _parent = parent;
            _splits = splits;
            _splitIndex = 0;

            _timer = new Timer();
            _timer.Interval = 10;
            _timer.Tick += Render;
            _timer.Start();

            Render();
        }

        void Render(object o = null, EventArgs e = null)
        {
            Text = (_splits.Dirty ? "*" : "") + _splits.Name;

            //Update renderers
            ElapsedText.Text = Elapsed.ToString();
            BestTimeText.Text = SelectedSplit.Best.NullableToString();
            CurrentTimeText.Text = SelectedSplit.Current.NullableToString();

            SplitNameText.Text = SelectedSplit.Name;
        }

        private void ToggleRecording(object sender, EventArgs e)
        {
            if(_recording)
            {
                StopRecording();
            }
            else
            {
                StartRecording();
            }
        }

        private void StartRecording()
        {
            if (_recording)
                return; _recording = true;
            _recordStartAt = DateTime.Now;
            StartStopButton.Text = "Stop";
        }

        private void StopRecording()
        {
            if (!_recording)
                return;
            _recording = false;
            _bankedTime += DateTime.Now - _recordStartAt;
            StartStopButton.Text = "Start";
        }

        private void SelectPreviousSplit(object sender, EventArgs e)
        {
            if (_splitIndex <= 0)
                return;
            _splitIndex--;
        }

        private void SelectNextSplit(object sender = null, EventArgs e = null)
        {
            if (_splitIndex >= _splits.Count)
                return;
            _splitIndex++;
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopRecording();

            _bankedTime = TimeSpan.FromSeconds(0);
        }

        private void SplitNow(object sender, EventArgs e)
        {
            _splits.Dirty = true;
            SelectedSplit.Current = Elapsed;
            if(!SelectedSplit.Best.HasValue
                || SelectedSplit.Current < SelectedSplit.Best)
            {
                SelectedSplit.Best = SelectedSplit.Current;
            }
            _parent.Render();

            if (_splitIndex + 1 >= _splits.Count)
            {
                //Finished run congrats!
                StopRecording();

                _bankedTime = SelectedSplit.Current.Value;
            }
            else
            {
                SelectNextSplit();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                _parent.Save();
                Render();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
