using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2._0
{
    internal class EnterScene : Scene
    {
        public EnterScene(Border border) : base(border)
        {
        }

        public override void Draw()
        {
            base.Draw();
            Console.CursorVisible = true;
        }

        public override void Update()
        {
            string login;
            string password;

            /*Console.Write("Введіть свій логін: ");
            login = Console.ReadLine();

            Console.WriteLine();
            Console.Write("Введіть свій пароль: ");
            password = Console.ReadLine();

            Player p = Game.pd.GetPlayer(login, password);

            if (p != null)
            {
                Game.player = Game.pd.GetPlayer(login, password);
            }*/
            Console.WriteLine("Для виходу з форми регістрації введіть 'exit'");
            Console.WriteLine();

            while (true) 
            {
                Console.Write("Введіть свій логін: ");
                login = Console.ReadLine();

                if(login == "exit") 
                {
                    IsActive = false;
                    Game.State = GameState.Start;
                    Console.CursorVisible = false;
                    return;
                }
                Console.WriteLine();
                Console.Write("Введіть свій пароль: ");
                password = Console.ReadLine();

                Player p = Game.pd.GetPlayer(login, password);

                if (p != null) {
                    Game.player = Game.pd.GetPlayer(login, password);
                    break;
                } 
                else 
                {
                    Console.WriteLine("Гравця не знайдено. Спробуйте ще раз");
                }
            }

            IsActive = false;
            Game.State = GameState.Start;
            Console.CursorVisible = false;

            /*foreach(var player in Game.pd.Players)
            {
                if(login == player.Login && password == player.Pas)
            }*/

            /*while (true)
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
            }*/

            /*Console.WriteLine();

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

            Game.pd.CreateNewPlayer(login, password);
            Game.State = GameState.Start;
            Console.CursorVisible = false;*/
        }
    }
}
