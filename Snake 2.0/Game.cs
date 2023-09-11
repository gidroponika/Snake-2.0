using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Snake_2._0
{
    enum GameState
    {
        Start=-1,
        Play,
        CreateAccount,
        ViewRecordTable,
        Quit
    }
    internal class Game
    {
        public static GameState state=GameState.Start;
        public static Player player;

        Border border;
        Dictionary<string,Scene> scenes = new Dictionary<string, Scene>();

        public Game(int widthScen, int heightScene)
        {
            border = new(widthScen, heightScene);
            scenes.Add("start", new StartScene(border));
            scenes.Add("game", new GameScene(border));
            scenes.Add("registration", new RegistrationScene(border));
        }

        internal void Play(string q)
        {
            //scenes["start"]
            //start.Draw();
            //start.Update();
            if (state == GameState.Play)
            {
                scenes["game"].Draw();
                scenes["game"].Update();
            }else if (state == GameState.CreateAccount)
            {
                scenes["registration"].Draw();
                scenes["registration"].Update();
            }
            else if (state == GameState.ViewRecordTable)
            {

            }
            else if (state == GameState.Quit)
            {
                Console.Clear();
                return;
            }
        }

        public void Play()
        {
            while (true)
            {
                switch (state)
                {
                    case GameState.Start:
                        if (scenes["start"].IsActive)
                        {
                            scenes["start"].Draw();
                            scenes["start"].Update();
                        }
                        else
                        {
                            scenes.Remove("start");
                            scenes.Add("start", new StartScene(border));
                        }
                        break;
                    case GameState.Play:
                        if (scenes["game"].IsActive)
                        {
                            scenes["game"].Draw();
                            scenes["game"].Update();
                        }
                        else
                        {
                            scenes.Remove("game");
                            scenes.Add("game", new GameScene(border));
                        }
                        break;
                    case GameState.CreateAccount:
                        scenes["registration"].Draw();
                        scenes["registration"].Update();
                        break;
                    case GameState.Quit:
                        return;
                }
            }
        }
    }
}
