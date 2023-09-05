using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2._0
{
    internal class Line
    {
        public int Length { get; protected set; }
        public Direction Direction { get; set; }

        protected Symbol origin;
        public List<Symbol> _Line { get; protected set; }

        public Line(Symbol symbol, Direction direction, int length)
        {
            _Line = new List<Symbol>();
            origin = symbol;
            Length = length;
            Direction = direction;
            
            InitialLine();
        }
        protected void InitialLine()
        {
            switch (Direction)
            {
                case Direction.Right:
                    for (int i = 0; i < Length; i++)
                    {
                        _Line.Add(new Symbol(origin.X + i, origin.Y, origin.Sign));
                    }
                    break;
                case Direction.Left:
                    for (int i = 0; i < Length; i++)
                    {
                        _Line.Add(new Symbol(origin.X - i, origin.Y, origin.Sign));
                    }
                    break;
                case Direction.Down:
                    for (int i = 0; i < Length; i++)
                    {
                        _Line.Add(new Symbol(origin.X, origin.Y + i, origin.Sign));
                    }
                    break;
                case Direction.Top:
                    for (int i = 0; i < Length; i++)
                    {
                        _Line.Add(new Symbol(origin.X, origin.Y - i, origin.Sign));
                    }
                    break;
            }
        }

        virtual public void Draw()
        {
            foreach (Symbol symbol in _Line)
            {
                symbol.Draw();
            }
        }
    }
}
