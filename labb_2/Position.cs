using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb_2;

internal struct Position
{
    public int Y { get; set; }
    public int X { get; set; }

    public Position(int y, int x)
    {
        X = y;
        Y = x;
    }
}
