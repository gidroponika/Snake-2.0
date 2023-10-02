using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Snake_2._0
{
    internal class GameScene : Scene
    {
        private readonly Snake snake;
        private readonly Food food;

        public GameScene(Border border)
            : base(border)
        {
            IsActive = true;
            
            snake = new(new Symbol(border.WidthScen / 2, border.HeightScene / 2, '\u263a'));
            food = new();


            snake.Eated += CreateFood;
            snake.Eated += food.Draw;
            snake.Eated += CountScore;
            snake.Eated += WriteInfo;
        }

        public override void Update()
        {
            while (IsActive)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }

                if (IsEated())
                {
                    snake.Eat();
                    snake.EventCall();
                }
                else
                {
                    snake.Move();
                }

                IsActive = snake.IsEatYourself() && border.IsOutBorder(snake.GetHead());
                Game.State = GameState.Start;

                Thread.Sleep(snake.Speed);
            }

            WriteGameOver();
            Console.ReadKey();
            Game.player.Score = 0;
        }

        private void WriteGameOver()
        {
            string[] gameOver = {"▄███▄ ▄██▄ █▄ ▄█ █▀▀▀   ▄██▄ █  █ █▀▀▀ █▀▀▄",
                                 "█     █  █ █ ▀ █ █▄▄    █  █ █  █ █▄▄  █▄▄▀",
                                 "█  ▀█ █▀▀█ █   █ █      █  █ █  █ █    █ █ ",
                                 "▀███▀ █  █ █   █ █▄▄▄   ▀██▀ ▀██▀ █▄▄▄ █  █",

            };
            int x=border.WidthScen/2- gameOver[0].Length/2;
            int y = 10;

            Console.ForegroundColor = ConsoleColor.Red;
            for(int i=0;i<gameOver.Length;i++)
            {
                Console.SetCursorPosition(x, y+i);
                Console.Write(gameOver[i]);
            }
            Console.ResetColor();
        }

        public override void Draw()
        {
            base.Draw();
            border.Draw();
            snake.Draw();
            food.Draw();
            WriteInfo();
        }

        private bool IsEated()
        {
            if (food.X == snake.GetHead().X && food.Y == snake.GetHead().Y)
            {
                return true;
            }
            return false;
        }

        private void WriteInfo()
        {
            Console.SetCursorPosition(0, border.HeightScene - 5);
            Console.WriteLine($"{Game.player.Login}");
            Console.WriteLine($"Score : {Game.player.Score}");
            Console.WriteLine($"Your record : {Game.player.Record}");
        }
        private void CountScore()
        {
            Game.player.Score++;
            if (Game.player.Score > Game.player.Record) {
                Game.player.Record=Game.player.Score;
            }
        }
        private void CreateFood()
        {
            food.Create();
            foreach (Symbol sym in snake.ListSymbols)
            {
                if (food.X == sym.X && food.Y == sym.Y)
                {
                    CreateFood();
                }
            }
        }
    }
}
