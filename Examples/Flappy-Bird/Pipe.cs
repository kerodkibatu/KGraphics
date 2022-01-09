using KGraphics;
using KGraphics.ConsoleG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    public class Pipe
    {
        public Rectangle Top;
        public Rectangle Bottom;
        float Speed = 10f;
        public float X;
        float Spacing = 4;
        float width = 10f;
        public Pipe(float Y,Size Window)
        {
            X = Window.Width;
            Top = new Rectangle(new Vector2(X,0),new(width,Y-Spacing));
            Bottom = new Rectangle(new Vector2(X,Y+Spacing),new(width,Window.Height-Y+Spacing));
        }
        public void Draw(Graphic G)
        {
            G.DrawRectangle(Bottom);
            G.DrawRectangle(Top);
        }
        public void Update()
        {
            X -= Speed;
            Top.Position.X = X;
            Bottom.Position.X = X;
        }
    }
}
