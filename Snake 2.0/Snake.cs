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

        int speed;

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
        Direction direction;
        Direction Direction
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

        public Snake(Symbol symbol, Direction direction = Direction.Left, int length = 3)
            : base(symbol, direction, length)
        {
            speed = 100;
            this.direction = direction;
        }

        public void Move()
        {
            Symbol tail = _Line.First();
            _Line.Remove(tail);
            Symbol newHead = GetNewHead();
            _Line.Add(newHead);

            newHead.Draw();
            tail.Clear();
        }

        public void Eat()
        {
            Symbol head = GetNewHead();
            _Line.Add(head);
            head.Draw();
        }

        public Symbol GetHead()
        {
            return _Line.Last();
        }

        public bool IsEatYourself()
        {
            for (int i = 0; i < _Line.Count - 1; i++)
            {
                if (_Line.Last().X == _Line[i].X && _Line.Last().Y == _Line[i].Y)
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
            if (key == ConsoleKey.DownArrow)
            {
                Direction = Direction.Down;
            }
            else if (key == ConsoleKey.UpArrow)
            {
                Direction = Direction.Top;
            }
            else if (key == ConsoleKey.LeftArrow)
            {
                Direction = Direction.Left;
            }
            else if (key == ConsoleKey.RightArrow)
            {
                Direction = Direction.Right;
            }
            Speed = 100;
        }

        Symbol GetNewHead()
        {
            Symbol head = _Line.Last();
            Symbol newHead = new(head.X, head.Y, head.Sign);
            newHead.Move(Direction);
            return newHead;
        }
    }
}
