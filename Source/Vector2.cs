using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGraphics
{
    public struct Vector2
    {
        public float X { get; set; }
        public float Y { get; set; }
        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }
        public void Set(float _X, float _Y)
        {
            X = _X;
            Y = _Y;
        }
        public override string ToString()
        {
            return $"({X},{Y})";
        }
        public static bool operator ==(Vector2 V1,Vector2 V2)=> !(V1!=V2);
        public static bool operator !=(Vector2 V1,Vector2 V2)=> V1.X != V2.X | V1.Y != V2.Y;
        public static Vector2 operator -(Vector2 V1, Vector2 V2) => new Vector2(V1.X - V2.X, V1.Y - V2.Y);
        public static Vector2 operator +(Vector2 V1, Vector2 V2) => new Vector2(V1.X + V2.X, V1.Y + V2.Y);
        public static Vector2 operator *(Vector2 V1, float num) => new Vector2(V1.X * num, V1.Y * num);
        public static Vector2 operator /(Vector2 V1, float num) => new Vector2(V1.X / num, V1.Y / num);
    }
    public static class Vector2Extensions
    {
        public static Vector2 NormalizedCopy(this Vector2 vector)
        {
            var Sum = vector.X + vector.Y;
            var normalized = new Vector2(vector.X / Sum, vector.Y / Sum);
            return normalized;
        }
    }
}
