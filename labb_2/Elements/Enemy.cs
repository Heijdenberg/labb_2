using labb_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public abstract void Update();

    public void Death(LevelData leveldata)
    {
        leveldata.removeElement(Position.Y,Position.X);
    }
}
