using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.Clear();
            Console.CursorVisible = true;
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
        }

        public override void Update()
        {
            string login;
            string password;

            while (true)
            {
                Console.Write("Введіть свій логін: ");
                login = Console.ReadLine();
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

            Game.State = GameState.Start;
            Console.CursorVisible = false;
        }
    }
}
