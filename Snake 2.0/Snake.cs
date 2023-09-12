using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Snake_2._0
{
    internal class Snake : Line
    {
        public event Action Eated;

        public int Speed
        {
            get { return speed; }
            set
            {
                if (Direction == Direction.Right || Direction == Direction.Left)
                {
                    speed = value;
                }
                else
                {
                    speed = (int)(value * 1.5);
                }
            }
        }
        public Direction Direction
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

        private int speed;
        private Direction direction;

        public Snake(Symbol symbol, Direction direction = Direction.Left, int length = 3)
            : base(symbol, direction, length)
        {
            speed = 100;
            this.direction = direction;
        }

        public void Move()
        {
            Symbol tail = ListSymbols.First();
            ListSymbols.Remove(tail);
            Symbol newHead = GetNewHead();
            ListSymbols.Add(newHead);

            newHead.Draw();
            tail.Clear();
        }

        public void Eat()
        {
            Symbol head = GetNewHead();
            ListSymbols.Add(head);
            head.Draw();
        }

        public Symbol GetHead()
        {
            return ListSymbols.Last();
        }

        public bool IsEatYourself()
        {
            for (int i = 0; i < ListSymbols.Count - 1; i++)
            {
                if (ListSymbols.Last().X == ListSymbols[i].X && ListSymbols.Last().Y == ListSymbols[i].Y)
                {
                    return false;
                }
            }
            return true;
        }

        public void EventCall()
        {
            Eated.Invoke();
        }

        public void HandleKey(ConsoleKey key)
        {
            Direction = key switch
            {
                ConsoleKey.DownArrow => Direction.Down,
                ConsoleKey.UpArrow => Direction.Top,
                ConsoleKey.LeftArrow => Direction.Left,
                ConsoleKey.RightArrow => Direction.Right,
            };
            Speed = 100;
        }

        Symbol GetNewHead()
        {
            Symbol head = ListSymbols.Last();
            Symbol newHead = new(head.X, head.Y, head.Sign);
            newHead.Move(Direction);

            return newHead;
        }
    }
}
