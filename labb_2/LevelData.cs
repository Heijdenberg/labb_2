using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb_2;

internal class LevelData
{
    private char[,] level;
    public int[] levelSize = new int[2];
    private string path = Path.Combine("Levels", "Level1.txt");
    public LevelData()
    {
        levelSize = GetLevelSize();
        level = LoadLevel();
    }

    private int[] GetLevelSize()
    {
        int y = 0;
        int x = 0;

        using (StreamReader reader = new StreamReader(path))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                y++;
                int length;
                string trimmedLine = line.TrimEnd();
                if ((length = trimmedLine.Length) > x)
                {
                    x = length;
                }
            }
        }

        return [y,x];
    }
    private char[,] LoadLevel()
    {
        int y = levelSize[0];
        int x = levelSize[1];

        char[,] level = new char[y, x];

        using (StreamReader reader = new StreamReader(path))
        {
            string line;
            int row = 0;

            while ((line = reader.ReadLine()) != null)
            {
                for (int i = 0; i < x; i++)
                {
                    level[row,i] = line[i];
                }

                row++;
            }
        }

        return level;
    }
    public override string ToString()
    {
        string levelString = string.Empty;

        for (int i = 0; i < levelSize[0]; i++)
        {
            for (int ii = 0; ii < levelSize[1]; ii++)
            {
                char currentChar = level[i, ii];
                levelString += currentChar;
                levelString += " ";
            }
            levelString += Environment.NewLine;
        }

        return levelString;
    }
}
