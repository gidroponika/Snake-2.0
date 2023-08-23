using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2._0
{
    internal class Symbol
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public char Token{ get; private set; }

        public Symbol(int x,int y,char token)
        {
            X = x;
            Y = y;
            Token = token;
        }

        public void Draw()
        {
            Console.SetCursorPosition(X,Y);
            //Console.Write(' ');
            Console.Write(Token);
        }

        public void Draw(int x,int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            Console.Write(Token);
        }
    }
}
