using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2._0 {
    internal class LeaderBoardScene : Scene {
        public LeaderBoardScene(Border border) : base(border)
        {
        }

        public override void Update()
        {
            //TODO:
            //
        }

        public override void Draw()
        {
            base.Draw();
            int maxLenth = 3;

            foreach (Player player in Game.pd.Players)
            {
                if (player.Login.Length > maxLenth)
                {
                    maxLenth += player.Login.Length;
                }
            }

            foreach(Player player in Game.pd.Players) 
            {
                string name=player.Login.PadRight(maxLenth,'.');
                Console.WriteLine($"{name}{player.Record}");
            }

            Console.ReadKey();
            IsActive = false;
            Game.State = GameState.Start;
            Console.CursorVisible = false;
            return;
        }
    }
}
