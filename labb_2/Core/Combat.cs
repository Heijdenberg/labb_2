using labb_2.Elements;
using labb_2.Interfaces;
using labb_2.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace labb_2.Core;

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

        if (damage < 0)
        {
            damage = 0;
        }

        Defender.HitPoints.HP -= damage;

        messageLog.AddMassage($"{Attacker.Name} attacks {Defender.Name} for {damage} damage.");

        if (Defender.HitPoints.HP <= 0)
        {
            messageLog.AddMassage($"{Defender.Name} is dead");
            Defender.Death(levelData);
            return;
        }

        int counterDamage = Attack(Defender.AttackDice, Attacker.DefenceDice);

        if (counterDamage < 0)
        {
            counterDamage = 0;
        }
        Attacker.HitPoints.HP -= counterDamage;

        messageLog.AddMassage($"{Defender.Name} Counter attacks {Attacker.Name} for {counterDamage} damage.");
        if (Attacker.HitPoints.HP <= 0)
        {
            messageLog.AddMassage($"{Attacker.Name} is dead");
            Attacker.Death(levelData);
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
