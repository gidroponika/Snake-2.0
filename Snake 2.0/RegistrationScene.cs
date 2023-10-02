using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2._0
{
    internal class RegistrationScene : Scene
    {
        public RegistrationScene(Border border)
            : base(border)
        {
        }

        public override void Draw()
        {
            base.Draw();
            Console.CursorVisible = true;
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
        }

        public override void Update()
        {
            string login;
            string password;

            Console.WriteLine("Для виходу з форми регістрації введіть 'exit'");
            Console.WriteLine();

        GoHere:
            while (true)
            {
                Console.Write("Введіть свій логін: ");
                login = Console.ReadLine();
                login = login.Trim();

                Exit(login);

                foreach (var player in Game.pd.Players) {
                    if (login == player.Login || login == "anonim") {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Цей логін зайнято. Виберіть інший");
                        Console.ResetColor();
                        goto GoHere;
                    }
                }

                if (string.IsNullOrEmpty(login) || login.Length < 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ваш логін занадто короткий");
                    Console.ResetColor();
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine();

            while (true)
            {
                Console.Write("Введіть свій пароль: ");
                password = Console.ReadLine();
                password =password.Trim();

                Exit(password);

                if (string.IsNullOrEmpty(password) || password.Length < 5)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ваш пароль занадто короткий");
                    Console.ResetColor();
                }
                else
                {
                    break;
                }
            }

            Game.pd.CreateNewPlayer(login, password);
            Exit();
        }

        private void Exit(string word="exit")
        {
            if (word == "exit") {
                IsActive = false;
                Game.State = GameState.Start;
                Console.CursorVisible = false;
                return;
            }
        }
    }
}
