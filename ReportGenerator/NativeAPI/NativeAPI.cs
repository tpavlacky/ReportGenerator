using DevExpress.Utils.Drawing.Helpers;
using System;
using System.Runtime.InteropServices;

namespace ReportGenerator
{
    public static class NativeAPI
    {
        public static bool ScreenToClient(IntPtr hWnd, ref NativeMethods.POINT lpPoint)
        {
            return Core.ScreenToClient(hWnd, ref lpPoint);
        }
        static class Core
        {
            [DllImport("user32.dll")]
            public static extern bool ScreenToClient(IntPtr hWnd, ref NativeMethods.POINT lpPoint);
        }
    }
}
