using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KGraphics
{
    public static class Input
    {
        [DllImport("user32.dll")]
        static extern bool GetCursorPos(out POINT point);

        public struct POINT
        {
            public int x;
            public int y;
        }
        public static Vector2 GetMousePosition()
        {
            POINT p;
            GetCursorPos(out p);
            Vector2 Pos = new(p.x,p.y);
            return Pos;
        }
        public static Vector2 ConsoleMousePos()
        {
            Vector2 Pos = GetMousePosition();
            Pos+=new Vector2(Console.WindowLeft,Console.WindowTop);
            return Pos;
        }
    }
}
