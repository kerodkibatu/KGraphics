using KGraphics;
using KGraphics.ConsoleG;
using Snake;


Size WindowSize = new Size(420);
SnakeGame SG = new SnakeGame(WindowSize);
Graphic G = new Graphic(WindowSize);

while (true)
{
    G.ClearDraw();
    Draw(G);
    G.DrawBuffer();
    Update();
}
void Draw(Graphic G)
{
    SG.Draw(G);
}
void Update()
{
    SG.Update();
}