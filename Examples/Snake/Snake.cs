using System;
using System.Collections.Generic;
using KGraphics;
using KGraphics.ConsoleG;

namespace Snake
{
    public class Snake
    {
        Vector2 Food;
        Vector2 Head;
        List<Vector2> Tails = new();
        Vector2 Dir;

        int Grid = 20;
        float Res;
        Size WinSize;
        public Snake(Size winSize)
        {
            WinSize = winSize;
            Res = WinSize.Width / Grid;
            Reset();
        }
        public void Reset()
        {
            Head = new Vector2(0, 0);
            Dir = new Vector2(1, 0);
            Tails = new List<Vector2>() { Head };
        }
        public void Draw(Graphic G)
        {
            G.DrawRectangle(new Rectangle(Head*Res, new SizeF(Res)));
            foreach (var tail in Tails)
            {
                G.DrawRectangle(new Rectangle(tail*Res, new SizeF(Res)));
            }
        }
        int Interval = 3;
        int Ctr = 0;
        public void Update()
        {
            Input();
            if (Ctr%Interval==0)
            {
                Move();
                Eat();
                Alive();
            }
            Ctr++;
        }
        public void Input()
        {

        }
        private void Eat()
        {
            if (Head==Food)
            {
                PlaceFood();
                AddTail();
            }
        }
        public void Move()
        {
            for (int i = Tails.Count; i > 0; i--)
            {
                Tails[i] = Tails[i - 1];
            }
            Tails[0] = Head;
            Head += Dir;
        }
        public void AddTail()
        {
            Tails.Add(Tails[Tails.Count - 1]);
        }
        public void PlaceFood()
        {
            do
            {
                Food.X = Random.Shared.Next(Grid);
                Food.Y = Random.Shared.Next(Grid);
            } while (Food == Head|Tails.Contains(Food));
        }
        public void Alive()
        {
            if (Head.X < 0 | Head.X > WinSize.Width | Head.Y < 0 | Head.Y > WinSize.Height)
            {
                Reset();
            }
        }
    }
}
