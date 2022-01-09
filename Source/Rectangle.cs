using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGraphics
{
    public struct Rectangle
    {
        public float X => Position.X;
        public float Y => Position.Y;
        public float Width => Size.Width;
        public float Height => Size.Height;

        public Vector2 Position;
        public SizeF Size;
        public Rectangle(Vector2 position, SizeF size)
        {
            Position = position;
            Size = size;
        }
        public bool Intersects(Vector2 Point)
        {
            if (Point.X > X & Point.X < X + Width & Point.Y > Y & Point.Y < Y + Height)
            {
                return true;
            }
            return false;
        }
        public static Rectangle operator /(Rectangle rect, float num) =>new(rect.Position,rect.Size/num);
        public override string ToString()
        {
            return $@"{Position},{Size}";
        }
    }
    public static class RectangleExtensions
    {
        public static (Vector2, SizeF) Deconstruct(this Rectangle R)
        {
            return (R.Position, R.Size);
        }
    }
}
