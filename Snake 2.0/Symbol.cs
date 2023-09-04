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
        public char Sign { get; protected set; }

        protected Symbol() { }

        public Symbol(int x, int y, char sign)
        {
            X = x;
            Y = y;
            Sign = sign;
        }

        public void Move(int offset,Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    X -= offset;
                    break;
                case Direction.Right:
                    X += offset;
                    break;
                case Direction.Top:
                    Y -= offset;
                    break;
                case Direction.Down:
                    Y += offset;
                    break;
            }
        }

        public virtual void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Sign);
        }

        public void Clear()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
        }
    }
}
