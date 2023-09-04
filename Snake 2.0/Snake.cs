using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2._0
{
    internal class Snake : Line
    {
        Direction direction;
        public new Direction Direction
        {
            get
            {
                return direction;
            }
            set
            {
                if ((direction == Direction.Left || direction == Direction.Right)
                    && (value == Direction.Top || value == Direction.Down))
                {
                    direction = value;
                }
                else if ((direction == Direction.Top || direction == Direction.Down)
                    && (value == Direction.Left || value == Direction.Right))
                {
                    direction = value;
                }
            }
        }

        public Snake(Symbol symbol, Direction direction=Direction.Left, int length = 3)
            : base(symbol, direction, length)
        {
            this.direction=direction;
        }

        public void Move()
        {
            Symbol tail = line.First();
            line.Remove(tail);
            Symbol newHead=GetNewHead();
            line.Add(newHead);

            newHead.Draw();
            tail.Clear();
        }

        public Symbol GetNewHead()
        {
            Symbol head = line.Last();
            Symbol newHead = new(head.X,head.Y,head.Sign);
            newHead.Move(1, Direction);
            return newHead;
        }
    }
}
