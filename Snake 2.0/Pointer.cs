using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2._0
{
    class Pointer : Symbol
    {
        public int Offset
        {
            get
            {
                return offset;
            }
            set
            {
                if (value < 0)
                {
                    offset = 4;
                }
                else if (value > 4)
                {
                    offset = 0;
                }
                else
                {
                    offset = value;
                }
            }
        }

        private int offset;
        private const int startY = 10;

        public Pointer(int x, int y = startY, char sign = '\u25ba')
            : base(x, y, sign)
        {
            Offset = 0;
        }

        public override void Move(Direction direction, int offset = 1)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
            switch (direction)
            {
                case Direction.Top:
                    Offset -= offset;
                    break;
                case Direction.Down:
                    Offset += offset;
                    break;
            }
            Y = startY + Offset;
        }

        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.DownArrow)
            {
                Move(Direction.Down);
            }
            else if (key == ConsoleKey.UpArrow)
            {
                Move(Direction.Top);
            }
        }
    }
}