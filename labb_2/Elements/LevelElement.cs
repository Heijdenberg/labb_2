using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb_2.Elements;

internal abstract class LevelElement
{
    protected char Sprite { get; }
    public Position Position { get; set; }
    public ConsoleColor SpriteColor { get; }

    protected LevelElement(char sprite, ConsoleColor spriteColor, int y, int x)
    {
        Sprite = sprite;
        SpriteColor = spriteColor;
        Position = new Position(y, x);
    }

    public void Draw() { }
}
