using labb_2.Elements;
using labb_2.Interfaces;
using labb_2.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace labb_2
{
    internal class Combat
    {
        private ICombatant Attacker { get; }
        private ICombatant Defender { get; }

        public Combat(ICombatant attacker, ICombatant defender)
        {
            Attacker = attacker;
            Defender = defender;
        }
        public void Battle(MessageLog messageLog, LevelData levelData)
        {
            int damage = Attack(Attacker.AttackDice, Defender.DefenceDice);
            Defender.HitPoints -= damage;

            messageLog.AddMassage($"{Attacker.Name} attacks {Defender.Name} for {damage} damage.");

            if (Defender.HitPoints <= 0)
            {
                messageLog.AddMassage($"{Defender.Name} is dead");
                Defender.Death(levelData);
                return;
            }

            Attacker.HitPoints -= Attack(Defender.AttackDice, Attacker.DefenceDice);

            messageLog.AddMassage($"{Defender.Name} Counter attaks {Attacker.Name} for {damage} damage.");
            if (Attacker.HitPoints <= 0)
            {
                messageLog.AddMassage($"{Attacker.Name} is dead");
                return;
            }
        }

        private int Attack(Dice atkDice, Dice defDice)
        {
            int damage = atkDice.Throw() - defDice.Throw();
            if (damage <= 0)
            {
                damage = 0;
            }

            return damage; 
        }
    }
}
