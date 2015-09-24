using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace SplitHunter.EXE.Tools
{
    public class KeyLogger
    {
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);

        public event Action<Keys> OnKeyPressed;

        public KeyLogger(params Keys[] keysToCheck)
        {
            _keysToCheck = keysToCheck;
        }

        public void Start()
        {
            Stop();
            _listenThread = new Thread(DoLogKeys);
            _listenThread.Start();
        }

        public void Stop()
        {
            if(_listenThread != null 
                && _listenThread.IsAlive)
            {
                _listenThread.Abort();
            }
        }

        void DoLogKeys()
        {
            while (true)
            {
                Thread.Sleep(10);
                for (var i = 0; i < _keysToCheck.Length; i++)
                {
                    int keyState = GetAsyncKeyState((int)_keysToCheck[i]);
                    if (keyState == 1 || keyState == -32767)
                    {
                        if (OnKeyPressed != null)
                            OnKeyPressed(_keysToCheck[i]);
                        break;
                    }
                }
            }
        }

        Thread _listenThread;
        Keys[] _keysToCheck;
    }
}
