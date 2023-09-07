using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2._0
{
    internal class Food : Symbol
    {
        static Random rnd = new Random();
        public Food()
        {
            Sign = '$';
            Create();
            Draw();
        }

        protected Food(int x, int y, char sign)
            : base(x, y, sign)
        { }

        public void Create()
        {
            X = rnd.Next(1, 99);
            Y = rnd.Next(1, 35);
        }

        public override void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Sign);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
