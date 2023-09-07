using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Snake_2._0
{
    internal class GameScene
    {
        bool isPlaying;
        Line top, left, right, down;
        Snake snake;
        Food food;
        int widthScen, heightScene, score;
        public GameScene(int widthScen, int heightScene)
        {
            this.widthScen = widthScen;
            this.heightScene = heightScene;
            score = 0;

            Console.SetWindowSize(widthScen, heightScene);
            Console.SetBufferSize(widthScen, heightScene);
            Console.CursorVisible = false;
            isPlaying = true;

            top = new Line(new Symbol(0, 0, '#'), Direction.Right, widthScen);
            left = new Line(new Symbol(0, 0, '#'), Direction.Down, heightScene - 10);
            right = new Line(new Symbol(widthScen - 1, 0, '#'), Direction.Down, heightScene - 10);
            down = new Line(new Symbol(0, heightScene - 10, '#'), Direction.Right, widthScen);
            snake = new Snake(new Symbol(45, 15, '@'));
            food = new Food();

            top.Draw();
            left.Draw();
            right.Draw();
            down.Draw();
            snake.Draw();
            AddScore();

            snake.Eated += CreateFood;
            snake.Eated += food.Draw;
            snake.Eated += AddScore;
        }

        public void Play()
        {
            while (isPlaying)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
                if (IsEated())
                {
                    snake.Grow();
                    score++;
                    snake.EventCall();
                }
                else
                {
                    snake.Move();
                }

                isPlaying = snake.EatYourself();

                Thread.Sleep(100);
            }
        }

        bool IsEated()
        {
            if (food.X == snake._Line.Last().X && food.Y == snake._Line.Last().Y)
            {
                return true;
            }
            return false;
        }

        void AddScore()
        {
            Console.SetCursorPosition(0, heightScene - 5);
            Console.Write($"Score {score}");
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
