using labb_2.UI;
using System.IO;
using System.Security.Cryptography;

namespace labb_2;

internal class Program
{
    static void Main()
    {
        Console.CursorVisible = false;

        string path = Path.Combine("Levels", "Level1.txt");
        LevelData levelData = new LevelData();
        int[] startPosition = levelData.Load(path);
        Player player = new(startPosition);
        MessageLog messageLog = new(levelData.LevelHeight, levelData.LevelWidth);
        Renderer renderer = new(levelData, player, messageLog);

        while (true)
        {
            renderer.DrawAll();
            ConsoleKey thePressedKey = Console.ReadKey().Key;
            player.Move(thePressedKey, levelData, messageLog);
            Console.Clear();

            if (thePressedKey == ConsoleKey.Escape || player.HitPoints<=0)
            {
                GameOverScreen gameOverScreen = new();
                gameOverScreen.GameOver(levelData.LevelHeight, levelData.LevelWidth);
            }
        }
    }
}

