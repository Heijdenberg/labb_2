using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb_2.UI
{
    internal class MessageLog
    {
        private List<string> _messages = new() { "", "", "", "","" };
        private int _maxMessages = 5;
        private int StartRow { get; set; }
        private int MaxWidth { get; set; }

        public MessageLog(int atartRow, int maxWidth)
        {
            StartRow = atartRow;
            MaxWidth = maxWidth;
            Draw();
        }

        public void Draw()
        {
            Console.SetCursorPosition(0, StartRow+1);
            string messageBox = "";
            messageBox += $"╔{new string('═', MaxWidth - 2)}╗\n";
            foreach (string message in _messages)
            {
                string messageLine = $"║{message}{new string(' ', MaxWidth - 2)}{new string(' ', MaxWidth - 2)}";
                messageLine = messageLine.Substring(0, MaxWidth - 1);
                messageLine += "║\n";
                messageBox += messageLine;
            }
            messageBox += $"╚{new string('═', MaxWidth - 2)}╝\n";
            Console.WriteLine(messageBox);
        }

        public void AddMassage(string newMessages)
        {
            _messages.Insert(0, newMessages);

            if (_messages.Count > _maxMessages)
            {
                _messages.RemoveAt(_messages.Count - 1);
            }
            Draw();
        }
    }
}
