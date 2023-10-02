using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2._0
{
    internal class Player
    {
        public int Score { get; set; }

        public string Login { get; set; }

        public string Password { get; set; } 

        public int Record { get; set; }

        public Player()
        {
            Score = 0;
            Login = "anonim";
            Record = 0;
            Password = string.Empty;
        }

        public Player(string login,string password)
        {
            Login = login;
            Password = password;
            Score = 0;
            Record = 0;
        }
    }
}
