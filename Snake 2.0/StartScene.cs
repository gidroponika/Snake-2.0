using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Snake_2._0
{
    internal class StartScene : Scene
    {
        private Pointer pointer;
        public StartScene(Border border) : base(border)
        {
            IsActive = true;
            pointer = new Pointer(border.WidthScen / 2 - 7);
        }

        public override void Draw()
        {
            base.Draw();
            WriteTitle();
            pointer.Draw();
            WriteMenu();
            WriteHelp();
        }

        public override void Update()
        {
            while (IsActive)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    pointer.HandleKey(key.Key);
                    pointer.Draw();
                    Game.State = (GameState)pointer.Offset;

                    if (key.Key == ConsoleKey.Enter)
                    {
                        Game.State = (GameState)pointer.Offset;
                        IsActive = false;
                    }
                }
            }
            IsActive = false;
        }

        void WriteTitle()
        {
            int offset = 3;
            Console.ForegroundColor = ConsoleColor.Red;
            string[] title = { " @@@   @    @     @     @  @   @@@@@",
                               "@   @  @@   @    @ @    @ @    @    ",
                               " @     @ @  @   @   @   @@     @    ",
                               "   @   @  @ @   @@@@@   @ @    @@@  ",
                               "@   @  @   @@  @     @  @  @   @    ",
                               " @@@   @    @  @     @  @   @  @@@@@"};

            for (int i = 3; i < title.Length + offset; i++)
            {
                Console.SetCursorPosition(border.WidthScen / 2 - 19, i);
                Console.WriteLine(title[i - 3]);
            }
            Console.ResetColor();
        }

        void WriteHelp()
        {
            string helloMessage = $"Hello, {Game.player.Login}";
            string record = $"Your record is {Game.player.Record}";
            string message = $"For navigation press {'\u2191'} or {'\u2193'}. " +
                "For choice press ENTER";

            Console.SetCursorPosition(border.WidthScen / 2 - helloMessage.Length / 2, border.HeightScene - 10);
            Console.ForegroundColor= ConsoleColor.Cyan;
            Console.Write(helloMessage);
            Console.ResetColor();

            Console.SetCursorPosition(border.WidthScen / 2 - record.Length / 2, border.HeightScene - 9);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(record);
            Console.ResetColor();


            Console.SetCursorPosition(border.WidthScen / 2 - message.Length / 2, border.HeightScene - 3);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(message);
            Console.ResetColor();
        }

        void WriteMenu()
        {
            int x = pointer.X + 2, y = pointer.Y;
            string[] menu = { "PLAY", $"ENTER","CREATE ACCOUNT",
                              "VIEW RECORDS TABLE", "QUIT" };

            for (int i = y; i < menu.Length + y; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.Write(menu[i - y]);
            }
        }
    }
}
