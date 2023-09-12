namespace Snake_2._0
{
    enum Direction
    {
        Left,
        Right,
        Top,
        Down
    }

    enum GameState
    {
        Start = -1,
        Play,
        CreateAccount,
        ViewRecordTable,
        Quit
    }
    internal class Program
    {
        static void Main()
        {
            Game game = new(100, 45);
            game.Play();
        }
    }
}