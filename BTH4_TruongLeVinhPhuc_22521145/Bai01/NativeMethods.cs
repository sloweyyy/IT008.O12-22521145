using System.Runtime.InteropServices;

namespace Bai01
{
    public partial class Form
    {
        internal static class NativeMethods
        {
            [DllImport("user32.dll")]
            internal static extern int ToAscii(int uVirtKey, int uScanCode, byte[] lpKeyState, out char lpChar, int uFlags);

            [DllImport("user32.dll")]
            internal static extern int GetKeyboardState(byte[] lpKeyState);
        }

    }



}