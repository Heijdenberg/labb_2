using labb_2.Elements;
using labb_2.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace labb_2.Core;

internal class GameLoop
{
    private LevelData _levelData;
    private Player _player;
    private MessageLog _messageLog;
    private Renderer _renderer;

    public GameLoop(LevelData levelData, Player player, MessageLog messageLog, Sidebar sidebar)
    {
        _levelData = levelData;
        _player = player;
        _messageLog = messageLog;
        _renderer = new(levelData, player, messageLog, sidebar);
    }

    public void StartLoop()
    {
        while (true)
        {
            _renderer.DrawAll();

            ConsoleKey thePressedKey = Console.ReadKey(intercept: true).Key;
            _player.Update(thePressedKey, _levelData, _messageLog);

            if (thePressedKey == ConsoleKey.Escape || _player.HitPoints.HP <= 0)
            {
                GameOverScreen gameOverScreen = new();
                gameOverScreen.GameOver(_levelData.LevelHeight, _levelData.LevelWidth);
            }

            UpdateEnemys();
        }
    }

    private void UpdateEnemys()
    {
        foreach(LevelElement element in _levelData.Elements)
        {
            if(element is Enemy enemy)
            {
                enemy.Update(_levelData, _messageLog, _player);
            }
        }
    }
}
