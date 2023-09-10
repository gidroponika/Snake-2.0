﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Snake_2._0
{
    enum GameState
    {
        Play,
        CreateAccount,
        ViewRecordTable,
        Quit
    }
    internal class StartScene : Scene
    {
        public Pointer pointer;
        public GameState state { get; private set; }
        public StartScene(Border border) : base(border)
        {
            isActive = true;
            state = GameState.Play;
            pointer = new Pointer(border.WidthScen / 2 - 7);
        }

        public override void Draw()
        {
            WriteTitle();
            pointer.Draw();
            WriteMenu();
            WriteHelp();
        }


        public override void Update()
        {
            while (isActive)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    pointer.HandleKey(key.Key);
                    pointer.Draw();
                    state = (GameState)pointer.Offset;

                    if (key.Key == ConsoleKey.Enter)
                    {
                        isActive = false;
                    }
                }
            }
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
            string message = "For navigation press arrows UP or DOWN. " +
                "For choice press ENTER";

            Console.SetCursorPosition(border.WidthScen / 2 - message.Length / 2, border.HeightScene - 3);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        void WriteMenu()
        {
            int x = pointer.X + 2, y = pointer.Y;
            string[] menu = { "PLAY", "ENTER / CREATE ACCOUNT",
                              "VIEW RECORDS TABLE", "QUIT" };

            for (int i = y; i < menu.Length + y; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.Write(menu[i - y]);
            }
        }
    }
}
