using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
namespace KGraphics.ConsoleG
{
    public class Graphic
    {
        Dictionary<(char, char), char> CompDict = new Dictionary<(char, char), char>();
        char Fill = '@';
        char Empty = ' ';
        char Up = '^';
        char Down = ',';
        char Vert = '│';
        char Hor =  '─';
        public Size Size;
        char[,] buffer;
        public Graphic(Size _Size)
        {
            CompDict.Add((Empty, Empty), Empty);
            CompDict.Add((Fill, Fill), Fill);
            CompDict.Add((Fill, Empty), Up);
            CompDict.Add((Empty, Fill), Down);
            Size = _Size;
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(Console.LargestWindowWidth-30,Console.LargestWindowHeight-30);
            buffer = new char[Size.Width,Size.Height];
        }
        public void ClearDraw()
        {
            for (int y = 0; y < Size.Height; y++)
            {
                for (int x = 0; x < Size.Width; x++)
                {
                    buffer[x,y] = Empty;
                }
            }
        }
        public void DrawBuffer()
        {
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < Size.Height / 2; y += 2)
            {
                char[] temp = new char[Size.Width];
                for (int x = 0; x < Size.Width; x++)
                {
                    temp[x] = CompDict[(buffer[x,y+0], buffer[x,y+1])];
                }
                Console.WriteLine(temp);
            }
        }
        public void DrawRectangle(Rectangle Rectangle)
        {
            Rectangle /= 2;
            for (int y = 0; y < Size.Height; y++)
            {
                for (int x = 0; x < Size.Width; x++)
                {
                    if (x > Rectangle.X & x < Rectangle.X + Rectangle.Width & y > Rectangle.Y& y < Rectangle.Y + Rectangle.Height)
                    {
                        buffer[x,y] = Fill;
                    }
                }
            }
        }
        public void DrawCircle(Vector2 Position, float Radius)
        {
            for (int y = 0; y < Size.Height; y++)
            {
                for (int x = 0; x < Size.Width; x++)
                {
                    if (Sqrt(Pow(x - Position.X, 2) + Pow(y - Position.Y, 2)) < Radius)
                    {
                        buffer[x,y] = Fill;
                    }
                }
            }
        }
        public void DrawPoint(Vector2 Point)
        {
            buffer[(int)Point.X, (int)Point.Y] = Fill;
        }
    }
}
