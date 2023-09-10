using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2._0
{
    internal class Border
    {
        Line[] lines = new Line[4];
        public int WidthScen { get; protected set; }
        public int HeightScene { get; protected set; }

        public Border(int widthScen, int heightScene)
        {
            WidthScen = widthScen;
            HeightScene = heightScene;

            Console.SetWindowSize(widthScen, heightScene);
            Console.SetBufferSize(widthScen, heightScene);
            Console.CursorVisible = false;

            lines[0] = new Line(new Symbol(0, 0, '#'), Direction.Right, widthScen);
            lines[1] = new Line(new Symbol(0, 0, '#'), Direction.Down, heightScene - 10);
            lines[2] = new Line(new Symbol(widthScen - 1, 0, '#'), Direction.Down, heightScene - 10);
            lines[3] = new Line(new Symbol(0, heightScene - 10, '#'), Direction.Right, widthScen);
        }

        public void Draw()
        {
            foreach (Line line in lines)
            {
                line.Draw();
            }
        }

        /*public bool IsHit(Symbol sym)
        {
            bool isHit = true;
            foreach (Line line in lines)
            { 
                isHit = line.IsHit(sym);
            }
            return isHit;
        }*/

        public bool IsOutBorder(Symbol sym)
        {
            if ((sym.X > 0 && sym.X < WidthScen - 2) &&
                (sym.Y > 0 && sym.Y < HeightScene - 10))
            {
                return true;
            }
            return false;
        }
    }
}
