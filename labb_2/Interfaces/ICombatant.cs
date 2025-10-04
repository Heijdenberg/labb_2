using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb_2.Interfaces
{
    internal interface ICombatant
    {
        string Name { get; }
        int HitPoints { get; set; }
        Dice AttackDice { get; }
        Dice DefenceDice { get; }
        public void Death(LevelData leveldata);
    }
}
