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
        private int score;

        private readonly Snake snake;
        private readonly Food food;

        public GameScene(Border border)
            : base(border)
        {
            score = 0;
            IsActive = true;

            snake = new(new Symbol(border.WidthScen / 2, border.HeightScene / 2, '\u263a'));
            food = new();

            snake.Eated += CreateFood;
            snake.Eated += food.Draw;
            snake.Eated += AddScore;
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
                    score++;
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

            Console.Clear();
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
            AddScore();
        }

        private bool IsEated()
        {
            if (food.X == snake.GetHead().X && food.Y == snake.GetHead().Y)
            {
                return true;
            }
            return false;
        }

        private void AddScore()
        {
            Console.SetCursorPosition(0, border.HeightScene - 5);
            //Console.WriteLine($"Score {score}");
            Console.WriteLine($"{Game.player.Login} {score}");
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
