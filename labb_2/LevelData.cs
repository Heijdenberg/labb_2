using labb_2.Elements;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace labb_2;

internal class LevelData
{
    private List<LevelElement> _elements = new();
    private int _levelWidth =  0;
    public int LevelHeight { get; set; }
    public int LevelWidth 
    {
        get
        {
            return _levelWidth;
        } 
        set
        { 
            if(value> _levelWidth)
            {
                _levelWidth = value;
            }
        }
    }
    public List<LevelElement> Elements
    {
        get
        {
            return _elements;
        }
    }

    public int[] Load(string path)
    {
        int[] startPosition = [0, 0];
        using (StreamReader reader = new StreamReader(path))
        {
            string line;

            for (int i = 0; (line = reader.ReadLine()) != null; i++)
            {
                for (int ii = 0; ii < line.Length; ii++)
                {
                    switch (line[ii])
                    {
                        case '@':
                            startPosition = [i, ii];
                            break;
                        case '#':
                            _elements.Add(new Wall(i, ii));
                            LevelWidth = ii;
                            LevelHeight = i;
                            break;
                        case 'r':
                            _elements.Add(new Rat(i, ii));
                            break;
                        case 's':
                            _elements.Add(new Snake(i, ii));
                            break;
                    }
                }
            }
        }
        return startPosition;
    }

    public LevelElement GetElementAtPosition(int y, int x)
    {
        LevelElement? inhabitant = null;


        for (int i = 0; i < Elements.Count; i++)
        {
            if (Elements[i].Position.Y==y && Elements[i].Position.X == x)
            {
                inhabitant = Elements[i];
            }
        }
        return inhabitant;
    }
    public int GetElementIndexAtPosition(int y, int x)
    {
        int index=-1;

        for (int i = 0; i < Elements.Count; i++)
        {
            if (Elements[i].Position.Y == y && Elements[i].Position.X == x)
            {
                index = i;
            }
        }
        return index;
    }
    public void removeElement(int y, int x)
    {
        int index = GetElementIndexAtPosition(y, x);
        Elements.RemoveAt(index);
    }
}
