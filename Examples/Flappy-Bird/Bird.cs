using KGraphics;
using KGraphics.ConsoleG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    internal class Bird
    {
        public Vector2 Pos;
        public float MaxSpeed = 5f;
        public float Radius;
        public float YSpeed = 0;
        public float YAcc;
        public static float Gravity = 10f;
        public Bird(Vector2 pos,float Rad)
        {
            Pos = pos;
            Radius = Rad;
        }
        public void Draw(Graphic G)
        {
            G.DrawCircle(Pos, Radius);
        }
        public void Update()
        {
            Input();
            YAcc+=Gravity;
            YSpeed += YAcc;
            YSpeed = Math.Clamp(YSpeed, -MaxSpeed, MaxSpeed);
            Pos.Y += YSpeed;
        }
        bool CanPress = true;
        public void Input()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey readKey = Console.ReadKey().Key;
                if (readKey == ConsoleKey.Spacebar && CanPress==true)
                {
                    YAcc = -100f;
                    CanPress = false;
                }
            }
            else
            {
                CanPress = true;
            }
        }
    }
}
