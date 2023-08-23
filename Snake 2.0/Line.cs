using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2._0
{
    internal class Line
    {
        private List<Symbol>line=new List<Symbol>();
        public readonly int Length;
        public Direction direction { get; set; }

        private Symbol origin;

        public Line(Symbol symbol,int length, Direction direction)
        {
            origin= symbol;
            Length = length;
            this.direction = direction;

            InitialLine();
        }
        protected void InitialLine()
        {
            switch (direction)
            {
                case Direction.Right:
                    for (int i = 0; i < Length; i++)
                    {
                        line.Add(new Symbol(origin.X + i, origin.Y, origin.Token));
                    }
                    break;
                case Direction.Left:
                    for (int i = 0; i < Length; i++)
                    {
                        line.Add(new Symbol(origin.X - i, origin.Y, origin.Token));
                    }
                    break;
                case Direction.Down:
                    for (int i = 0; i < Length; i++)
                    {
                        line.Add(new Symbol(origin.X, origin.Y + i, origin.Token));
                    }
                    break;
                case Direction.Top:
                    for (int i = 0; i < Length; i++)
                    {
                        line.Add(new Symbol(origin.X, origin.Y - i, origin.Token));
                    }
                    break;
            }
        }

        virtual public void Draw()
        {
            foreach (Symbol symbol in line)
            {
                symbol.Draw();
            }
        }
    }
}
