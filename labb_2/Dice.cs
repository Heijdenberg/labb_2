using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb_2;

internal class Dice
{
    private static readonly Random random = new Random();

    private int numberOfDice;
    private int sidesPerDice;
    private int modifier;

    public Dice(int numberOfDice, int sidesPerDice, int modifier)
    {
        this.numberOfDice = numberOfDice;
        this.sidesPerDice = sidesPerDice;
        this.modifier = modifier;
    }

    public int Throw()
    {
        int result = 0;

        for (int i = 0; i < numberOfDice; i++)
        {
            result += random.Next(1, sidesPerDice+1);
        }

        result += modifier;

        return result;
    }

    public override string ToString()
    {
        string diceNotation = $"{numberOfDice}D{sidesPerDice}";

        if (modifier > 0)
        {
            diceNotation += $"+{modifier}";
        }
        else if (modifier < 0)
        {
            diceNotation += $"{modifier}";
        }

            return diceNotation;
    }
}
