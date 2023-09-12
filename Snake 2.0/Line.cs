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
        public List<Symbol> ListSymbols { get; protected set; }

        public Line(Symbol symbol, Direction direction, int length)
        {
            ListSymbols = new List<Symbol>();
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
                        ListSymbols.Add(new Symbol(origin.X + i, origin.Y, origin.Sign));
                    }
                    break;
                case Direction.Left:
                    for (int i = 0; i < Length; i++)
                    {
                        ListSymbols.Add(new Symbol(origin.X - i, origin.Y, origin.Sign));
                    }
                    break;
                case Direction.Down:
                    for (int i = 0; i < Length; i++)
                    {
                        ListSymbols.Add(new Symbol(origin.X, origin.Y + i, origin.Sign));
                    }
                    break;
                case Direction.Top:
                    for (int i = 0; i < Length; i++)
                    {
                        ListSymbols.Add(new Symbol(origin.X, origin.Y - i, origin.Sign));
                    }
                    break;
            }
        }

        virtual public void Draw()
        {
            foreach (Symbol symbol in ListSymbols)
            {
                symbol.Draw();
            }
        }

        public bool IsHit(Symbol sym)
        {
            foreach (Symbol symbol in ListSymbols)
            {
                if (symbol.X == sym.X && symbol.Y == sym.Y)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
