using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb_2.Elements;

internal class Snake : Enemy
{
    public Snake(int y, int x)
        : base(name: "Snake",
            hp: 25,
            attackDice: new Dice(3, 4, 2),
            defenceDice: new Dice(1, 8, 5),
            sprite: 's',
            color: ConsoleColor.Green,
            y, x)
    { }
    public override void Update()
    {

    }
}
