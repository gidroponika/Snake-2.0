using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2._0
{
    internal class Symbol
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public char Token{ get; protected set; }

        protected Symbol() { }

        public Symbol(int x,int y,char token)
        {
            X = x;
            Y = y;
            Token = token;
        }

        public virtual void Draw()
        {
            Console.SetCursorPosition(X,Y);
            Console.Write(Token);
        }

        public virtual void Draw(int x,int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(Token);
        }
    }
}
