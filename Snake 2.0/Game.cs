using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2._0
{
    internal class Game
    {
        public static PlayersData pd;
        public static Player player;
        public static GameState State { get; set; }

        private Border border;
        private Dictionary<string, Scene> scenes;

        private const string start = "start";
        private const string game = "game";
        private const string registration = "registration";
        private const string enter = "enter";
        private const string leaderBoard = "leaderBoard";

        public Game(int widthScen, int heightScene)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            scenes = new Dictionary<string, Scene>();
            State = GameState.Start;
            border = new(widthScen, heightScene);

            scenes.Add(start, new StartScene(border));
            scenes.Add(game, new GameScene(border));
            scenes.Add(registration, new RegistrationScene(border));
            scenes.Add(enter, new EnterScene(border));
            scenes.Add(leaderBoard, new LeaderBoardScene(border));

            pd = new PlayersData();
            player=new Player();
        }

        public void Play()
        {
            while (true)
            {
                switch (State)
                {
                    case GameState.Start:
                        if (scenes[start].IsActive)
                        {
                            scenes[start].Draw();
                            scenes[start].Update();
                        }
                        else
                        {
                            scenes.Remove(start);
                            scenes.Add(start, new StartScene(border));
                        }
                        break;

                    case GameState.Play:
                        if (scenes[game].IsActive)
                        {
                            scenes[game].Draw();
                            scenes[game].Update();
                        }
                        else
                        {
                            scenes.Remove(game);
                            player.Score = 0;
                            scenes.Add(game, new GameScene(border));
                        }
                        break;

                    case GameState.Enter:
                        if (scenes[enter].IsActive) 
                        {
                            scenes[enter].Draw();
                            scenes[enter].Update();
                        } 
                        else 
                        {
                            scenes.Remove(enter);
                            scenes.Add(enter, new EnterScene(border));
                        }
                        break;

                    case GameState.CreateAccount:
                        scenes[registration].Draw();
                        scenes[registration].Update();
                        break;

                    case GameState.ViewRecordTable:
                        if (scenes[leaderBoard].IsActive) {
                            scenes[leaderBoard].Draw();
                            //scenes[leaderBoard].Update();
                        } else {
                            scenes.Remove(leaderBoard);
                            scenes.Add(leaderBoard, new LeaderBoardScene(border));
                        }
                        break;

                    case GameState.Quit:
                        pd.SaveData();
                        return;
                }
            }
        }
    }
}
