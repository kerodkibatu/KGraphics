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

        public static bool isKeyPressed(ConsoleKey Key)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey readKey = Console.ReadKey().Key;
                if (readKey == Key)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
