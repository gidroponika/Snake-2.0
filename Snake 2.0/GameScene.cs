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
        int score;

        Snake snake;
        Food food;

        public GameScene(Border border)
            : base(border)
        {
            score = 0;
            IsActive = true;

            snake = new(new Symbol(border.WidthScen / 2, border.HeightScene / 2, '@'));
            food = new();

            snake.Eated += CreateFood;
            snake.Eated += food.Draw;
            snake.Eated += AddScore;
        }

        public override void Update()
        {
            IsActive = true;
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
                Game.state = GameState.Start;
                

                Thread.Sleep(snake.Speed);
            }
            Console.Clear();
        }

        public override void Draw()
        {
            Console.Clear();
            border.Draw();
            snake.Draw();
            food.Draw();
            AddScore();
        }

        bool IsEated()
        {
            if (food.X == snake.GetHead().X && food.Y == snake.GetHead().Y)
            {
                return true;
            }
            return false;
        }

        void AddScore()
        {
            Console.SetCursorPosition(0, border.HeightScene - 5);
            Console.WriteLine($"Score {score}");
        }

        void CreateFood()
        {
            food.Create();
            foreach (Symbol sym in snake._Line)
            {
                if (food.X == sym.X && food.Y == sym.Y)
                {
                    CreateFood();
                }
            }
        }
    }
}
