using labb_2.UI;
using System;
using System.IO;
using System.Runtime.CompilerServices;
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

        GameLoop gameLoop = new(levelData, player, messageLog, renderer);
        gameLoop.StartLoop();
    }
}

