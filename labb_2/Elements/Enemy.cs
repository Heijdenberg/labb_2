using labb_2.Core;
using labb_2.Interfaces;
using labb_2.UI;
using labb_2.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace labb_2.Elements;

internal abstract class Enemy: LevelElement, ICombatant
{
    public string Name { get; }
    public int HitPoints { get; set; }
    public Dice AttackDice { get; }
    public Dice DefenceDice { get; }

    public Enemy(string name, int hp, Dice attackDice, Dice defenceDice, char sprite, ConsoleColor color, int y, int x)
        : base(sprite, color, y, x)
    {
        Name = name;
        HitPoints = hp;
        AttackDice = attackDice;
        DefenceDice = defenceDice;
    }
    public override void Draw()
    {
        base.Draw();
    }
    public virtual void Draw(Player player)
    {
        if (GameMath.IsWithinRange(Position, player.Position, player.VisionRange))
        {
            base.Draw();
        }
        else
        {
            Renderer.EraseAtCord(Position);
        }
    }
    public abstract void Update(LevelData levelData, MessageLog messageLog, Player player);

    public void Death(LevelData leveldata)
    {
        leveldata.removeElement(Position.Y,Position.X);
    }
}
