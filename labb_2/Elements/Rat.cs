using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb_2.Elements;

internal class Rat : Enemy
{
    public Rat(int y, int x)
        : base(name:"rat",
            hp:10,
            attackDice: new Dice(1,6,3),
            defenceDice: new Dice(1, 6, 1),
            sprite:'r',
            color: ConsoleColor.Red,
            y, x)
    {}
    public override void Update()
    {

    }
}
