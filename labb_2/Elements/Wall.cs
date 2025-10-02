using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb_2.Elements;

internal class Wall : LevelElement
{
    public bool HasBeenSeen { get; set; }
    public Wall(int y, int x) : base('#', ConsoleColor.Gray, y, x){}
}
