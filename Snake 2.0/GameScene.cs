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
        Line top;
        Line left;
        Line right;
        Line down;
        Snake snake;

        public GameScene(int widthScen, int heightScene) 
        {
            Console.SetWindowSize(widthScen, heightScene);
            Console.SetBufferSize(widthScen, heightScene);
            Console.CursorVisible = false;
            isPlaying = true;

            top = new Line(new Symbol(0, 0, '#'), Direction.Right, 100);
            left = new Line(new Symbol(0, 0, '#'), Direction.Down, 36);
            right = new Line(new Symbol(widthScen-1, 0, '#'), Direction.Down, 36);
            down = new Line(new Symbol(0, heightScene-10, '#'), Direction.Right, 100);
            snake = new Snake(new Symbol(45, 15, '@'));

            top.Draw();
            left.Draw();
            right.Draw();
            down.Draw();
            snake.Draw();
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
                snake.Move();
                Thread.Sleep(100);
            }
        }
        
            //Console.SetCursorPosition(0, 37);
    }
}
