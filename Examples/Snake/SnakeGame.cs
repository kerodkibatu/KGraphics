using System;
using System.Collections.Generic;
using KGraphics;
using KGraphics.ConsoleG;

namespace Snake
{
    public class SnakeGame
    {
        Vector2 Food;
        Vector2 Head;
        List<Vector2> Tails = new();
        Vector2 Dir;

        int Grid = 40;
        float Res;
        Size WinSize;
        public SnakeGame(Size winSize)
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
            AddTail();
            PlaceFood();
        }
        public void Draw(Graphic G)
        {
            G.DrawRectangle(new Rectangle(Head * Res, new SizeF(Res)));
            G.DrawRectangle(new Rectangle(Food * Res, new SizeF(Res)));
            foreach (var tail in Tails)
            {
                G.DrawRectangle(new Rectangle(tail * Res, new SizeF(Res)));
            }
        }
        int Interval = 1;
        int Ctr = 0;
        public void Update()
        {
            SnakeInput();
            if (Ctr % Interval == 0)
            {
                Move();
                Eat();
                Alive();
            }
            Ctr++;
        }
        public void SnakeInput()
        {
            if (Input.isKeyPressed(ConsoleKey.UpArrow) & Dir != new Vector2(0, 1))
            {
                Dir = new Vector2(0, -1);
            }else
            if (Input.isKeyPressed(ConsoleKey.DownArrow) & Dir != new Vector2(0, -1))
            {
                Dir = new Vector2(0, 1);
            }else
            if (Input.isKeyPressed(ConsoleKey.RightArrow) & Dir != new Vector2(-1, 0))
            {
                Dir = new Vector2(1, 0);
            }else
            if (Input.isKeyPressed(ConsoleKey.LeftArrow) & Dir != new Vector2(1, 0))
            {
                Dir = new Vector2(-1, 0);
            }
        }
        private void Eat()
        {
            if (Head == Food)
            {
                PlaceFood();
                AddTail();
            }
        }
        public void Move()
        {
            for (int i = Tails.Count - 1; i > 0; i--)
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
            } while (Food == Head | Tails.Contains(Food));
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
