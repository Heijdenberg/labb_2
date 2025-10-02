using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb_2.Elements;

internal abstract class Enemy: LevelElement
{
    protected string Name { get; }
    protected int HitPoints { get; set; }
    protected Dice AttackDice { get; }
    protected Dice DefenceDice { get; }

    public Enemy(string name, int hp, Dice attackDice, Dice defenceDice, char sprite, ConsoleColor color, int y, int x)
        : base(sprite, color, y, x)
    {
        Name = name;
        HitPoints = hp;
        AttackDice = attackDice;
        DefenceDice = defenceDice;
    }
    public abstract void Update();
}
