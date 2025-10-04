using labb_2.Elements;
using labb_2.Interfaces;
using labb_2.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace labb_2;

internal class Player : LevelElement, ICombatant
{
    public string Name { get; }
    public int HitPoints { get; set; }
    public Dice AttackDice { get; }
    public Dice DefenceDice { get; }
    public Player(int[] startPosition)
        : base(
            sprite: '@',
            spriteColor: ConsoleColor.Red,
            startPosition[0], startPosition[1])
    {
        Name = "Player";
        AttackDice = new(2, 6, 2);
        DefenceDice = new(2, 6, 0);
        HitPoints = 100;
    }

    public void Death(LevelData levelData)
    {
        GameOverScreen gameOver = new();
        gameOver.GameOver(levelData.LevelHeight, levelData.LevelWidth);
    }
    public void Move(ConsoleKey direction, LevelData levelData, MessageLog messageLog)
    {
        int y = Position.Y;
        int x = Position.X;
        
        if(direction == ConsoleKey.UpArrow || direction == ConsoleKey.W)
        {
            x--; 
        }
        else if (direction == ConsoleKey.LeftArrow || direction == ConsoleKey.A)
        {
            y--;
        }
        else if (direction == ConsoleKey.DownArrow || direction == ConsoleKey.S)
        {
            x++;
        }
        else if (direction == ConsoleKey.RightArrow || direction == ConsoleKey.D)
        {
            y++;
        }
        LevelElement nextPostionInhabitant = levelData.GetElementAtPosition(y, x);

        if (nextPostionInhabitant == null)
        {
            Position.Y = y;
            Position.X = x;
        }
        else if (nextPostionInhabitant is Enemy)
        {
            messageLog.AddMassage("Found an Enemy!");
            Combat combat = new(this, (ICombatant)nextPostionInhabitant);
            combat.Battle(messageLog, levelData);
        }
    }
}
