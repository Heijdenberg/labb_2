using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace labb_2.UI
{
    internal class NameScreen
    {
        public static string SetName(int hight, int width)
        {
            DrawBox(hight, width);

            Console.SetCursorPosition((width / 2) - 10, (hight / 2));
            Console.Write("Name: ");
            string name = Console.ReadLine();
            name = char.ToUpper(name[0]) + name.Substring(1);

            Console.Clear();
            DrawBox(hight, width);

            Console.SetCursorPosition((width / 2) - 10, (hight / 2));
            Console.WriteLine($"Welcome {name}!!!");
            Thread.Sleep(1500);

            Console.Clear();

            return name;
        }

        private static void DrawBox(int hight, int width)
        {
            Console.SetCursorPosition(0,0);
            Console.WriteLine($"╔{new string('═', width - 2)}╗");
            for (int ii = 0; ii < hight - 2; ii++)
            {
                Console.WriteLine($"║{new string(' ', width - 2)}║");
            }
            Console.WriteLine($"╚{new string('═', width - 2)}╝");
        }
    }
}
