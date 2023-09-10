using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2._0
{
    class Pointer : Symbol
    {
        int offset;
        const int START_Y = 10;

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
                    offset = 3;
                }
                else if (value > 3)
                {
                    offset = 0;
                }
                else
                {
                    offset = value;
                }
            }
        }

        public Pointer(int x, int y = START_Y, char sign = '>')
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
            Y = START_Y + Offset;
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
            else if (key == ConsoleKey.Enter)
            {

            }
        }
    }
}