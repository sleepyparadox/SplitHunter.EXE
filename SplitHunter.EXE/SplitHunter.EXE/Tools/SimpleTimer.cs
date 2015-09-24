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
        public bool SaveOnSplit { get; set; }

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
        Splits _splits;
        int _splitIndex;
        SplitEditor _parent;
        KeyLogger _keyLogger;

        Keys _toggleStartKey = Keys.NumPad5;
        Keys _splitNowKey = Keys.NumPad0;
        Keys _selectPreviousSplitKey = Keys.NumPad4;
        Keys _selectNextSplitKey = Keys.NumPad6;

        public SimpleTimer(Splits splits, SplitEditor parent)
        {
            InitializeComponent();

            SaveOnSplit = true;

            _parent = parent;
            _splits = splits;
            _splitIndex = 0;

            _timer = new Timer();
            _timer.Interval = 10;
            _timer.Tick += Render;
            _timer.Start();

            _keyLogger = new KeyLogger(_toggleStartKey, _splitNowKey, _selectPreviousSplitKey, _selectNextSplitKey);
            _keyLogger.OnKeyPressed += OnKeyPressedThreadSafe;
            _keyLogger.Start();

            this.PerformRecursive((control) =>
            {
                control.MouseClick += HandleClick;
            });

            Render();
        }

        private void HandleClick(object sender, MouseEventArgs e)
        {
            if(sender is Control
                && e.Button == MouseButtons.Right)
            {
                var mousePos = (sender as Control).GetWorldLocation();
                mousePos.X += e.X;
                mousePos.Y += e.Y;

                RightClickContext.Show(mousePos);
            }
        }

        public delegate void KeyPressedEventHandler(Keys key);

        private void OnKeyPressedThreadSafe(Keys key)
        {
            if (InvokeRequired)
            {
                Invoke(new KeyPressedEventHandler(OnKeyPressedThreadSafe), key);
            }
            else
            {
                if(key == _toggleStartKey)
                {
                    ToggleRecording();
                }
                if (key == _splitNowKey)
                {
                    SplitNow();
                }
                if (key == _selectPreviousSplitKey)
                {
                    SelectPreviousSplit();
                }
                if (key == _selectNextSplitKey)
                {
                    SelectNextSplit();
                }
            }
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

        private void ToggleRecording(object o = null, EventArgs e = null)
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

        private void SelectPreviousSplit(object o = null, EventArgs e = null)
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

        private void resetToolStripMenuItem_Click(object o = null, EventArgs e = null)
        {
            StopRecording();

            _bankedTime = TimeSpan.FromSeconds(0);
        }

        private void SplitNow(object o = null, EventArgs e = null)
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

            if(SaveOnSplit)
            {
                Save();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                Save();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SimpleTimer_FormClosed(object sender, FormClosedEventArgs e)
        {
            _timer.Stop();
            _keyLogger.Stop();
        }

        void Save()
        {
            _parent.Save();
            Render();
        }
    }
}
