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

            Line top = new Line(new Symbol(0, 0, '#'), 100, Direction.Right);
            Line left = new Line(new Symbol(0, 0, '#'), 35, Direction.Down);
            Line right = new Line(new Symbol(99, 0, '#'), 35, Direction.Down);
            Line down = new Line(new Symbol(0, 35, '#'), 100, Direction.Right);
            Food food = new Food();

            top.Draw();
            left.Draw();
            right.Draw();
            down.Draw();

            while (true)
            {
                Thread.Sleep(100);
                food.Create();
                food.Draw();
            }
        }
    }
}