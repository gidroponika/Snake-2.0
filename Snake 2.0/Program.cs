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
            GameScene gameScene = new(100, 45);
            gameScene.Play();
        }
    }
}