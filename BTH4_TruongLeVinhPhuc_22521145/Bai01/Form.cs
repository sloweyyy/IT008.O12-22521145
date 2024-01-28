using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Bai01
{
    public partial class Form : System.Windows.Forms.Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);


        private delegate IntPtr LowLevelProc(int nCode, IntPtr wParam, IntPtr lParam);

        private const int WH_KEYBOARD_LL = 13;
        private const int WH_MOUSE_LL = 14;


        private IntPtr _keyboardHookID = IntPtr.Zero;
        private IntPtr _mouseHookID = IntPtr.Zero;
        private LowLevelProc _keyboardProc;
        private LowLevelProc _mouseProc;
        private TextBox textBoxOutput;

        public Form()
        {
            InitializeComponent();
            _keyboardProc = KeyboardHookCallback;
            _mouseProc = MouseHookCallback;
            _keyboardHookID = SetHook(_keyboardProc, WH_KEYBOARD_LL);
            _mouseHookID = SetHook(_mouseProc, WH_MOUSE_LL);
        }

        private void InitializeComponent()
        {
            textBoxOutput = new TextBox();
            SuspendLayout();

            textBoxOutput.Location = new Point(16, 18);
            textBoxOutput.Multiline = true;
            textBoxOutput.Name = "textBoxOutput";
            textBoxOutput.ReadOnly = true;
            textBoxOutput.ScrollBars = ScrollBars.Vertical;
            textBoxOutput.Size = new Size(400, 400);
            textBoxOutput.TabIndex = 0;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 400);
            Controls.Add(textBoxOutput);
            KeyPreview = true;
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Keyboard and Mouse Event Tracker";
            StartPosition = FormStartPosition.CenterScreen;
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        private IntPtr SetHook(LowLevelProc proc, int hookType)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(hookType, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            UnhookWindowsHookEx(_keyboardHookID);
            UnhookWindowsHookEx(_mouseHookID);
        }

        private IntPtr KeyboardHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                KeyboardMessages message = (KeyboardMessages)wParam;
                if (message == KeyboardMessages.WM_KEYDOWN || message == KeyboardMessages.WM_SYSKEYDOWN)
                {
                    int vkCode = Marshal.ReadInt32(lParam);
                    char asciiChar = ConvertToAscii(vkCode);
                    textBoxOutput.AppendText("Key Pressed: " + (Keys)vkCode + " (Key Code: " + vkCode + ", ASCII: " +
                                             asciiChar + ")" + Environment.NewLine);
                }
            }

            return CallNextHookEx(_keyboardHookID, nCode, wParam, lParam);
        }

        private char ConvertToAscii(int vkCode)
        {
            byte[] keyboardState = new byte[256];
            NativeMethods.GetKeyboardState(keyboardState);

            char asciiChar = ' ';
            int result = NativeMethods.ToAscii(vkCode, 0, keyboardState, out asciiChar, 0);
            if (result == 1)
            {
                return asciiChar;
            }

            return ' ';
        }


        private IntPtr MouseHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                if ((MouseandKeyMessages)wParam == MouseandKeyMessages.WM_LBUTTONDOWN)
                {
                    MouseHookStruct mouseInfo =
                        (MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseHookStruct));
                    textBoxOutput.AppendText("Left button down at X: " + mouseInfo.X + " Y: " + mouseInfo.Y +
                                             Environment.NewLine);
                }
                else if ((MouseandKeyMessages)wParam == MouseandKeyMessages.WM_RBUTTONDOWN)
                {
                    MouseHookStruct mouseInfo =
                        (MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseHookStruct));
                    textBoxOutput.AppendText("Right button down at X: " + mouseInfo.X + " Y: " + mouseInfo.Y +
                                             Environment.NewLine);
                }
            }

            return CallNextHookEx(_mouseHookID, nCode, wParam, lParam);
        }

        private struct MouseHookStruct
        {
            public int X;
            public int Y;
            public int MouseData;
            public int Flags;
            public int Time;
            public IntPtr ExtraInfo;
        }
    }
}