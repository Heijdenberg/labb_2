using labb_2.Components;
using labb_2.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb_2.Interfaces;

internal interface ICombatant
{
    string Name { get; }
    HitPoints HitPoints { get; set; }
    Dice AttackDice { get; }
    Dice DefenceDice { get; }
    public void Death(LevelData leveldata);
}
