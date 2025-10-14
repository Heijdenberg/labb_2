using labb_2.Elements;
using labb_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace labb_2.UI;

internal class Renderer
{
    private LevelData _levelData;
    private Player _player;
    private MessageLog _messageLog;
    private Sidebar _sidebar;

    public Renderer(LevelData levelData, Player player, MessageLog messageLog, Sidebar sidebar)
    {

        _levelData = levelData;
        _player = player;
        _messageLog = messageLog;
        _sidebar = sidebar;
    }

    public void DrawAll()
    {      
        foreach (LevelElement element in _levelData.Elements)
        {
            if(element is IPlayerAwareDrawable iPlayerAwareDrawable)
            {
                iPlayerAwareDrawable.Draw(_player);
            }
            else
            {
                element.Draw();
            } 
        }

        _player.Draw();
        _messageLog.Draw();
        _sidebar.Draw();
    }

    static public void EraseAtCord(Position position)
    {
        //if (position.X < 0 || position.Y < 0)
        //{
        //    return;
        //}
        //else if (position.X >= Console.BufferWidth || position.Y >= Console.BufferHeight)
        //{
        //    return;
        //}

        Console.SetCursorPosition(position.X, position.Y);
        Console.Write('x');
    }
}
