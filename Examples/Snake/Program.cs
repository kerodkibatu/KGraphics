using KGraphics;
using KGraphics.ConsoleG;

using (Console.Out)
{
    Size WindowSize = new Size(420);
    Graphic G = new Graphic(WindowSize);
    
    while (true)
    {
        G.ClearDraw();
        Draw(G);
        G.DrawBuffer();
        Update();
    }
}
void Draw(Graphic G)
{

}
void Update()
{

}