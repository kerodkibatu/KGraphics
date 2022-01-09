using FlappyBird;
using KGraphics;
using KGraphics.ConsoleG;

Graphic Graphic = new Graphic(new Size(420,420));
Bird B;
List<Pipe> pipes;
void Reset()
{
    B = new Bird(new Vector2(100, 120), 5);
    pipes = new List<Pipe>();

    pipes.Add(new Pipe(Random.Shared.Next(10,Graphic.Size.Height-10), Graphic.Size));
    pipes.Add(new Pipe(Random.Shared.Next(10,Graphic.Size.Height-10), Graphic.Size) { X = Graphic.Size.Width * 1.5f });
}
Reset();
using (Console.Out)
{
    while (true)
    {
        Graphic.ClearDraw();
        Draw(Graphic);
        Graphic.DrawBuffer();
        Update();
    }
}
void Draw(Graphic G)
{
    foreach (var pipe in pipes)
    {
        pipe.Draw(G);
    }
    B.Draw(G);
}
void Update()
{
    for (int i = pipes.Count-1; i >= 0; i--)
    {
        pipes[i].Update();
        if (pipes[i].Top.Intersects(B.Pos)|pipes[i].Bottom.Intersects(B.Pos))
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        if (pipes[i].X<0)
        {
            pipes[i] = new Pipe(Random.Shared.Next(10,Graphic.Size.Height-10),Graphic.Size);
        }
    }
    B.Update();
}