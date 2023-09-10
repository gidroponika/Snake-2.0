using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2._0
{
    internal class Game
    {
        Border border;
        Scene[] scenes = new Scene[3];
        public Game(int widthScen, int heightScene)
        {
            border = new(widthScen, heightScene);
            scenes[0] = new StartScene(border);
            scenes[1] = new GameScene(border);
        }

        internal void Play()
        {

        }
    }
}
