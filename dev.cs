using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows;
using System.Drawing;

namespace dev_help
{
    internal static class cursor_pos
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct point
        {
            public int x;
            public int y;

            public static implicit operator System.Drawing.Point(point pointy)
            {
                return new Point(pointy.x, pointy.y);
            }

        }
        public static Point get_cur_pos()
        {
            point pointy;
            GetCursorPos(out pointy);

            return pointy;
        }

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out point pointy);
    }
}
