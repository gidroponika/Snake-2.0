using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2._0
{
    internal class Food : Symbol
    {
        Random rnd=new Random();
        public Food()
        {
            Token = '*';
            Create();
            Draw();
        }
        private Food(int x, int y, char token) 
            : base(x, y, token)
        {
        }
        public void Create()
        {
            X = rnd.Next(1, 99);
            Y = rnd.Next(1, 35);
        }

        public override void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Token);
            Console.ForegroundColor= ConsoleColor.Gray;
        }
    }
}
