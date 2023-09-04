using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2._0
{
    internal class Snake : Line
    {
        public Snake(Symbol symbol, Direction direction=Direction.Left, int length = 3)
            : base(symbol, direction, length)
        {
        }

        public void Move(Direction direction)
        {
            Symbol tail = line.First();

        }
    }
}
