using labb_2.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace labb_2.UI
{
    internal class Renderer
    {
        private LevelData _levelData;
        private Player _player;
        private MessageLog _messageLog;
        private Sidebar _sidebar;

        public Renderer(LevelData levelData, Player player, MessageLog messageLog, Sidebar sidebar)
        {

            _levelData = levelData;
            _player = player;
            _messageLog = messageLog;
            _sidebar = sidebar;
        }

        public void DrawAll()
        {
            foreach (LevelElement x in _levelData.Elements)
            {
                x.Draw();
            }

            _player.Draw();
            _messageLog.Draw();
            _sidebar.Draw();
        }
    }
}
