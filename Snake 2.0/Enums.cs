using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2._0
{
    enum Direction
    {
        Left,
        Right,
        Top,
        Down
    }

    enum GameState
    {
        Start = -1,
        Play,
        CreateAccount,
        ViewRecordTable,
        Quit
    }
}
