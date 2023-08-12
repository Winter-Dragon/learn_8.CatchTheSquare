using System;
using Catch_The_Square;
using SFML.Graphics;
using SFML.Window;


class Program
{
    static RenderWindow window;

    static private Color backgroundColor = new Color(Color.Black);
    static private Color defeatColor = new Color(50, 50, 50);

    static void Main(string[] args)
    {
        window = new RenderWindow(new VideoMode(1600, 900), "Catch The Square");
        window.Closed += Window_Closed;
        window.SetFramerateLimit(60);

        Game game = new Game();

        while (window.IsOpen == true)
        {
            if (Game.isLose == false)
            {
                window.Clear(backgroundColor);
            }
            else window.Clear(defeatColor);

            window.DispatchEvents();

            game.Update(window);

            window.Display();
        }
    }

    private static void Window_Closed(object sender, EventArgs e)
    {
        window.Close();
    }
}
