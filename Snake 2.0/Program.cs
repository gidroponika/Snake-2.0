namespace Snake_2._0
{
    enum Direction
    {
        Left,
        Right,
        Top,
        Down
    }
    internal class Program
    {
        static void Main()
        {
            Console.SetWindowSize(100, 45);
            Console.SetBufferSize(100, 45);
            Console.CursorVisible = false;

            Line top = new Line(new Symbol(0, 0, '#'), Direction.Right, 100);
            Line left = new Line(new Symbol(0, 0, '#'), Direction.Down, 36);
            Line right = new Line(new Symbol(99, 0, '#'), Direction.Down, 36);
            Line down = new Line(new Symbol(0, 36, '#'), Direction.Right, 100);
            Snake snake = new Snake(new Symbol(45, 15, '@'));
            //Food food = new Food();

            top.Draw();
            left.Draw();
            right.Draw();
            down.Draw();
            snake.Draw();

            while (true)
            {
                //snake.Move(snake.direction);
                //Thread.Sleep(300);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key= Console.ReadKey();
                    if(key.Key == ConsoleKey.DownArrow)
                    {
                        snake.Direction = Direction.Down;
                    }else if(key.Key == ConsoleKey.UpArrow)
                    {
                        snake.Direction = Direction.Top;
                    }else if(key.Key == ConsoleKey.LeftArrow)
                    {
                        snake.Direction = Direction.Left;
                    }else if(key.Key == ConsoleKey.RightArrow)
                    {
                        snake.Direction = Direction.Right;
                    }
                }
                snake.Move();
                Thread.Sleep(300);
            }
            //Console.SetCursorPosition(0, 37);
        }
    }
}