using System.Security.Cryptography;

namespace labb_2;

internal class Program
{
    static void Main()
    {
        while (true)
        {
            LevelData level = new LevelData();
            Console.WriteLine(level.ToString());
            Console.ReadLine();
            Console.Clear();
        }

    }
}

