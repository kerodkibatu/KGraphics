using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGraphics
{
    public struct Size
    {
        public int Width, Height;
        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public Size(int Size)
        {
            (Width,Height) = (Size,Size);
        }
        public static implicit operator SizeF(Size sf)
        {
            return new(sf.Width, sf.Height);
        }
        public override string ToString()
        {
            return $"{Width},{Height}";
        }
    }
    public struct SizeF
    {
        public float Width, Height;
        public SizeF(float width, float height)
        {
            (Width,Height) = (width,height);
        }
        public SizeF(float Size)
        {
            (Height, Width) = (Size, Size);
        }
        public override string ToString()
        {
            return $"({Width},{Height})";
        }
        public static implicit operator Size(SizeF sf)
        {
            return new((int)sf.Width,(int)sf.Height);
        }
        public static SizeF operator /(SizeF size, float num) => new(size.Width / num, size.Height / num);
    }
}
