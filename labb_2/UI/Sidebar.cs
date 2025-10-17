using labb_2.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb_2.UI;

internal class Sidebar
{
    private readonly int _height;
    private readonly int _width;
    private readonly int _x;
    private readonly Player _player;

    public Sidebar(int levelHeight, int levelWidth, Player player)
    {
        _height = levelHeight-1;
        _width = 24;
        _x = levelWidth+1;
        _player = player;

    }

    public int Width
        {
            get { return _width; }
        }

    public void Draw()
    {
        DrawBox();
        DrawLifeCounter();
    }

    private void DrawBox()
    {
        Console.SetCursorPosition(_x, 0);
        Console.WriteLine($"╔═ Life {new string('═', _width - 9)}╗");
        Console.SetCursorPosition(_x, Console.GetCursorPosition().Top);
        Console.WriteLine($"║{new string(' ', _width - 2)}║");
        Console.SetCursorPosition(_x, Console.GetCursorPosition().Top);
        Console.WriteLine($"╠{new string('═', _width - 2)}╣");
        Console.SetCursorPosition(_x, Console.GetCursorPosition().Top);

        for (int i = 0; i < _height; i++)
        {
            Console.SetCursorPosition(_x, Console.GetCursorPosition().Top);
            Console.WriteLine($"║{new string(' ', _width - 2)}║");
        }
        Console.SetCursorPosition(_x, Console.GetCursorPosition().Top);
        Console.WriteLine($"╚{new string('═', _width - 2)}╝");

        Console.SetCursorPosition(_x + 1, 1);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(_x + 2, Console.GetCursorPosition().Top);
    }

    private void DrawLifeCounter()
    {
        int hearts = _player.HitPoints.HP / 5;
        if (hearts == 0)
        {
            hearts = 1;
        }
        while (hearts > 0)
        {
            Console.Write('♥');
            if (hearts % (_width - 2) == 1)
            {
                Console.WriteLine();
                Console.SetCursorPosition(_x + 2, Console.GetCursorPosition().Top);
            }
            hearts--;
        }
        Console.ResetColor();
    }
}
