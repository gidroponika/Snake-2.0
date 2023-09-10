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
            Border border = new(100, 45);
            StartScene start = new(border);
            start.Draw();
            start.Update();

            GameScene gameScene = new(border);
            gameScene.Draw();
            gameScene.Update();

            //Game game = new(100, 45);
            //game.Play();
        }
    }
}