using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Snake_2._0
{

    internal class Game
    {
        public static GameState State { get; set; }

        private Border border;
        private Dictionary<string, Scene> scenes;

        private const string start = "start";
        private const string game = "game";
        private const string registration = "registration";

        public Game(int widthScen, int heightScene)
        {
            scenes = new Dictionary<string, Scene>();
            State = GameState.Start;
            border = new(widthScen, heightScene);
            scenes.Add(start, new StartScene(border));
            scenes.Add(game, new GameScene(border));
            scenes.Add(registration, new RegistrationScene(border));
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
                            scenes.Add(game, new GameScene(border));
                        }
                        break;

                    case GameState.CreateAccount:
                        scenes[registration].Draw();
                        scenes[registration].Update();
                        break;
                    case GameState.ViewRecordTable:
                        return;
                    case GameState.Quit:
                        return;
                }
            }
        }
    }
}
